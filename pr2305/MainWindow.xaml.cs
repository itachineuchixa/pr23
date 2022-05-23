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
using System.IO;
using pr2305.Classes;

namespace pr2305
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int count = System.IO.File.ReadAllLines(@"Input.txt").Length;
            StreamReader sr = new StreamReader(@"Input.txt");
            List<Workers> worker = new List<Workers>();
            for (int i = 0; i < count; i++)
            {
                string input = sr.ReadLine();
                Workers worker1 = new Workers(input);
                ConnectHelper.worker.Add(worker1);
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.worker.ToList();
            DtgListPreparate.SelectedIndex = -1;

        }
        /// <summary>
        /// сортировка по алфавиту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.worker.OrderBy(x => x.name).ToList();
        }
        /// <summary>
        /// сортировка в обратном порядке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.worker.OrderByDescending(x => x.name).ToList();
        }
        /// <summary>
        /// поиск по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.worker.Where(x =>
                x.name.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        /// <summary>
        /// фильтр по количеству
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPreparate windowAdd = new WindowAddPreparate();
            windowAdd.ShowDialog();
        }



        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = null;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPreparate windowAdd = new WindowAddPreparate();
            windowAdd.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                int ind = DtgListPreparate.SelectedIndex;
                ConnectHelper.worker.RemoveAt(ind);
                DtgListPreparate.ItemsSource = ConnectHelper.worker.ToList();
            }

        }

    }
}
