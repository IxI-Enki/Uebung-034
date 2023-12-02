/*------------------------------------------------------------------------------
 *                      HTBLA-Leonding / Class: 3ACIF
 *------------------------------------------------------------------------------
 *                      Jan Ritt
 *------------------------------------------------------------------------------
 *  Description:  The program reads in a Number and tells the user if the number
 *                is a primenumber, it shall do this with once with a while loop
 *                and once with a for loop.
 *                Further: the program shall output all primes from 1 to 10_000.
 *------------------------------------------------------------------------------
*/

/* Wikipedia Recherche:
 *    Der einfachste Primzahltest ist die Probedivision. 
 *    Dabei probiert man nacheinander, ob die Zahl n durch eine der Primzahlen p mit 2 ≤ p ≤ √n teilbar ist.
 *    Wenn nicht, dann ist n eine Primzahl. 
 *    
 *    In der Praxis wird die Probedivision nur für kleine n bis etwa eine Million eingesetzt.
 *    Für größere n sind andere Verfahren effizienter.
 */

using System;
using System.Threading;

namespace PrimzahlenCheck
{
  internal class Program
  {
    static void Main()
    {
      /*  SET SCREEN  */
      const int consoleWidth = 58;
      const int consoleHeight = 30;
      Console.SetWindowSize(consoleWidth, consoleHeight);

      /*  VARIABLES  */
      string userInput;      //
      char userChoice;       //
      int primeCandidate;    //
      int divisor;           //
      bool isPrime;          //

      /*  START PROMT  */
      Console.Clear();
      Console.Write("\n                    Primzahlen Checker                    " +
                    "\n==========================================================");

      Console.Write("\n Wählen Sie die Art der Berechnung:          " +
                    "\n [w] - Berechnung mittels While-Schleife     " +
                    "\n [f] - Berechnung mittels For-Schleife       " +
                    "\n [a] - Prüft alle Kandidaten von 1 bis 10000 " +
                    "\n ");

      userInput = Console.ReadLine();
      char.TryParse(userInput, out userChoice);
      switch (userChoice)
      {
        case 'w':  // solution with WHILE LOOP
          Console.Write("\n Geben Sie eine ganze Zahl ein, die getestet werden soll " +
                        "\n [0] - Abbrechen ");
          do
          {
            /*  INPUT  */
            userInput = Console.ReadLine();
            int.TryParse(userInput, out primeCandidate);

            /*  CALCULATION  */
            isPrime = primeCandidate >= 2 ? true : false;   //  isPrime true if candidate >= 2 
                                                            //  isPrime false if candidate < 2
            divisor = 2;
            while (divisor <= primeCandidate / 2 && isPrime)
            {
              isPrime = primeCandidate % divisor != 0 ? true : false;
              divisor++;
            }
            /*  OUTPUT  */
            Console.Write($"\n {primeCandidate} ist {(isPrime ? "eine" : "keine")} Primzahl.");
          } while (primeCandidate != 0);
          break;

        case 'f': // solution with FOR LOOP
          Console.Write("\n Geben Sie eine ganze Zahl ein, die getestet werden soll. " +
                        "\n [0] - Abbrechen ");
          do
          {
            /*  INPUT  */
            userInput = Console.ReadLine();
            int.TryParse(userInput, out primeCandidate);

            /*  CALCULATION  */
            isPrime = primeCandidate >= 2 ? true : false;   //  isPrime true if candidate >= 2 
                                                            //  isPrime false if candidate < 2
            for (divisor = 2; divisor <= primeCandidate / 2 && isPrime; divisor++)
            {
              isPrime = primeCandidate % divisor != 0 ? true : false;
            }
            /*  OUTPUT  */
            Console.Write($"\n {primeCandidate} ist {(isPrime ? "eine" : "keine")} Primzahl.");
          } while (primeCandidate != 0);
          break;

        case 'a':    //  TEST ALL NUMBERS 1 to 10_000
          Console.Write($"\n Alle Primzahlen bis 10000:");
          for (primeCandidate = 1; primeCandidate <= 10_000; primeCandidate++)
          {
            /*  CALCULATION  */
            isPrime = primeCandidate >= 2 ? true : false;   //  isPrime true if candidate >= 2 
                                                            //  isPrime false if candidate < 2
            for (divisor = 2; divisor <= primeCandidate / 2 && isPrime; divisor++)
            {
              isPrime = primeCandidate % divisor != 0 ? true : false;
            }
            /*  OUTPUT  */
            if (isPrime)
            {
              Console.Write($"\n {primeCandidate} ");
            }
          }
          break;
        default: break;
      }
      /*  END PROGRAM  */
      Console.Write("\nZum Beenden bitte Eingabetaste drücken ...");
      Console.ReadLine();
      Console.Clear();
    }
  }
}