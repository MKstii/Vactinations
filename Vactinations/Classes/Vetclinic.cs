using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Classes
{
    public class Vetclinic
    {
        private List<KuratorVetclinnic> kurators = new List<KuratorVetclinnic>();
        private List<Doctor> doctors = new List<Doctor>();
        public string Name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public BusinessEntity businessEntity { get; set; }
        public string Adress { get; set; }
        public Locality Locality { get; set; }
        public Vetclinic(string name, string iNN, string kPP, BusinessEntity businessEntity, string adress, Locality locality)
        {
            Name = name;
            INN = iNN;
            KPP = kPP;
            this.businessEntity = businessEntity;
            Adress = adress;
            Locality = locality;
        }
        public KuratorVetclinnic FindKurator(string kuratorName)
        {
            string[] name = kuratorName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return kurators.FindAll(x => x.SecondName == name[0])
                .FindAll(x => x.FirstName == name[1])
                .Find(x => x.ThirdName == name[2]);
        }
        public Doctor FindDoctor(string docName)
        {
            string[] name = docName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return doctors.FindAll(x => x.SecondName == name[0])
                .FindAll(x => x.FirstName == name[1])
                .Find(x => x.ThirdName == name[2]);
        }
        public void AddDoctor(Doctor doc)
        {
            doctors.Add(doc);
            doc.Vetclinic = this;
        }
        public void AddKurator(KuratorVetclinnic kur)
        {
            kurators.Add(kur);
            kur.Vetclinic = this;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vetclinic vetclinic &&
                   kurators.Select(x => x.ToString()).SequenceEqual(vetclinic.kurators.Select(x => x.ToString())) &&
                   doctors.Select(x => x.ToString()).SequenceEqual(vetclinic.doctors.Select(x => x.ToString())) &&
                   Name == vetclinic.Name &&
                   INN == vetclinic.INN &&
                   KPP == vetclinic.KPP &&
                   businessEntity == vetclinic.businessEntity &&
                   Adress == vetclinic.Adress &&
                   EqualityComparer<Locality>.Default.Equals(Locality, vetclinic.Locality);
        }
    }
}
