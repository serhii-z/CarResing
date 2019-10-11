using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gonki_WPF
{
    public class Game : INotifyPropertyChanged
    {
        SportCar sCar;
        PassCar pCar;
        Truck tCar;
        Bus bCar;
        bool IsCreateSportCar = false;
        bool IsCreatePassCar = false;
        bool IsCreateTrack = false;
        bool IsCreateBus = false;
        public Thread threadSportCar;
        public Thread threadPassCar;
        public Thread threadTrack;
        public Thread threadBus;

        private string _infoTrack;
        public string InfoTrack
        {
            get { return _infoTrack; }
            set
            {
                _infoTrack = value;
                OnPropertyChanged("InfoTrack");
            }
        }

        private string _infoSportCar;
        public string InfoSportCar
        {
            get { return _infoSportCar; }
            set
            {
                _infoSportCar = value;
                OnPropertyChanged("InfoSportCar");
            }
        }

        private string _infoPassCar;
        public string InfoPassCar
        {
            get { return _infoPassCar; }
            set
            {
                _infoPassCar = value;
                OnPropertyChanged("InfoPassCar");
            }
        }

        private string _infoBus;
        public string InfoBus
        {
            get { return _infoBus; }
            set
            {
                _infoBus = value;
                OnPropertyChanged("InfoBus");
            }
        }

        private string _finish;
        public string Finish
        {
            get { return _finish; }
            set
            {
                _finish = value;
                OnPropertyChanged("Finish");
            }
        }

        public bool VerifyFinish()
        {
            return Finish == null;
        }


        public bool IsMoreDistanceTrack()
        {
            try
            {
                return tCar.Distance > bCar.Distance && tCar.Distance > sCar.Distance && tCar.Distance > pCar.Distance;
            }
            catch { return false; }
            
        }

        public bool IsMoreDistanceBus()
        {
            try
            {
                return bCar.Distance > tCar.Distance && bCar.Distance > sCar.Distance && bCar.Distance > pCar.Distance;
            }
            catch { return false; }       
        }

        public bool IsMoreDistanceSportCar()
        {
            try
            {
                return sCar.Distance > tCar.Distance && sCar.Distance > bCar.Distance && sCar.Distance > pCar.Distance;
            }
            catch { return false; }        
        }

        public bool IsMoreDistancePassCar()
        {
            try
            {
                return pCar.Distance > tCar.Distance && pCar.Distance > bCar.Distance && pCar.Distance > sCar.Distance;
            }
            catch { return false; }           
        }

        public bool IsLessDistanceTrack()
        {
            try
            {
                return tCar.Distance < bCar.Distance && tCar.Distance < sCar.Distance && tCar.Distance < pCar.Distance;
            }
            catch { return false; }          
        }

        public bool IsLessDistanceBus()
        {
            try
            {
                return bCar.Distance < tCar.Distance && bCar.Distance < sCar.Distance && bCar.Distance < pCar.Distance;
            }
            catch { return false; }         
        }

        public bool IsLessDistanceSportCar()
        {
            try
            {
                return sCar.Distance < tCar.Distance && sCar.Distance < bCar.Distance && sCar.Distance < pCar.Distance;
            }
            catch { return false; }          
        }

        public bool IsLessDistancePassCar()
        {
            try
            {
                return pCar.Distance < tCar.Distance && pCar.Distance < bCar.Distance && pCar.Distance < sCar.Distance;
            }
            catch { return false; }            
        }

        public void CreateSportCar()
        {
            sCar = new SportCar("Porshe 911");
            IsCreateSportCar = true;
        }

        public void CreatePassCar()
        {
            pCar = new PassCar("Ford Focus");
            IsCreatePassCar = true;
        }

        public void CreateTrack()
        {
            tCar = new Truck("DAF CF- 85");
            IsCreateTrack = true;
        }

        public void CreateBus()
        {
            bCar = new Bus("Temsa MD 7");
            IsCreateBus = true;
        }

        public void StartGame()
        {
            if (IsCreateSportCar)
            {
                threadSportCar = new Thread(SportCarMove);
                threadSportCar.Start();
            }
            if (IsCreatePassCar)
            {
                threadPassCar = new Thread(PassCarMove);
                threadPassCar.Start();
            }
            if (IsCreateTrack)
            {
                threadTrack = new Thread(TrackMove);
                threadTrack.Start();
            }
            if (IsCreateBus)
            {
                threadBus = new Thread(BusMove);
                threadBus.Start();
            }
        }

        private void SportCarMove()
        {
            int i = 1;
            while (sCar.Move(i) == false)
            {
                Thread.Sleep(1000);
                InfoSportCar = sCar.MoveCar;
                i++;
            }
            Finish = sCar.Win;
        }

        private void PassCarMove()
        {
            int i = 1;
            while (pCar.Move(i) == false)
            {
                Thread.Sleep(1000);
                InfoPassCar = pCar.MoveCar;
                i++;
            }
            Finish = pCar.Win;
        }

        private void TrackMove()
        {
            int i = 1;
            while (tCar.Move(i) == false)
            {
                Thread.Sleep(1000);
                InfoTrack = tCar.MoveCar;
                i++;
            }
            Finish = tCar.Win;
        }

        private void BusMove()
        {
            int i = 1;
            while (bCar.Move(i) == false)
            {
                Thread.Sleep(1000);
                InfoBus = bCar.MoveCar;
                i++;
            }
            Finish = bCar.Win;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}