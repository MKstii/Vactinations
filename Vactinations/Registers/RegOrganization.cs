using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vactinations.Classes;

namespace Vactinations.Registers
{
    public static class RegOrganization
    {
        private static List<OMSU> organizations = new List<OMSU>();
        public static OMSU FindOrganization(string orgName)
        {
            return organizations.Find(x => x.Name == orgName);
        }
        public static void AddOrganization(OMSU org)
        {
            organizations.Add(org);
        }
    }
}
