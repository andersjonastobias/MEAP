using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEAPImmutableList
{
    class Animal
    {
        public override string ToString() => GetType().Name;
    }
    class Tiger : Animal { }
    class Giraffe : Animal { }
}
