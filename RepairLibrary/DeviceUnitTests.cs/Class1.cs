using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RepairLibrary;

namespace DeviceUnitTests
{
    public class ConstructorTest
    {
        [TestFixture]
        public class DeviceUnitTests
        {
            [Test]
            public void ConstructorTest()
            {
                var device = CreateTestDevice();
                Assert.That(device.Name, Is.EqualTo("Washing Machine"));
                Assert.That(device.Manufacturer, Is.EqualTo("LG"));
                Assert.That(device.SerialNumber, Is.EqualTo("LG123456789"));
                Assert.That(device.Repair, Is.EqualTo(RepairType.Warranty));
            }

            [Test]
            public void GetInfoTest()
            {
                var device = CreateTestDevice();
                var info = device.GetInfo();
                Assert.That(info.Length, Is.EqualTo(2));
                Assert.That(info[0], Is.EqualTo("Washing Machine (LG)"));
                Assert.That(info[1], Is.EqualTo(
                    $"Серийный номер: LG123456789. Тип ремонта: гарантийный. " +
                    $"Неисправность: Не включается. Стоимость: {device.RepairCost:C}. " +
                    $"Мастер: Иванов Иван Иванович."));
            }

            private Device CreateTestDevice()
            {
                var device = new Device("Washing Machine", "LG", "LG123456789", RepairType.Warranty)
                {
                    FaultDescription = "Не включается", 
                    RepairCost = 0.00m,
                    TechnicianFullName = "Иванов Иван Иванович"
                };
                return device; 

            }
        }
    }
    public class ConstructorTest1
    {
        [TestFixture]
        public class TelevisionDeviceTests
        {
            [Test]
            public void GetInfo_Television_ReturnsFullInfo()
            {
                var tv = new TelevisionDevice("Smart TV", "Samsung", "TV2024X123", RepairType.Paid)
                {
                    ScreenSize = 55,
                    MatrixType = "OLED",
                    BacklightType = "Edge LED",
                    FaultDescription = "Нет изображения",
                    RepairCost = 7500.00m,
                    TechnicianFullName = "Сидоров Алексей Петрович"
                };

                var info = tv.GetInfo();

                Assert.That(info.Length, Is.EqualTo(3));
                Assert.That(info[0], Is.EqualTo("Smart TV (Samsung)"));
                Assert.That(info[1], Does.Contain("Серийный номер: TV2024X123"));
                Assert.That(info[2], Is.EqualTo("Телевизор: Диагональ 55\". Матрица: OLED. Подсветка: Edge LED."));
            }
        }
    }
    [TestFixture]
    public class RefrigeratorDeviceTests
    {
        [Test]
        public void GetInfo_Refrigerator_ReturnsFullInfo()
        {
            var fridge = new RefrigeratorDevice("Fridge X", "Bosch", "FR2023B567", RepairType.Warranty)
            {
                ChamberCount = 2,
                Height = 200,
                Width = 60,
                Depth = 65,
                FaultDescription = "Не морозит",
                RepairCost = 0.00m,
                TechnicianFullName = "Петров Николай Сергеевич"
            };

            var info = fridge.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Fridge X (Bosch)"));
            Assert.That(info[1], Does.Contain("Серийный номер: FR2023B567"));
            Assert.That(info[2], Is.EqualTo("Холодильник: 2 камер. Размеры: 200x60x65 см."));
        }
    }
    [TestFixture]
    public class DeviceTests
    {
        [Test]
        public void CompareTo_ByTechnicianSurname_ThenByName()
        {
            var d1 = new Device("Телевизор", "LG", "123", RepairType.Paid)
            {
                TechnicianFullName = "Иванов Алексей"
            };

            var d2 = new Device("Холодильник", "Samsung", "456", RepairType.Paid)
            {
                TechnicianFullName = "Петров Иван"
            };

            var d3 = new Device("Аудиосистема", "Sony", "789", RepairType.Paid)
            {
                TechnicianFullName = "Иванов Сергей"
            };

            Assert.That(d1.CompareTo(d2), Is.LessThan(0)); 
            Assert.That(d2.CompareTo(d1), Is.GreaterThan(0));
            Assert.That(d1.CompareTo(d3), Is.GreaterThan(0)); 
        }
    }
    [TestFixture]
    public class RepairServiceTests
    {
        RepairService service;
        Device[] devices;

        [SetUp]
        public void Setup()
        {
            service = new RepairService("РемБытТех", "ул. Техническая, д.5", "8 (800) 555-35-35");

            devices = new[]
            {
                new Device("Телевизор", "LG", "123", RepairType.Paid) { TechnicianFullName = "Иванов Алексей" },
                new Device("Холодильник", "Samsung", "456", RepairType.Warranty) { TechnicianFullName = "Петров Иван" },
                new Device("Стиральная машина", "Bosch", "789", RepairType.Paid) { TechnicianFullName = "Сидоров Павел" }
            };

            foreach (var d in devices)
                service.AddDevice(d);
        }

        [Test]
        public void AddDevice_DeviceAddedToService()
        {
            Assert.That(service.Count(), Is.EqualTo(3));
        }

        [Test]
        public void RemoveDevice_DeviceRemovedFromService()
        {
            service.RemoveDevice(devices[1]); 
            Assert.That(service.Count(), Is.EqualTo(2));
            Assert.That(service.Contains(devices[2]), Is.True);
        }

        [Test]
        public void IEnumerableImplementation_ForeachWorks()
        {
            int count = 0;
            foreach (var d in service)
            {
                Assert.That(d, Is.InstanceOf<Device>());
                count++;
            }
            Assert.That(count, Is.EqualTo(3));
        }
    }
}














