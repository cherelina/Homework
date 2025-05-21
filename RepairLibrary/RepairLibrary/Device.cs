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

            public string[] GetInfo()
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
    }


