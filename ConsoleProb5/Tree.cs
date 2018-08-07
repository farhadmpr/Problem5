using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProb5
{
    class Tree
    {
        public int Value { get; set; }
        public Tree PlusNode { get; set; }
        public Tree MinusNode { get; set; }
        public Tree ConcatNode { get; set; }
        public string Sign { get; set; }
    }
}
