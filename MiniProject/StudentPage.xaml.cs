using Model;
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
using ViewModel;

namespace MiniProject
{
    /// <summary>
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        StudentDB db = new StudentDB();
        public StudentPage()
        {
            InitializeComponent();
            
            this.DataContext = db;
        }
        private void Button_Click(object sender, RoutedEventArgs e)

        {
            StudentDB db = new StudentDB();
            StudentList list = db.SelectAll();

            this.lstViewStudent.ItemsSource = list;

        }

        private void StudentById_Click(object sender, RoutedEventArgs e)
        {
            StudentDB db = new StudentDB();
            this.DataContext = db;
            int Id = int.Parse(StudentId.Text);
            StudentList list = db.SelectByID(Id);
            this.lstViewStudent.ItemsSource = list;
        }

        private void StudentByIName_Click(object sender, RoutedEventArgs e)
        {
            StudentDB db = new StudentDB();
            string firstName = StudentFName.Text;
            string lastName = StudentLName.Text;

            StudentList list = db.SelectByName(firstName, lastName);
            this.DataContext = db;
            this.lstViewStudent.ItemsSource = list;
        }

        

        private void Button_Click_FirstName(object sender, RoutedEventArgs e)
        {
            //StudentDB db = new StudentDB();
            //this.DataContext = db;
            //db.FirstName = TextBoxByName.Text;
            StudentList list = db.SelectByFirstName();
            //this.DataContext = db;
            this.lstViewStudent.ItemsSource = list;
        }

        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {

        }
    }
}
