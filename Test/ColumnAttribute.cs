using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ColumnAttribute:Attribute
    {
        public string _name;
        public ColumnAttribute(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            var aa = "";
            return _name;
        }
    }
}
