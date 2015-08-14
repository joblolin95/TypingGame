using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TypingGame
{
    class BinarySearch
    {
        string[] dictionary;
        bool status;

        public void readDictionary()
        {

            dictionary = new string[235886];

            int i = 0;

            using (StreamReader inf = new StreamReader("C:\\Users\\Blaine's Laptop\\Documents\\Visual Studio 2015\\Projects\\TypingGame\\TypingGame\\dictionary.txt"))
            {
                while (!inf.EndOfStream)
                {
                    dictionary[i] = inf.ReadLine();
                    i++;

                }// end while
            }// end using
            Array.Sort(dictionary);
        }// end readDictionary

        public bool binarySearch(String key)
        {
            int low = 0;
            int high = dictionary.Length;
            status = false;

            binarySearch(key, low, high);

            return status;
        }// end binarySearch method

        public void binarySearch(String key, int low, int high)
        {
            int mid = (low + high) / 2;
            String midElement = dictionary[mid];

            if(low > high)
            {
                status = false;
            }// end if

            else if (key.Equals(midElement))
            {
                status = true;
            }// end if
            else if (key.CompareTo(midElement) < 0)
            {
                binarySearch(key, low, mid - 1);
            }// end else if
            else
            {
                binarySearch(key, mid + 1, high);
            }// end else
        }// end overloaded binarySearch

        public String get(int index)
        {
            return dictionary[index];
        }
        
        public int getDictionarySize()
        {
            return dictionary.Length;
        }
    }// end class
}// end namespace
