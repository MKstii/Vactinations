using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vactinations.Classes;

namespace Vactinations.Registers
{
    public static class RegVactination
    {
        private static List<Vactination> vactinations = new List<Vactination>(); 
        public static void AddVactination(int animalID, string docName, string vetName)
        {
            var vet = RegVetclinic.FindVetclinic(vetName);
            var doc = vet.FindDoctor(docName);
            var ani = RegAnimal.FindAnimal(animalID);
            var currentDate = DateOnly.FromDateTime(DateTime.Today);
            var vac = new Vactination(doc, ani, currentDate);
            vactinations.Add(vac);
        }
        public static List<Vactination> GetVactinationsByDate(DateOnly startDate, DateOnly endDate, Vetclinic vetclinic)
        {
            return vactinations.FindAll(x => x.Doctor.Vetclinic == vetclinic)
                .FindAll(x => x.DateVactination <= endDate)
                .FindAll(x => x.DateVactination >= startDate);
        }
        public static int GetVactinationsCount(Vetclinic vet, Contract con)
        {
            var vacs = vactinations.FindAll(x => x.Doctor.Vetclinic == vet)
                .FindAll(x => x.DateVactination >= con.DateStart)
                .FindAll(x => x.DateVactination <= con.DateEnd);
            return vacs.Count();
        }
        public static Vactination GetLastVactination()
        {
            return vactinations.Last();
        }
        public static void Clear()
        {
            vactinations.Clear();
        }
    }
}
