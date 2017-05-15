using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Interface;

namespace Task2.Models
{
    public class Sentence : ISentence
    {
        private string _sentence = "";
        public char Separator { get; protected set; }
        public List<IWord> Words { get; protected set; } 
        public bool IsInterrogative
        {
            get { return _sentence.EndsWith("?"); }
        }
        public Sentence ()
        {
            Words = new List<IWord>();
        }
        private Sentence(string sentence, char separator):this() 
        {
            _sentence = sentence;
            Separator = separator;
        }

        public Sentence (IEnumerable<IWord> words, char separator)
        {
            Words = new List<IWord>(words);
            Separator = separator;
        }


        public static Sentence Parse(string sentence)
        {
            var simpleSentence = Regex.Replace(sentence.Trim(), "[^a-zA-Z0-9 ]", "");
            var words = simpleSentence.Split(' ');
            var result = new Sentence(sentence.Trim(),sentence.LastOrDefault());

            foreach (var word in words)
            {
                result.Words.Add(new Word(word));
            }
            return result;
        }

        public int Count
        {get { return Words.Count(); } }

        public  string ToRawString()
        {
            return  _sentence;
        }

        public override string ToString()
        {
            return String.Join(" ", Words) + Separator;
        }

    }
}
