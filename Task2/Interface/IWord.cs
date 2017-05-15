using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Interface
{
    public interface IWord : ICountable
    {
        List<Symbol> Symbols { get; }
        bool IsConsonant { get; }
    }
}
