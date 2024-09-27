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
    /// <summary>
    /// Interaction logic for AddStudentPage.xaml
    /// </summary>
    public partial class InsertStudentPage : Page
    {

        ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
        Student student = new Student();

        public InsertStudentPage()
        {
            InitializeComponent();
            this.DataContext = student;

            CityList cityLst = new CityList();
            cityLst = srv.GetCityList();  // ממלא את רשימת הערים בדף
            this.CityCbox.ItemsSource = cityLst;


        }

        public InsertStudentPage(int id) : this()
        {


            if (id == 0) { }

            else
            {

                StudentList list = srv.GetStudentListById(id);
                student = list[0];
                CityCbox.SelectedValue = student.City.Name;
                this.DataContext = student;
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // כפתור זהה להוספה ולעדכון
        {
            //ShareData.Data = person;

           

            if (DataContext != null)
            {
                
                if (!String.IsNullOrEmpty(student.Lname) &&
                    !String.IsNullOrEmpty(student.Fname) &&
                    student.City != null)
                {
                    try
                    {
                        if(student.Id == 0)   srv.GetInsertStudent(student);
                        else srv.GetUpdateStudent(student);
                        
                    }
                    catch { }
                    finally {
                        NavigationService nav = NavigationService.GetNavigationService(this);
                        if (nav.CanGoBack)
                            nav.GoBack();
                    }


                }
                else
                {
                    Massage.Text = "Fields should not be empty";
                }

            }
        }

    }
}

