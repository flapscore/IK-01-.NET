using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class RingNode<T> 
    {
        public T Value { get; private set; }
        public RingNode<T> Next { get; set; }

        public RingNode(T value)
        {
            Value = value;
            Next = null;
        }
    }
}
