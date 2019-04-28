using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TableAttribute:Attribute
    {
        public string _name;
        public TableAttribute(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
    }
}
