using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingGame
{
    class GameClient
    {
        static void Main(string[] args)
        {

            string response = "y";
            while (response.Equals("Y") || response.Equals("y"))
            {
                Console.Clear();
                TypingGame type = new TypingGame();

                
                type.displayIntro();
                type.displayMenu();
                
                Console.WriteLine("Ready ...");
                Console.ReadKey();
                Console.WriteLine("\nSet ...");
                Console.ReadKey();
                Console.WriteLine("\nGo!\n");

                while (!type.isTimeUp())
                {


                    type.displayWord();
                    type.getWord();
                }// end while

                type.displayWPM();
                type.displayOutcome();

                Console.Write("\nPlay Again (Y / N)? ");
                response = Console.ReadLine();
                Console.WriteLine();
            }// end outer while            
            Console.ReadKey();


        }// end main
    }// end class
}// end namespace
