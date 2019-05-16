using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropTest
{
    public class TestObject
    {
        public string Name { get; set; }
        public string Range { get; set; }
        public string Total { get; set; }

        public TestObject(string name, string range, string total)
        {
            Name = name;
            Range = range;
            Total = total;
        }

        public override string ToString()
        {
            return string.Format("\nName: {0}, Range: {1}, Total: {2}", Name, Range, Total);
        }
    }
}
