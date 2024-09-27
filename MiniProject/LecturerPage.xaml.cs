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
    //public enum Mode { None, Update, Insert };

    public partial class LecturerPage : Page
    {

        //LecturerDB db = new LecturerDB();
        //Lecturer lecturer = new Lecturer();// "עצם "בטיפול      
        //LecturerList lecturerList = new LecturerList();
        //private Mode mode;
        public LecturerPage()

        {
            InitializeComponent();
            //this.DataContext = db;
            //RefreshUserList();

            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            LecturerList list = srv.GetLecturertList();
            this.lstViewLecturer.ItemsSource = list;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigating += NavigationService_Navigating;
        }


        private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            //    if (e.NavigationMode == NavigationMode.Back)
            //    {
            //        this.lecturer = ShareData.Data as Lecturer; ;
            //        if (mode == Mode.Insert)  //insert Mode
            //        {
            //            db.CreateInsertSql(lecturer);
            //        }
            //        if (mode == Mode.Update)
            //        {
            //            db.CreateUpdateSql(lecturer);
            //        }
            //        RefreshUserList();

            //        mode = Mode.None;
            //    }
            if (e.NavigationMode == NavigationMode.Back)
            {

                ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
                LecturerList list = srv.GetLecturertList();
                this.lstViewLecturer.ItemsSource = list;

            }
        }

        private void Lecturer_List_Click(object sender, RoutedEventArgs e)
        {
            //Show all Names
            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            LecturerList list = srv.GetLecturertList();
            this.lstViewLecturer.ItemsSource = list;
        }
        private void LecturerById_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(LecturertId.Text);            
            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            LecturerList list = srv.GetLecturertListById(Id);
            this.lstViewLecturer.ItemsSource = list;
        }

        private void LecturerByName_Click(object sender, RoutedEventArgs e)
        {
  
            string firstName = LecturerFName.Text;
            string lastName = LecturerLName.Text;
            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            LecturerList list = srv.GetLecturertListByName(firstName, lastName);
            this.lstViewLecturer.ItemsSource = list;
        }

        private void Button_Click_FirstName(object sender, RoutedEventArgs e)
        {
            //LecturerList list = db.SelectByFirstName();
            //this.lstViewLecturer.ItemsSource = list;
        }

       

        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {

            Lecturer lecturer = this.lstViewLecturer.SelectedItem as Lecturer;

            //// בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new InsertLecturerPage(lecturer.Id));  // שלח את המשתמש החדש כפרמטר לבנאי של    
        }

        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {
            Lecturer lecturer = this.lstViewLecturer.SelectedItem as Lecturer;
            ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
            int l = srv.GetDeleteLecturer(lecturer);

            LecturerList list = srv.GetLecturertList();

            this.lstViewLecturer.ItemsSource = list;           
        }

        private void Add_Lecturer_Click(object sender, RoutedEventArgs e)
        {

            //// בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new InsertLecturerPage(0));  // שלח את המשתמש החדש כפרמטר לבנאי של 

        }
       
    }
}

