using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Classes
{
    public class Locality
    {
        private string name;

        public Locality(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; } 
        }

        public override bool Equals(object? obj)
        {
            return obj is Locality locality &&
                   name == locality.name &&
                   Name == locality.Name;
        }
    }
}
