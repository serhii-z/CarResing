using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_WPF
{
    class SportCar : Car
    {
        public SportCar(string c) : base(c) { }

        private event ShowDelegate finishEvent;
        private void Finish()
        {
            if (finishEvent != null)
            {
                finishEvent?.Invoke();
            }
        }
        private double Dist1min()
        {
            Random r = new Random();
            Speed = r.Next(20, 160);
            return Speed / 60;
        }
        public override bool Move(int t)
        {
            if ((int)Distance >= 100)
            {
                finishEvent += Show;
                Finish();
                return true;
            }
            else
            {
                Distance += Dist1min();
                MoveCar = (ToString() + $": \n{t} мин,  проехал {Distance} км, \nСкорость: {Speed} км/ч");
                return false;
            }
        }
        public override string ToString()
        {
            return $"Cпорткар: " + base.ToString();
        }
        public override void Show()
        {
            Win = $"ПОБЕДИЛ СПОРТИВНЫЙ АВТОМОБИЛЬ";
        }
    }
}
