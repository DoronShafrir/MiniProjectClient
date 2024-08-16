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
    public enum Mode { None, Update, Insert };

    /// <summary>
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        StudentDB db = new StudentDB();
        Student student = new Student();       // "עצם "בטיפול
        StudentList studentList = new StudentList();
        private Mode mode;
        

        public StudentPage()
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
                this.student = ShareData.Data as Student; ;
                if (mode == Mode.Insert)  //insert Mode
                {                
                    db.CreateInsertSql(student);
                }
                if (mode == Mode.Update)
                {
                    db.CreateUpdateSql(student);
                }
                RefreshUserList();

                mode = Mode.None;
            }
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
            StudentList list = db.SelectByFirstName();            
            this.lstViewStudent.ItemsSource = list;
        }

        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {
            mode = Mode.Update;
            ShareData.Data = new BaseEntity() { Id = 1 };
            Student student = this.lstViewStudent.SelectedItem as Student;
            studentList.Add(student);
            // בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new InsertPersonPage(student));  // שלח את המשתמש החדש כפרמטר לבנאי של    
        }

        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {
            Student student = this.lstViewStudent.SelectedItem as Student;
            db.CreateDeletetSql(student);

            RefreshUserList();

        }

        private void Add_Student_Click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Insert;
            ShareData.Data = new BaseEntity() { Id = 1 };
            
            // בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new InsertPersonPage(student));  // שלח את המשתמש החדש כפרמטר לבנאי של 
        }



        private void RefreshUserList()
        {
            StudentDB db = new StudentDB();
            StudentList list = db.SelectAll();
            this.lstViewStudent.ItemsSource = list;
        }
    }
}
