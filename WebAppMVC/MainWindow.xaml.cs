using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
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

namespace WebAppMVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int FibonaciProcessing(int first, int second)
        {
            return (first + second);
        }

        private void Foo()
        {
            int firstNumber = 0;
            int secondNumber = 1;
            int result = 0;

            result = FibonaciProcessing(firstNumber, secondNumber);
            firstNumber = secondNumber;
            secondNumber = result;
            tbxNumbers.Text = tbxNumbers.Text + $"{result}\n";
            Thread.Sleep(500);

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                int firstNumber = 0;
            int secondNumber = 1;
            int result = 0;
            tbxNumbers.Text = "";

            var newThread = new Thread(() =>
            {
            try
            {
                for (int i = 0; i < 10; i++)
                    {
                        result = FibonaciProcessing(firstNumber, secondNumber);
                        firstNumber = secondNumber;
                        secondNumber = result;
                        tbxNumbers.Dispatcher.BeginInvoke(() =>
                        {
                            tbxNumbers.Text = tbxNumbers.Text + $"{result}\n";
                        });
                        int sleep = 0;
                        slSleep.Dispatcher.Invoke(() => sleep = (int)slSleep.Value * 1000);

                        Thread.Sleep(sleep);
                    }
                }
                catch (ThreadInterruptedException ex)
                {
                    tbxNumbers.Text += "Брошено исключение: " + ex.Message;
                }
                catch (Exception ex)
                {
                    tbxNumbers.Text += "Брошено исключение: " + ex.Message;
                }
            });

                newThread.Start();

                newThread.Interrupt();
            //}
            //catch (Exception ex)
            //{
            //    tbxNumbers.Text += "Брошено";
            //}
        }


    }
}

