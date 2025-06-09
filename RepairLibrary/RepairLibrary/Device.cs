using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairLibrary
{

    public class Device : IComparable<Device>
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

        public int CompareTo(Device other)
        {
            var thisSurname = TechnicianFullName?.Split(' ').FirstOrDefault() ?? "";
            var otherSurname = other.TechnicianFullName?.Split(' ').FirstOrDefault() ?? "";

            int surnameCompare = string.Compare(thisSurname, otherSurname, StringComparison.OrdinalIgnoreCase);
            if (surnameCompare != 0)
                return surnameCompare;

            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
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
    public class RepairService : IEnumerable<Device>
    {
        public string ServiceName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        private List<Device> devices;

        public RepairService(string serviceName, string address, string phone)
        {
            ServiceName = serviceName;
            Address = address;
            Phone = phone;
            devices = new List<Device>();
        }

        public void AddDevice(Device device)
        {
            if (device != null && !devices.Contains(device))
                devices.Add(device);
        }

        public void RemoveDevice(Device device)
        {
            if (device != null)
                devices.Remove(device);
        }

        public bool Contains(Device device)
        {
            return devices.Contains(device);
        }

        public IEnumerator<Device> GetEnumerator() => devices.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}





