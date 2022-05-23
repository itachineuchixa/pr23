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
using System.Windows.Shapes;
using System.IO;
using pr2305.Classes;

namespace pr2305
{
    /// <summary>
    /// Логика взаимодействия для WindowAddPreparate.xaml
    /// </summary>
    public partial class WindowAddPreparate : Window
    {
        public WindowAddPreparate()
        {
            InitializeComponent();
        }
        private void BtnAddPreparate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(
                    birthname.Text) < 0)
                {
                    MessageBox.Show("Количество не может быть отрицательным!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    birthname.Clear();
                    birthname.Focus();
                    return;
                }
                if (int.Parse(payname.Text) < 0)
                {
                    MessageBox.Show("Количество не может быть отрицательным!", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                    payname.Clear();
                    payname.Focus();
                    return;
                }
                string res = string.Format("{0,30} {1,5} {2:8}", FIONAME.Text, birthname.Text, payname.Text);
                Workers worker = new Workers(res);
                ConnectHelper.worker.Add(worker);
                StreamWriter sr = new StreamWriter(@"Input.txt", true);
                sr.WriteLine(string.Format("{0,30} {1,5} {2:8}", FIONAME.Text, birthname.Text, payname.Text));
                sr.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
