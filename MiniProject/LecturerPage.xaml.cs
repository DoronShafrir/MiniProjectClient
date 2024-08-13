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
    /// Interaction logic for LecturerPage.xaml
    /// </summary>
    public partial class LecturerPage : Page
    {
        public LecturerPage()
        {
            InitializeComponent();
            LecturerDB db = new LecturerDB();
            
        }

        private void Lecturer_List_Click(object sender, RoutedEventArgs e)
        {
            LecturerDB db = new LecturerDB();
            LecturerList list = db.SelectAll();

            this.lstViewLecturer.ItemsSource = list;
        }

        private void LectureById_Click(object sender, RoutedEventArgs e)
        {
            LecturerDB db = new LecturerDB();
            this.DataContext = db;
            int Id = int.Parse(LecturerId.Text);
            LecturerList list = db.SelectByID(Id);
            this.lstViewLecturer.ItemsSource = list; 
        }

        private void LectureByIName_Click(object sender, RoutedEventArgs e)
        {
            LecturerDB db = new LecturerDB();
            string firstName = LecturerFName.Text;
            string lastName = LecturerLName.Text;


            LecturerList list = db.SelectByName(firstName, lastName);
            this.DataContext = db;
            this.lstViewLecturer.ItemsSource = list;
        }
    }
}
