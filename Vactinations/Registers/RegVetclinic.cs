using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vactinations.Classes;

namespace Vactinations.Registers
{
    public static class RegVetclinic
    {
        private static List<Vetclinic> vetclinics = new List<Vetclinic>();
        public static Vetclinic FindVetclinic(string vetName)
        {
            return vetclinics.Find(x => x.Name == vetName);
        }
        public static void AddVetclinic(Vetclinic vet)
        {
            vetclinics.Add(vet);
        }
    }
}
