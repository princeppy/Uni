using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Computers
{
    public class Laptop
    {
        private string model;
        private string manufacturer;
        private string cpu;
        private string ram;
        private string gpu;
        private string hdd;
        private string screenSize;
        private Battery batteryType;
        private decimal price;


        public Laptop(string model, string manufacturer, string screenSize, decimal price, string cpu = null, string gpu = null, string hdd = null, string ram = null, Battery battery = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.ScreenSize = screenSize;
            this.Price = price;
            this.Cpu = cpu;
            this.Gpu = gpu;
            this.Hdd = hdd;
            this.Ram = ram;
            this.BatteryType = battery;
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                Validate.IsEmpty(value, "Laptop model");
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                Validate.IsEmpty(value, "Laptop manufacturer");

                this.manufacturer = value;
            }
        }

        public string Cpu
        {
            get { return this.cpu; }
            set
            {
                Validate.IsEmpty(value, "Laptop cpu model");

                this.cpu = value;
            }
        }

        public string Ram
        {
            get { return this.ram; }
            set
            {
                Validate.IsEmpty(value, "Laptop ram");
                this.ram = value;
            }
        }

        public string Gpu
        {
            get { return this.gpu; }
            set
            {
                Validate.IsEmpty(value, "Laptop GPU");
                this.gpu = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                Validate.IsEmpty(value, "Laptop HDD");
                this.hdd = value;
            }
        }

        public string ScreenSize
        {
            get { return this.screenSize; }
            set
            {
                Validate.IsEmpty(value, "Laptop screen");
                this.screenSize = value;
            }
        }

        public Battery BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                Validate.IsNegative(value, "Price");
                this.price = value;
            }
        }

        public override string ToString()
        {
            string str = String.Format(
                "model: {0}\n" +
                "manufacturer: {1}\n" +
                "processor: {2}\n" +
                "RAM: {3}\n" +
                "graphics card: {4}\n" +
                "HDD: {5}\n" +
                "screen: {6}\n" +
                "{7}"+
                "price: {8}",
                this.Model ?? "n/a", this.Manufacturer ?? "n/a", this.Cpu ?? "n/a", this.Ram ?? "n/a", this.Gpu ?? "n/a", this.Hdd ?? "n/a", this.ScreenSize ?? "n/a",
                this.BatteryType, this.Price);
            return str;
        }
    }
}
