using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vactinations.Classes
{
    public class Contract
    {
        public int ContructNumber { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public double VactinationPrice { get; set; }
        public Vetclinic Vetclinic { get; }
        public OMSU OMSU { get; }
        public KuratorOMSU KuratorOMSU { get; }
        public KuratorVetclinnic KuratorVetclinic { get; }
        public Contract(int contructNumber, DateOnly dateStart, DateOnly dateEnd, 
            double vactinationPrice, Vetclinic vetclinic, OMSU oMSU,
            KuratorOMSU kuratorOMSU, KuratorVetclinnic kuratorVetclinic)
        {
            ContructNumber = contructNumber;
            DateStart = dateStart;
            DateEnd = dateEnd;
            VactinationPrice = vactinationPrice;
            Vetclinic = vetclinic;
            OMSU = oMSU;
            KuratorOMSU = kuratorOMSU;
            KuratorVetclinic = kuratorVetclinic;
        }

        public override bool Equals(object? obj)
        {
            return obj is Contract contract &&
                   ContructNumber == contract.ContructNumber &&
                   DateStart.Equals(contract.DateStart) &&
                   DateEnd.Equals(contract.DateEnd) &&
                   VactinationPrice == contract.VactinationPrice &&
                   EqualityComparer<Vetclinic>.Default.Equals(Vetclinic, contract.Vetclinic) &&
                   EqualityComparer<OMSU>.Default.Equals(OMSU, contract.OMSU) &&
                   EqualityComparer<KuratorOMSU>.Default.Equals(KuratorOMSU, contract.KuratorOMSU) &&
                   EqualityComparer<KuratorVetclinnic>.Default.Equals(KuratorVetclinic, contract.KuratorVetclinic);
        }

        public override string? ToString()
        {
            return $"ID:{ContructNumber.GetHashCode()}, DateStart: {DateStart.GetHashCode()}, DateEnd: {DateEnd.GetHashCode()}, " +
                $"Price: {VactinationPrice.GetHashCode()}, Vetclinic: {Vetclinic.GetHashCode()}, OMSU: {OMSU.GetHashCode()}, " +
                $"KuratorOMSU: {KuratorOMSU.GetHashCode()}, KuratorVet: {KuratorVetclinic.GetHashCode()}," +
                $"Hash: {this.GetHashCode()}";
        }
    }
}
