using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Classes
{
    public class Animal
    {
        public AnimalType AnimalType { get; }
        public int ChipNumber { get; set; }
        public int BirthYear { get; }
        public Gender Gender { get; }
        public Animal(AnimalType animalType, int chipNumber, int birthYear, Gender gender)
        {
            AnimalType = animalType;
            ChipNumber = chipNumber;
            BirthYear = birthYear;
            Gender = gender;
        }

        public override bool Equals(object? obj)
        {
            return obj is Animal animal &&
                   AnimalType == animal.AnimalType &&
                   ChipNumber == animal.ChipNumber &&
                   BirthYear == animal.BirthYear &&
                   Gender == animal.Gender;
        }
    }
}
