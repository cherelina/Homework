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
}












