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
}

            
        
    

