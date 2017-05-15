using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interface;

namespace Task2.Models
{
    public class Word : IWord
    {
        private readonly string _word;
        private List<string> consonantLetters = new List<string>() { "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };

        public List<Symbol>  Symbols { get; protected set; }
        public bool IsConsonant
        {
            get { return consonantLetters.Any(x => _word.StartsWith(x)); }
        }

        public Word(string word)
        {
            _word = word;

            Symbols = new List<Symbol>();
            foreach (char symbol in word)
            {
                Symbols.Add(new Symbol(symbol));
            }
        }

        public string PrintWordFromSymbols()
        {
            var result = "";
            foreach (var symbol in Symbols)
            {
                result += symbol.StringSymbol();
            }
            return result;
        }

        public override string ToString()
        {
            return _word;
        }

        public int Count
        { get { return Symbols.Count; } }


        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
            { return false; }
            return _word == (other as Word).ToString();
        }

        
    }
}
