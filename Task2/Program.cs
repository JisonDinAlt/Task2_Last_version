using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;
using Task2.StringHelper;



namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

             Text text = new Text();
            text.Parse(AppDomain.CurrentDomain.BaseDirectory + @"\Files\Text1.txt");

            Console.WriteLine(text.ToString());

            Console.WriteLine(String.Join(" ", text.OrderbyWordsCount()));

            Console.WriteLine(String.Join(" ", text.GetInterrogativeSentence(2)));
            
            Console.WriteLine(text.RemoveWordsWithConsonantLetter(5));

            Console.WriteLine(text.TextChangeOnSubstring(2, 5, "SimpleSubstring"));


            Console.ReadKey();
              
         }

        
    }
}
