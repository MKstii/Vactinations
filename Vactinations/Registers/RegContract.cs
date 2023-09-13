using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vactinations.Classes;

namespace Vactinations.Registers
{
    public static class RegContract
    {
        private static int counter = 1;
        private static List<Contract> contracts = new List<Contract>();
        public static void CreateContract(string orgName, string supervisorName, string vetName,
            string kuratorName, DateOnly endDate, double vacPrice)
        {
            var org = RegOrganization.FindOrganization(orgName);
            var superV = org.Find(supervisorName);
            var vet = RegVetclinic.FindVetclinic(vetName);
            var kur = vet.FindKurator(kuratorName);
            var dateStart = DateOnly.FromDateTime(DateTime.Today);
            var con = new Contract(counter, dateStart, endDate, vacPrice, vet, org, superV, kur);
            counter++;
            contracts.Add(con);
        }
        public static Contract FindContract(int conNumber)
        {
            return contracts.Find(x => x.ContructNumber == conNumber);
        }
        public static void Clear()
        {
            contracts.Clear();
            counter = 1;
        }
    }
}
