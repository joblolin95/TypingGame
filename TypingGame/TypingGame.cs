using System;
using System.IO;
using System.Diagnostics;

namespace TypingGame
{
    class TypingGame
    {
        string[] dictionary;
        int dLength;

        double timeTaken;
        int duration;

        int wordsCompleted;
        int misspelled;
        int wpm;

        String word;
        String inputWord;

        Random rand;
        Stopwatch sw;
        

        public TypingGame()
        {
            timeTaken = 0;
            duration = 0;
            wordsCompleted = 0;
            misspelled = 0;
            wpm = 0;
            
            word = "";
            rand = new Random();
            sw = new Stopwatch();
            inputWord = "";
            dLength = 0;
            
        }// end constructor


        public void readDictionary(string name)
        {

            dictionary = new string[dLength];
            string fullPath = Path.GetFullPath(name);

            int i = 0;
            //"C:\\Users\\Blaine's Laptop\\Documents\\Visual Studio 2015\\Projects\\TypingGame\\TypingGame\\" + name
            using (StreamReader inf = new StreamReader(fullPath))
            {
                while (!inf.EndOfStream)
                {

                    if (Char.IsControl((char)inf.Peek()))
                    {
                        inf.ReadLine();
                        continue;
                    }
                    
                    dictionary[i] = inf.ReadLine();
                    i++;

                }// end while
            }// end using
            
            Array.Sort(dictionary);

        }// end readDictionary


        public void displayMenu()
        {

            Console.WriteLine("\t\tGame Menu");
            getDifficulty();
            getDuration();      

        }// end displayMenu


        public void displayWord()
        {
           
            int index = rand.Next(0, dictionary.Length);

            word = dictionary[index];

            Console.WriteLine(word);

        }// end displayWord method


        public void getWord()
        {
            sw.Start();
            inputWord = Console.ReadLine();
            sw.Stop();
            timeTaken += sw.Elapsed.Seconds;

            if (!inputWord.Equals(word))
            {
                misspelled++;
            }// end if
            wordsCompleted++;
          
            Console.WriteLine();
            sw.Reset();
        }// end getWord


        public bool isTimeUp()
        {
            return timeTaken >= duration;
        }// end method


        public void displayWPM()
        {
            double min = timeTaken / 60.0;
            double gross = (wordsCompleted) / min;

            wpm = (int)(gross - (misspelled / min));

            Console.WriteLine("WPM: " + wpm);
            Console.WriteLine("Misspelled Words: " + misspelled);

        }// end displayWPM


        void getDuration()
        {
            Console.WriteLine("1 - 30 Second Challenge");
            Console.WriteLine("2 - 1 Minute Challenge");
            Console.WriteLine("3 - 2 Minute Challenge");
            Console.Write("\nChoose Game Mode: ");

            duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            while (duration != 1 && duration != 2 && duration != 3)
            {
                Console.Write("\nPlease Enter A Valid Game Mode: ");
                duration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }// end while

            if (duration == 1)
            {
                duration = 30;
            }
            else if (duration == 2)
            {
                duration = 60;
            }
            else if (duration == 3)
            {
                duration = 120;
            }
        }// end getDuration


        void getDifficulty()
        {
            Console.WriteLine("1 - Easy");
            Console.WriteLine("2 - Challenging");
            Console.WriteLine("3 - Difficult");
            Console.Write("\nEnter Game Difficulty: ");

            dLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            while(dLength != 1 && dLength != 2 && dLength != 3)
            {
                Console.Write("Please Enter A Valid Game Difficulty: ");
                dLength = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }// end while

            if(dLength == 1)
            {
                dLength = 91;
                readDictionary("easy.txt");
            }// end if
            else if(dLength == 2)
            {
                dLength = 91;
                readDictionary("challenging.txt");
            }// end else if
            else
            {
                dLength = 235886;
                readDictionary("dictionary.txt");
            }// end else

        }// end getDifficulty


        public void displayOutcome()
        {
            if(wpm < 25)
            {
                Console.WriteLine("Oh no! Dr. Nefarious escaped on his Evil-Copter!! The world is doomed!");
            }// end if
            else if(wpm >= 25 && wpm < 40)
            {
                Console.WriteLine("Whew. You tripped Dr. Nefarious juuuuuust as he was boarding his Evil-Copter. Threat averted. The world is safe again.");
            }// end else if
            else
            {
                Console.WriteLine("Great job! You caught Dr. Nefarious and gave him a whopping he's not sure to forget anytime soon. What would the world do without you?");
            }// end else
        }// end displayOutcome method


        public void displayIntro()
        {
            Console.WriteLine("\t\tHero Typing Game\n");
            Console.WriteLine("You must hurry, Agent!  Dr. Nefarious has stolen a powerful nuclear weapon, and is rushing to his Evil-Copter to unleash the weapon's power upon the world!");
            Console.WriteLine("\nYou must use your masterful typing skills to catch him before he escapes or we're all doomed!");
            Console.WriteLine("\nSimply retype the words before you, and get a score good enough to catch the evil madman.");
            Console.WriteLine("\nGood luck, Agent, and remember - we're all counting on you.\n");

        }// end displayIntro

    }// end class
}// end namespace
