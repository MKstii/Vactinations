using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Registers
{
    public static class Reg
    {
        public static void CreateContract(string orgName, string supervisorName, string vetName, 
            string kuratorName, DateOnly endDate, double vacPrice)
        {
            RegContract.CreateContract(orgName, supervisorName, vetName, kuratorName, endDate, vacPrice);
        }
        public static void AddVactination(int animalID, string docName, string vetName)
        {
            RegVactination.AddVactination(animalID, docName, vetName);
        }
        public static int GetReportByVactinations(DateOnly startDate, DateOnly endDate, string vetName)
        {
            return ReportMaker.GetReportByVactinations(startDate, endDate, vetName);
        }
        public static double GetPriceReportByContractNumber(int conNumber, string vetName)
        {
            return ReportMaker.GetPriceReportByContractNumber(conNumber, vetName);
        }
        public static void ClearReg()
        {
            RegContract.Clear();
            RegVactination.Clear();
        }
    }
}
