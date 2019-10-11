using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_WPF
{
    public delegate void ShowDelegate();

    abstract class Car
    {
        public string carName;
        public string MoveCar { get; set; }
        public int Speed { get; set; }
        public string Win { get; set; }
        public double Distance { get; set; }
        public Car(string c)
        {
            carName = c;
        }
        public abstract bool Move(int t);
        public abstract void Show();
        public override string ToString()
        {
            return $" {carName}";
        }
    }
}
