using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vactinations.Registers;

namespace Vactinations
{
    public static class ReportMaker
    {
        public static int GetReportByVactinations(DateOnly startDate, DateOnly endDate, string vetName)
        {
            var vetclinic = RegVetclinic.FindVetclinic(vetName);
            var vacs = RegVactination.GetVactinationsByDate(startDate, endDate, vetclinic);
            return vacs.Count();
        }
        public static double GetPriceReportByContractNumber(int conNumber, string vetName)
        {
            var vet = RegVetclinic.FindVetclinic(vetName);
            var con = RegContract.FindContract(conNumber);
            var vacCount = RegVactination.GetVactinationsCount(vet, con);
            double report = con.VactinationPrice * vacCount;
            return report;
        }
    }
}
