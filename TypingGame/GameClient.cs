using System;

namespace TypingGame
{
    class GameClient
    {
        static void Main(string[] args)
        {

            string response = "y";
            while (response.Equals("Y") || response.Equals("y"))
            {
                TypingGame type = new TypingGame();

                
                type.displayIntro();
                type.displayMenu();

                Console.Clear();
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
				Console.Clear();
            }// end outer while            
            Console.ReadKey();
			


        }// end main
    }// end class
}// end namespace
