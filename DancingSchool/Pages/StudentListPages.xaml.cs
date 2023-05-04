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
using DancingSchool.Pages;
namespace DancingSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentListPages.xaml
    /// </summary>
    public partial class StudentListPages : Page
    {
        public StudentListPages()
        {
            InitializeComponent();
            Update();
            CbType.SelectedIndex = 0;
          
    
            CbGroup.SelectedIndex = 0;
         
        }

        private void BtListTrainer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TrainerListPages());
        }

        private void CbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        public void Update()
        {
            IEnumerable<Student> students = App.Db.Student.ToList();
            if(CbType.SelectedIndex == 0)
            {
                students = students.Where(x=>x.IsDell != 1).ToList();
            }
            if (CbType.SelectedIndex == 1)
            {
                students = students.Where(x => x.IsDell == 1).ToList();
            }
            if (CbType.SelectedIndex == 2)
            {
                students = students.ToList();
            }
            if(CbGroup.SelectedIndex == 0)
            {
                students = students.OrderBy(x=>x.GroupId).ToList();
            }
            if (CbGroup.SelectedIndex == 1)
            {
                students = students.OrderByDescending(x => x.GroupId).ToList();
            }
            StudentList.ItemsSource = students.ToList();
        }

        private void CbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void EdintStudent_Click(object sender, RoutedEventArgs e)
        {
            var student = (sender as Button).DataContext as Student;
            NavigationService.Navigate(new EditStudentPages(student));
        }

      
    }
}
