using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairLibrary
{
     
    public class Device
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public readonly string SerialNumber;

        public RepairType Repair;
        public string FaultDescription { get; set; }
        public decimal RepairCost { get; set; }
        public string TechnicianFullName { get; set; }
        
        public Device(string name, string manufacturer, string serialNumber, RepairType repairType)
            {
                Name = name;
                Manufacturer = manufacturer;
                if (string.IsNullOrWhiteSpace(serialNumber))
                    throw new ArgumentException("Серийный номер не может быть пустым");
                SerialNumber = serialNumber;
                Repair = repairType;
            }

            public virtual string[] GetInfo()
            {
                var info = new string[2];
                info[0] = $"{Name} ({Manufacturer})";
                string repairTypeStr = Repair == RepairType.Warranty ? "гарантийный" : "оплачиваемый";
                info[1] = $"Серийный номер: {SerialNumber}. Тип ремонта: {repairTypeStr}. " +
                          $"Неисправность: {FaultDescription}. Стоимость: {RepairCost:C}. " +
                          $"Мастер: {TechnicianFullName}.";
                return info;
            }
        }
        public class TelevisionDevice : Device
        {
            public double ScreenSize { get; set; }
            public string MatrixType { get; set; }
            public string BacklightType { get; set; }

            public TelevisionDevice(string name, string manufacturer, string serialNumber, RepairType repairType)
                : base(name, manufacturer, serialNumber, repairType) { }

            public override string[] GetInfo()
            {
                var baseInfo = base.GetInfo();
                var info = new string[baseInfo.Length + 1];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Телевизор: Диагональ {ScreenSize}\". Матрица: {MatrixType}. Подсветка: {BacklightType}.";
                return info;
            }
        }
  
    
        public class RefrigeratorDevice : Device
        {
            public int ChamberCount { get; set; }
            public int Height { get; set; } 
            public int Width { get; set; }  
            public int Depth { get; set; }  

            public RefrigeratorDevice(string name, string manufacturer, string serialNumber, RepairType repairType)
                : base(name, manufacturer, serialNumber, repairType) { }

            public override string[] GetInfo()
            {
                var baseInfo = base.GetInfo();
                var info = new string[baseInfo.Length + 1];
                info[0] = baseInfo[0];
                info[1] = baseInfo[1];
                info[2] = $"Холодильник: {ChamberCount} камер. Размеры: {Height}x{Width}x{Depth} см.";
                return info;
            }
        }
    }



