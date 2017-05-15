using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Models;
using Task2.Interface;
using Task2.StringHelper;




namespace Task2.Models
{
    public class Text : ICountable, IText

    {
        private StringBuilder _sbText;
        public List<ISentence> Sentences { get; protected set; }
        public Text ()
        {
            Sentences = new List<ISentence>();
        }

        public void Parse(string path)
        {
            try
            {
                _sbText = new StringBuilder();
                using (var sr = new StreamReader(path))
                {
                    var line = sr.ReadToEnd().Replace("\n", String.Empty).Replace("\r", String.Empty).Replace("\t", String.Empty);
                    _sbText.Append(line);
                }

                var senstences = Regex.Split(_sbText.ToString(), @"(?<=[.?!])");
                foreach (var sentence in senstences)
                {
                    Sentences.Add( Sentence.Parse(sentence));
                }
            }
            catch (Exception e)
            {

            }
        }

        public string FullText
        { get { return _sbText.ToString(); } }

        public int Count
        { get { return Sentences.Count(); } }

        public override string ToString()
        {
            return String.Join(" ", Sentences);
        }

        public List<ISentence> OrderbyWordsCount()
        {
            return Sentences.OrderByDescending(x => x.Count).ToList();
        }

        public List<IWord> GetInterrogativeSentence (int wordLenght)
        {
            List <IWord> result = new List<IWord>();

            foreach (var sentence in Sentences.Where(x=>x.IsInterrogative))
            {
                foreach (var word in sentence.Words.Where(x=>x.Count==wordLenght))
                    {
                    if (!result.Contains(word))
                            {result.Add(word);}
                    }
            }

            return result;
        }

        public Text  RemoveWordsWithConsonantLetter (int WordLenght)
        {
            var result = new Text();
            
            foreach (var sentence in Sentences)
            {
                result.Sentences.Add(new Sentence(sentence.Words.Where(x => !(x.Count == WordLenght && x.IsConsonant)),sentence.Separator));
            }
            return result;          
        }

        public Text TextChangeOnSubstring(int sentenceNumber, int wordLenght, string subString)
        {
            Word tempWord = new Word(subString);

            var result = new Text();


            for (int index = 0; index < Sentences.Count; index++)
            {
                if (index == sentenceNumber - 1)
                {
                    result.Sentences.Add(new Sentence(Sentences[index].Words.Select(x => x.Count == wordLenght ? tempWord : x), Sentences[index].Separator));
                }
                else
                {
                    result.Sentences.Add(new Sentence(Sentences[index].Words, Sentences[index].Separator));
                }
            }
            return result;
        }
    }
}
