using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vactinations.Classes;
using Vactinations.Registers;

namespace Vactinations
{
    [TestFixture]
    public class Application_Should
    {
        private static bool IsInitialize = false;
        private void InitializeComponent()
        {
            if (IsInitialize)
            {
                Reg.ClearReg();
                return;
            }
            var locality = new Locality("Тюмень");
            // Создаем ветклинику #1
            var vetclinic = new Vetclinic("Улыбка", "9922773648", "892642946",
                BusinessEntity.IP, "улица Пушкина, 69", locality);
            var kur = new KuratorVetclinnic("Веселов", "Михаил", "Константинович");
            var doctor = new Doctor("Ширгазина", "Аида", "Владиславовна");
            vetclinic.AddKurator(kur);
            vetclinic.AddDoctor(doctor);

            // Создаем ветклинику #2
            var vetclinic2 = new Vetclinic("Грустинка", "9912343648", "999642946",
                BusinessEntity.IP, "улица Ленина, 12", locality);
            var kur2 = new KuratorVetclinnic("Теплов", "Ярослав", "Игоревич");
            var doctor2 = new Doctor("Рудин", "Валентин", "Константинович");
            vetclinic2.AddKurator(kur2);
            vetclinic2.AddDoctor(doctor2);

            // Создаем ОМСУ
            var org = new OMSU("Муниципалитет г. Тюмень", "2830974658", "102749265",
                BusinessEntity.OOO, "улица Пушкина, 80", locality);
            var supervisor = new KuratorOMSU("Васильев", "Алексей", "Викторович");
            org.AddKurator(supervisor);

            // Создаем животных
            var ani = new Animal(AnimalType.Dog, 101, 2018, Gender.Man);
            var ani2 = new Animal(AnimalType.Cat, 1110, 2019, Gender.Woman);
            var ani3 = new Animal(AnimalType.Dog, 110, 2017, Gender.Man);

            // Добавляем в реестры
            RegVetclinic.AddVetclinic(vetclinic);
            RegVetclinic.AddVetclinic(vetclinic2);
            RegOrganization.AddOrganization(org);
            RegAnimal.AddAnimal(ani);
            RegAnimal.AddAnimal(ani2);
            RegAnimal.AddAnimal(ani3);

            IsInitialize = true;
        }
        [Test]
        public void CreateContract() // Тест на создание контракта
        {
            // Заполняем реестры
            InitializeComponent();

            // Имитируем полученные данные от пользователя
            var orgName = "Муниципалитет г. Тюмень";
            var supervisorName = "Васильев Алексей Викторович";
            var vetName = "Улыбка";
            var kuratorName = "Веселов Михаил Константинович";
            var endDate = DateOnly.FromDateTime(DateTime.Parse("20.07.2023"));
            var vacPrice = 1000;

            // Используем наш метод
            Reg.CreateContract(orgName, supervisorName, vetName, kuratorName, endDate, vacPrice);

            // Создаем объекты, для ожидаемого объекта
            var locality = new Locality("Тюмень");
            var vetclinic = new Vetclinic("Улыбка", "9922773648", "892642946",
                BusinessEntity.IP, "улица Пушкина, 69", locality);
            var kur = new KuratorVetclinnic("Веселов", "Михаил", "Константинович");
            vetclinic.AddKurator(kur);
            var doc = new Doctor("Ширгазина", "Аида", "Владиславовна");
            vetclinic.AddDoctor(doc);

            var org = new OMSU("Муниципалитет г. Тюмень", "2830974658", "102749265",
                BusinessEntity.OOO, "улица Пушкина, 80", locality);
            var supervisor = new KuratorOMSU("Васильев", "Алексей", "Викторович");
            org.AddKurator(supervisor);


            var myCon = RegContract.FindContract(1);
            var excpectedCon = new Contract(1, DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Parse("20.07.2023")),
                1000, vetclinic, org, supervisor, kur);

            Assert.AreEqual(excpectedCon, myCon);
        }

        [Test]
        public void AddVactination()
        {
            // Заполняем реестры
            InitializeComponent();

            // Имитируем полученные данные от пользователя
            var animalId = 110;
            var doctorName = "Ширгазина Аида Владиславовна";
            var vetName = "Улыбка";

            // Используем наш метод
            Reg.AddVactination(animalId, doctorName, vetName);

            // Создаем объекты, для ожидаемого объекта
            var locality = new Locality("Тюмень");

            var vetclinic = new Vetclinic("Улыбка", "9922773648", "892642946",
                BusinessEntity.IP, "улица Пушкина, 69", locality);
            var doc = new Doctor("Ширгазина", "Аида", "Владиславовна");
            vetclinic.AddDoctor(doc);
            var kur = new KuratorVetclinnic("Веселов", "Михаил", "Константинович");
            vetclinic.AddKurator(kur);

            var ani = new Animal(AnimalType.Dog, 110, 2017, Gender.Man);
            var date = DateOnly.FromDateTime(DateTime.Today);

            var myVac = RegVactination.GetLastVactination();
            var excpectedVac = new Vactination(doc, ani, date);

            Assert.AreEqual(excpectedVac, myVac);
        }

        [Test]
        public void GetReportByVactinations()
        {
            // Заполняем реестры
            InitializeComponent();

            // Имитируем полученные данные от пользователя
            var dateStart = DateOnly.FromDateTime(DateTime.Parse("04.07.2023"));
            var dateEnd = DateOnly.FromDateTime(DateTime.Today);
            var vetName = "Улыбка";

            // Создадим вакцинации для ветклиники 1
            Reg.AddVactination(101, "Ширгазина Аида Владиславовна", "Улыбка");
            Reg.AddVactination(110, "Ширгазина Аида Владиславовна", "Улыбка");
            Reg.AddVactination(1110, "Ширгазина Аида Владиславовна", "Улыбка");

            // Создадим вакцинации для ветклиники 2
            Reg.AddVactination(101, "Рудин Валентин Константинович", "Грустинка");
            Reg.AddVactination(110, "Рудин Валентин Константинович", "Грустинка");

            // Используем наш метод
            var report = Reg.GetReportByVactinations(dateStart, dateEnd, vetName);
            
            Assert.AreEqual(3, report);
        }

        [Test]
        public void GetPriceReportByContract()
        {
            // Заполняем реестры
            InitializeComponent();

            // Имитируем полученные данные от пользователя
            var conNumber = 1;
            var vetName = "Улыбка";

            // Заключим контракт
            var orgName = "Муниципалитет г. Тюмень";
            var supervisorName = "Васильев Алексей Викторович";
            var vetclinicName = "Улыбка";
            var kuratorName = "Веселов Михаил Константинович";
            var endDate = DateOnly.FromDateTime(DateTime.Parse("27.07.2023"));
            var vacPrice = 1000;

            Reg.CreateContract(orgName, supervisorName, vetclinicName, kuratorName, endDate, vacPrice);

            // Создадим вакцинации
            Reg.AddVactination(101, "Ширгазина Аида Владиславовна", "Улыбка");
            Reg.AddVactination(110, "Ширгазина Аида Владиславовна", "Улыбка");
            Reg.AddVactination(1110, "Ширгазина Аида Владиславовна", "Улыбка");

            // Используем наш метод
            var report = Reg.GetPriceReportByContractNumber(conNumber, vetName);

            Assert.AreEqual(3000, report);
        }
    }
}
