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


    public partial class LecturerPage : Page
    {

        LecturerDB db = new LecturerDB();
        Lecturer lecturer = new Lecturer();// "עצם "בטיפול      
        LecturerList lecturerList = new LecturerList();
        private Mode mode;
        public LecturerPage()

        {
            InitializeComponent();
            this.DataContext = db;
            RefreshUserList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigating += NavigationService_Navigating;
        }


        private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                this.lecturer = ShareData.Data as Lecturer; ;
                if (mode == Mode.Insert)  //insert Mode
                {
                    db.CreateInsertSql(lecturer);
                }
                if (mode == Mode.Update)
                {
                    db.CreateUpdateSql(lecturer);
                }
                RefreshUserList();

                mode = Mode.None;
            }
        }

        private void Lecturer_List_Click(object sender, RoutedEventArgs e)
        {
            LecturerDB db = new LecturerDB();
            LecturerList list = db.SelectAll();

            this.lstViewLecturer.ItemsSource = list;
        }
        private void LecturerById_Click(object sender, RoutedEventArgs e)
        {
            LecturerDB db = new LecturerDB();
            this.DataContext = db;
            int Id = int.Parse(LecturertId.Text);
            LecturerList list = db.SelectByID(Id);
            this.lstViewLecturer.ItemsSource = list;
        }

        private void LecturerByName_Click(object sender, RoutedEventArgs e)
        {
            LecturerDB db = new LecturerDB();
            string firstName = LecturerFName.Text;
            string lastName = LecturerLName.Text;


            LecturerList list = db.SelectByName(firstName, lastName);
            this.DataContext = db;
            this.lstViewLecturer.ItemsSource = list;
        }



        private void Button_Click_FirstName(object sender, RoutedEventArgs e)
        {
            LecturerList list = db.SelectByFirstName();
            this.lstViewLecturer.ItemsSource = list;
        }

       

        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {
            mode = Mode.Update;
            ShareData.Data = new BaseEntity() { Id = 2 };
            Lecturer lecturer = this.lstViewLecturer.SelectedItem as Lecturer;
            lecturerList.Add(lecturer);
            // בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new InsertPersonPage(lecturer));  // שלח את המשתמש החדש כפרמטר לבנאי של    
        }

        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {
            Lecturer lecturer = this.lstViewLecturer.SelectedItem as Lecturer;
            db.CreateDeletetSql(lecturer); 

            RefreshUserList();

        }
        private void Add_Lecturer_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Insert;
            ShareData.Data = new BaseEntity() { Id = 2 };

            // בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new InsertPersonPage(lecturer));  // שלח את המשתמש החדש כפרמטר לבנאי של 

        }



        private void RefreshUserList()
        {
            LecturerDB db = new LecturerDB();
            LecturerList list = db.SelectAll();
            this.lstViewLecturer.ItemsSource = list;
        }

       
    }
}

