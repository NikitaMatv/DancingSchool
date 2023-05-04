using DancingSchool.Components;
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

namespace DancingSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для TrainerListPages.xaml
    /// </summary>
    public partial class TrainerListPages : Page
    {
        public TrainerListPages()
        {
            InitializeComponent();
            TrainerList.ItemsSource = App.Db.Trainer.Where(x => x.IsDell != 1).ToList();
        }

        private void BtListStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentListPages());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var trainer = (sender as Button).DataContext as Trainer;
            trainer.IsDell = 1;
            App.Db.SaveChanges();
            TrainerList.ItemsSource = App.Db.Trainer.Where(x => x.IsDell != 1).ToList();
        }
    }
}
