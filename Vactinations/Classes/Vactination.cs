using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Classes
{
    public class Vactination
    {
        public Doctor Doctor { get; }
        public Animal Animal { get; }
        public DateOnly DateVactination { get; }
        public Vactination(Doctor doctor, Animal animal, DateOnly dateVactination)
        {
            Doctor = doctor;
            Animal = animal;
            DateVactination = dateVactination;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vactination vactination &&
                   Doctor.Equals(vactination.Doctor) &&
                   Animal.Equals(vactination.Animal) &&
                   DateVactination.Equals(vactination.DateVactination);
        }
        public override string ToString()
        {
            return $"Doc: {Doctor.GetHashCode()}, Ani: {Animal.GetHashCode()}, Date: {DateVactination.GetHashCode()}";
        }
    }
}
