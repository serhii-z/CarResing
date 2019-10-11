using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Gonki_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queue<int> qu = new Queue<int>();
        public delegate void Action();
        Thread thread;
        bool IsDriveCar = true;
        Game game = new Game();                     

        public MainWindow()
        {
            InitializeComponent();
            qu.Enqueue(2);
            qu.Enqueue(3);
            qu.Enqueue(4);
            Truck1.Visibility = Visibility.Hidden;
            Bus1.Visibility = Visibility.Hidden;
            PassCar1.Visibility = Visibility.Hidden;
            SportCar1.Visibility = Visibility.Hidden;
            DataContext = game;
        }
        private void CreateTruck_Click(object sender, RoutedEventArgs e)
        {           
            Truck1.Visibility = Visibility.Visible;
            game.CreateTrack();
        }
        private void CreateBus_Click(object sender, RoutedEventArgs e)
        {
            Bus1.Visibility = Visibility.Visible;
            game.CreateBus();
        }
        private void CreatePassCar_Click(object sender, RoutedEventArgs e)
        {
            PassCar1.Visibility = Visibility.Visible;
            game.CreatePassCar();
        }

        private void CreateSportCar_Click(object sender, RoutedEventArgs e)
        {
            SportCar1.Visibility = Visibility.Visible;
            game.CreateSportCar();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            game.StartGame();
            thread = new Thread(Method1);
            thread.Start();
            startButton.IsEnabled = false;
        }
        
            
        private void Method1()
        {
            while (IsDriveCar)
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    if (game.IsMoreDistanceTrack())
                    {
                        Truck1.Visibility = Visibility.Hidden;
                        Truck2.Visibility = Visibility.Hidden;
                        Truck3.Visibility = Visibility.Visible;
                    }
                    if (game.IsMoreDistanceBus())
                    {
                        Bus1.Visibility = Visibility.Hidden;
                        Bus2.Visibility = Visibility.Hidden;
                        Bus3.Visibility = Visibility.Visible;
                    }
                    if (game.IsMoreDistanceSportCar())
                    {
                        SportCar1.Visibility = Visibility.Hidden;
                        SportCar2.Visibility = Visibility.Hidden;
                        SportCar3.Visibility = Visibility.Visible;
                    }
                    if (game.IsMoreDistancePassCar())
                    {
                        PassCar1.Visibility = Visibility.Hidden;
                        PassCar2.Visibility = Visibility.Hidden;
                        PassCar3.Visibility = Visibility.Visible;
                    }
                    if (game.IsLessDistanceTrack())
                    {
                        Truck1.Visibility = Visibility.Visible;
                        Truck2.Visibility = Visibility.Hidden;
                        Truck3.Visibility = Visibility.Hidden;
                    }
                    if (game.IsLessDistanceBus())
                    {
                        Bus1.Visibility = Visibility.Visible;
                        Bus2.Visibility = Visibility.Hidden;
                        Bus3.Visibility = Visibility.Hidden;
                    }
                    if (game.IsLessDistanceSportCar())
                    {
                        SportCar1.Visibility = Visibility.Visible;
                        SportCar2.Visibility = Visibility.Hidden;
                        SportCar3.Visibility = Visibility.Hidden;
                    }
                    if (game.IsLessDistancePassCar())
                    {
                        PassCar1.Visibility = Visibility.Visible;
                        PassCar2.Visibility = Visibility.Hidden;
                        PassCar3.Visibility = Visibility.Hidden;
                    }
                       
                        int q = qu.Dequeue();
                    if (q == 2)
                    {
                        MethodA2();
                        MethodB2();
                        MethodC2();
                        MethodD2();
                        
                    }
                    else if (q == 3)
                    {
                        MethodA3();
                        MethodB3();
                        MethodC3();
                        MethodD3();
                        
                    }
                    else if (q == 4)
                    {
                        MethodA4();
                        MethodB4();
                        MethodC4();
                        MethodD4();
                       
                    }
                    qu.Enqueue(q);
                }));
                Thread.Sleep(150);
                IsDriveCar = game.VerifyFinish();
            }
            StopThread();
        }

        private void StopThread()
        {
            if(game.threadSportCar != null)
            {
                game.threadSportCar.Abort();
            }            
            if(game.threadPassCar != null)
            {
                game.threadPassCar.Abort();
            }
            if (game.threadTrack != null)
            {
                game.threadTrack.Abort();
            }
            if (game.threadBus != null)
            {
                game.threadBus.Abort();
            }                
        }

        private void MethodA2()
        {
            a1.Visibility = Visibility.Hidden;
            a2.Visibility = Visibility.Visible;
            a3.Visibility = Visibility.Hidden;
            a4.Visibility = Visibility.Hidden;
            a5.Visibility = Visibility.Visible;
            a6.Visibility = Visibility.Hidden;
            a7.Visibility = Visibility.Hidden;
            a8.Visibility = Visibility.Visible;
            a9.Visibility = Visibility.Hidden;
            a10.Visibility = Visibility.Hidden;
            a11.Visibility = Visibility.Visible;
            a12.Visibility = Visibility.Hidden;
            a13.Visibility = Visibility.Hidden;
            a14.Visibility = Visibility.Visible;
            a15.Visibility = Visibility.Hidden;
        }
        private void MethodA3()
        {
            a1.Visibility = Visibility.Hidden;
            a2.Visibility = Visibility.Hidden;
            a3.Visibility = Visibility.Visible;
            a4.Visibility = Visibility.Hidden;
            a5.Visibility = Visibility.Hidden;
            a6.Visibility = Visibility.Visible;
            a7.Visibility = Visibility.Hidden;
            a8.Visibility = Visibility.Hidden;
            a9.Visibility = Visibility.Visible;
            a10.Visibility = Visibility.Hidden;
            a11.Visibility = Visibility.Hidden;
            a12.Visibility = Visibility.Visible;
            a13.Visibility = Visibility.Hidden;
            a14.Visibility = Visibility.Hidden;
            a15.Visibility = Visibility.Visible;
        }
        private void MethodA4()
        {
            a1.Visibility = Visibility.Visible;
            a2.Visibility = Visibility.Hidden;
            a3.Visibility = Visibility.Hidden;
            a4.Visibility = Visibility.Visible;
            a5.Visibility = Visibility.Hidden;
            a6.Visibility = Visibility.Hidden;
            a7.Visibility = Visibility.Visible;
            a8.Visibility = Visibility.Hidden;
            a9.Visibility = Visibility.Hidden;
            a10.Visibility = Visibility.Visible;
            a11.Visibility = Visibility.Hidden;
            a12.Visibility = Visibility.Hidden;
            a13.Visibility = Visibility.Visible;
            a14.Visibility = Visibility.Hidden;
            a15.Visibility = Visibility.Hidden;
        }
        private void MethodB2()
        {
            b1.Visibility = Visibility.Hidden;
            b2.Visibility = Visibility.Visible;
            b3.Visibility = Visibility.Hidden;
            b4.Visibility = Visibility.Hidden;
            b5.Visibility = Visibility.Visible;
            b6.Visibility = Visibility.Hidden;
            b7.Visibility = Visibility.Hidden;
            b8.Visibility = Visibility.Visible;
            b9.Visibility = Visibility.Hidden;
            b10.Visibility = Visibility.Hidden;
            b11.Visibility = Visibility.Visible;
            b12.Visibility = Visibility.Hidden;
            b13.Visibility = Visibility.Hidden;
            b14.Visibility = Visibility.Visible;
            b15.Visibility = Visibility.Hidden;
        }
        private void MethodB3()
        {
            b1.Visibility = Visibility.Hidden;
            b2.Visibility = Visibility.Hidden;
            b3.Visibility = Visibility.Visible;
            b4.Visibility = Visibility.Hidden;
            b5.Visibility = Visibility.Hidden;
            b6.Visibility = Visibility.Visible;
            b7.Visibility = Visibility.Hidden;
            b8.Visibility = Visibility.Hidden;
            b9.Visibility = Visibility.Visible;
            b10.Visibility = Visibility.Hidden;
            b11.Visibility = Visibility.Hidden;
            b12.Visibility = Visibility.Visible;
            b13.Visibility = Visibility.Hidden;
            b14.Visibility = Visibility.Hidden;
            b15.Visibility = Visibility.Visible;
        }
        private void MethodB4()
        {
            b1.Visibility = Visibility.Visible;
            b2.Visibility = Visibility.Hidden;
            b3.Visibility = Visibility.Hidden;
            b4.Visibility = Visibility.Visible;
            b5.Visibility = Visibility.Hidden;
            b6.Visibility = Visibility.Hidden;
            b7.Visibility = Visibility.Visible;
            b8.Visibility = Visibility.Hidden;
            b9.Visibility = Visibility.Hidden;
            b10.Visibility = Visibility.Visible;
            b11.Visibility = Visibility.Hidden;
            b12.Visibility = Visibility.Hidden;
            b13.Visibility = Visibility.Visible;
            b14.Visibility = Visibility.Hidden;
            b15.Visibility = Visibility.Hidden;
        }

        private void MethodC2()
        {
            c1.Visibility = Visibility.Hidden;
            c2.Visibility = Visibility.Visible;
            c3.Visibility = Visibility.Hidden;
            c4.Visibility = Visibility.Hidden;
            c5.Visibility = Visibility.Visible;
            c6.Visibility = Visibility.Hidden;
            c7.Visibility = Visibility.Hidden;
            c8.Visibility = Visibility.Visible;
            c9.Visibility = Visibility.Hidden;
            c10.Visibility = Visibility.Hidden;
            c11.Visibility = Visibility.Visible;
            c12.Visibility = Visibility.Hidden;
            c13.Visibility = Visibility.Hidden;
            c14.Visibility = Visibility.Visible;
            c15.Visibility = Visibility.Hidden;
        }
        private void MethodC3()
        {
            c1.Visibility = Visibility.Hidden;
            c2.Visibility = Visibility.Hidden;
            c3.Visibility = Visibility.Visible;
            c4.Visibility = Visibility.Hidden;
            c5.Visibility = Visibility.Hidden;
            c6.Visibility = Visibility.Visible;
            c7.Visibility = Visibility.Hidden;
            c8.Visibility = Visibility.Hidden;
            c9.Visibility = Visibility.Visible;
            c10.Visibility = Visibility.Hidden;
            c11.Visibility = Visibility.Hidden;
            c12.Visibility = Visibility.Visible;
            c13.Visibility = Visibility.Hidden;
            c14.Visibility = Visibility.Hidden;
            c15.Visibility = Visibility.Visible;
        }
        private void MethodC4()
        {
            c1.Visibility = Visibility.Visible;
            c2.Visibility = Visibility.Hidden;
            c3.Visibility = Visibility.Hidden;
            c4.Visibility = Visibility.Visible;
            c5.Visibility = Visibility.Hidden;
            c6.Visibility = Visibility.Hidden;
            c7.Visibility = Visibility.Visible;
            c8.Visibility = Visibility.Hidden;
            c9.Visibility = Visibility.Hidden;
            c10.Visibility = Visibility.Visible;
            c11.Visibility = Visibility.Hidden;
            c12.Visibility = Visibility.Hidden;
            c13.Visibility = Visibility.Visible;
            c14.Visibility = Visibility.Hidden;
            c15.Visibility = Visibility.Hidden;
        }

        private void MethodD2()
        {
            d1.Visibility = Visibility.Hidden;
            d2.Visibility = Visibility.Visible;
            d3.Visibility = Visibility.Hidden;
            d4.Visibility = Visibility.Hidden;
            d5.Visibility = Visibility.Visible;
            d6.Visibility = Visibility.Hidden;
            d7.Visibility = Visibility.Hidden;
            d8.Visibility = Visibility.Visible;
            d9.Visibility = Visibility.Hidden;
            d10.Visibility = Visibility.Hidden;
            d11.Visibility = Visibility.Visible;
            d12.Visibility = Visibility.Hidden;
            d13.Visibility = Visibility.Hidden;
            d14.Visibility = Visibility.Visible;
            d15.Visibility = Visibility.Hidden;
        }
        private void MethodD3()
        {
            d1.Visibility = Visibility.Hidden;
            d2.Visibility = Visibility.Hidden;
            d3.Visibility = Visibility.Visible;
            d4.Visibility = Visibility.Hidden;
            d5.Visibility = Visibility.Hidden;
            d6.Visibility = Visibility.Visible;
            d7.Visibility = Visibility.Hidden;
            d8.Visibility = Visibility.Hidden;
            d9.Visibility = Visibility.Visible;
            d10.Visibility = Visibility.Hidden;
            d11.Visibility = Visibility.Hidden;
            d12.Visibility = Visibility.Visible;
            d13.Visibility = Visibility.Hidden;
            d14.Visibility = Visibility.Hidden;
            d15.Visibility = Visibility.Visible;
        }
        private void MethodD4()
        {
            d1.Visibility = Visibility.Visible;
            d1.Visibility = Visibility.Hidden;
            d2.Visibility = Visibility.Hidden;
            d2.Visibility = Visibility.Visible;
            d3.Visibility = Visibility.Hidden;
            d4.Visibility = Visibility.Visible;
            d5.Visibility = Visibility.Hidden;
            d6.Visibility = Visibility.Hidden;
            d7.Visibility = Visibility.Visible;
            d8.Visibility = Visibility.Hidden;
            d9.Visibility = Visibility.Hidden;
            d10.Visibility = Visibility.Visible;
            d11.Visibility = Visibility.Hidden;
            d12.Visibility = Visibility.Hidden;
            d13.Visibility = Visibility.Visible;
            d14.Visibility = Visibility.Hidden;
            d15.Visibility = Visibility.Hidden;
        }

       
    }
}
