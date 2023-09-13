using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Classes
{
    public class KuratorOMSU
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public OMSU OMSU { get; set; }

        public KuratorOMSU(string secondName, string firstName, string thirdName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
        }

        public override bool Equals(object? obj)
        {
            return obj is KuratorOMSU oMSU &&
                   FirstName == oMSU.FirstName &&
                   SecondName == oMSU.SecondName &&
                   ThirdName == oMSU.ThirdName &&
                   OMSU.Equals(oMSU.OMSU);
        }

        public override string ToString()
        {
            return $"{SecondName}, {FirstName}, {ThirdName}";
        }
    }
}
