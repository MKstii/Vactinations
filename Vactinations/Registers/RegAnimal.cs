using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vactinations.Classes;

namespace Vactinations.Registers
{
    public static class RegAnimal
    {
        private static List<Animal> animals = new List<Animal>();
        public static Animal FindAnimal(int animalID)
        {
            return animals.Find(x => x.ChipNumber == animalID);
        }
        public static void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }
    }
}
