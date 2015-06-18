using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Computers
{
    public class Battery
    {
        private string model;
        private string manufacturer;
        private double batteryLife;

        public Battery(double batteryLife, string model = null, string manufacturer = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.BatteryLife = batteryLife;
        }

        public string Model
        {
            get { return model; }
            set
            {
                Validate.IsEmpty(value, "Model");
                model = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                Validate.IsEmpty(value, "Manufacturer");
                manufacturer = value;
            }
        }

        public double BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                Validate.IsNegative(value, "Battery life");
                this.batteryLife = value;
            }
        }

        public override string ToString()
        {
            string str = String.Format(
               "battery model: {0}\n" +
               "battery manufacturer: {1}\n" +
               "battery life: {2}\n",
               this.Model ?? "n/a", this.Manufacturer ?? "n/a", this.BatteryLife);

            return str;
        }
    }
}
