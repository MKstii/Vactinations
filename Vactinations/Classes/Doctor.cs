using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Classes
{
    public class Doctor
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public Vetclinic Vetclinic { get; set; }

        public Doctor(string secondName, string firstName, string thirdName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
        }

        public override bool Equals(object? obj)
        {
            return obj is Doctor doctor &&
                   FirstName == doctor.FirstName &&
                   SecondName == doctor.SecondName &&
                   ThirdName == doctor.ThirdName &&
                   Vetclinic.Equals(doctor.Vetclinic);
        }
        public override string ToString()
        {
            return $"{SecondName}, {FirstName}, {ThirdName}";
        }
    }
}
