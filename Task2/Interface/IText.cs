using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Interface
{
    public interface IText
    {
        List<ISentence> Sentences { get; }
    }
}
