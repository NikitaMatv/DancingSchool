using DancingSchool.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditStudentPages.xaml
    /// </summary>
    public partial class EditStudentPages : Page
    {
        Student contextstudent;
        public EditStudentPages(Student student)
        {
            InitializeComponent();
            contextstudent = student;
    
            DataContext = contextstudent;
            CbGroup.SelectedIndex = (int)contextstudent.GroupId - 1;

            CbGroup.ItemsSource = App.Db.Group.ToList();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9()-]") == false)
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[А-я]") == false)
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9@.A-z]") == false)
            {
                e.Handled = true;
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {

            string eror = "";
            if(TbEmail.Text.Length < 10)
            {
                eror += "Заполнете коректынй Email \n";
            }
            if (TbName.Text.Length < 3)
            {
                eror += "Заполнете коректыное Имя \n";
            }
            if (TbPhoneNumber.Text.Length < 12)
            {
                eror += "Заполнете коректынй Телефон \n";
            }
            if (TbSurname.Text.Length < 5)
            {
                eror += "Заполнете коректыную Фамилию \n";
            }         
            if (eror.Length == 0)
            {
                contextstudent.GroupId = CbGroup.SelectedIndex + 1;
                App.Db.SaveChanges();
                NavigationService.Navigate(new StudentListPages());
            }
            else
            {
                MessageBox.Show($"{eror}");
                return;
            }
        }

        private void BtSaveOnDisc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
