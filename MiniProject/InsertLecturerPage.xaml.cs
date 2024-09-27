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
    public partial class InsertLecturerPage : Page
    {

        ServiceReference2.Service1Client srv = new ServiceReference2.Service1Client();
        Lecturer lecturer = new Lecturer();

        public InsertLecturerPage()
        {
            InitializeComponent();
            this.DataContext = lecturer;

            CityList cityLst = new CityList();
            cityLst = srv.GetCityList();  // ממלא את רשימת הערים בדף
            this.CityCbox.ItemsSource = cityLst;


        }

        public InsertLecturerPage(int id) : this()
        {


            if (id == 0) { }

            else
            {

                LecturerList list = srv.GetLecturertListById(id);
                lecturer = list[0];
                CityCbox.SelectedValue = lecturer.City.Name;
                this.DataContext = lecturer;
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // כפתור זהה להוספה ולעדכון
        {




            if (DataContext != null)
            {

                if (!String.IsNullOrEmpty(lecturer.Lname) &&
                    !String.IsNullOrEmpty(lecturer.Fname) &&
                    lecturer.City != null)
                {
                    try
                    {
                        if (lecturer.Id == 0) srv.GetInsertLecturer(lecturer);
                        else srv.GetUpdateLecturer(lecturer);

                    }
                    catch { }
                    finally
                    {
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