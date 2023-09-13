using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Classes
{
    public class OMSU
    {
        private List<KuratorOMSU> kurators = new List<KuratorOMSU>();
        public string Name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public BusinessEntity businessEntity { get; set; }
        public string Adress { get; set; }
        public Locality Locality { get; set; }
        public OMSU(string name, string iNN, string kPP, BusinessEntity businessEntity, string adress, Locality locality)
        {
            Name = name;
            INN = iNN;
            KPP = kPP;
            this.businessEntity = businessEntity;
            Adress = adress;
            Locality = locality;
        }

        public KuratorOMSU Find(string supervisorName)
        {
            var name = supervisorName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return kurators
                .FindAll(x => x.SecondName == name[0])
                .FindAll(x => x.FirstName == name[1])
                .Find(x => x.ThirdName == name[2]);
        }

        public void AddKurator(KuratorOMSU kur)
        {
            kurators.Add(kur);
            kur.OMSU = this;
        }

        public override bool Equals(object? obj)
        {
            return obj is OMSU oMSU &&
                   kurators.Select(x => x.ToString()).SequenceEqual(oMSU.kurators.Select(x => x.ToString())) &&
                   Name == oMSU.Name &&
                   INN == oMSU.INN &&
                   KPP == oMSU.KPP &&
                   businessEntity == oMSU.businessEntity &&
                   Adress == oMSU.Adress &&
                   EqualityComparer<Locality>.Default.Equals(Locality, oMSU.Locality);
        }
    }
}
