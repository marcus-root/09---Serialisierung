using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON___03___FizzBuzz
{
    internal class Word
    {
        public String Output { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"Zahlen die durch {Value} teilbar sind werden durch das Wort {Output} ersetzt.";
        }
    }
}
