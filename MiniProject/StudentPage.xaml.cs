using MiniProject.ServiceReference2;
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


namespace MiniProject
{
    


    public partial class StudentPage : Page
    {
        //StudentDB db = new StudentDB();
        //Student student = new Student();       // "עצם "בטיפול
        //StudentList studentList = new StudentList();

        //public enum Mode { None, Update, Insert };
        //Mode mode = new Mode();

        public StudentPage()
        {
            InitializeComponent();
            
            //this.DataContext = db;
            //RefreshUserList();
            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            StudentList list = srv.GetStudentList();
              this.lstViewStudent.ItemsSource = list;

        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigating += NavigationService_Navigating;
        }


        private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                
                ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
                StudentList list = srv.GetStudentList();
                this.lstViewStudent.ItemsSource = list;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            //Show all Names
            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            StudentList list = srv.GetStudentList();
            this.lstViewStudent.ItemsSource = list;
        }

        private void StudentById_Click(object sender, RoutedEventArgs e)
        {         
            int Id = int.Parse(StudentId.Text);
            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            StudentList list = srv.GetStudentListById(Id);
            this.lstViewStudent.ItemsSource = list;
        }

        private void StudentByIName_Click(object sender, RoutedEventArgs e)
        {            
            string firstName = StudentFName.Text;
            string lastName = StudentLName.Text;

            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            StudentList list = srv.GetStudentListByName(firstName, lastName);
            this.lstViewStudent.ItemsSource = list;
        }



        private void Button_Click_FirstName(object sender, RoutedEventArgs e)
        {
            //StudentList list = db.SelectByFirstName();
            //this.lstViewStudent.ItemsSource = list;
        }

        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {           
            Student student = this.lstViewStudent.SelectedItem as Student;
            
            //// בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new InsertStudentPage(student.Id));  // שלח את המשתמש החדש כפרמטר לבנאי של    
        }

        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {
            Student student = this.lstViewStudent.SelectedItem as Student;
            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            int l = srv.GetDeleteStudent(student);

            StudentList list = srv.GetStudentList();

            this.lstViewStudent.ItemsSource = list;


        }

        private void Add_Student_Click(object sender, RoutedEventArgs e)
        {
           
            //ShareData.Data = new BaseEntity() { Id = 1 };

            // בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            int id = 0;
            nav.Navigate(new InsertStudentPage(id));  // פותח דף להכנסת נתוני המשתשמש
        }



       
    }
}
