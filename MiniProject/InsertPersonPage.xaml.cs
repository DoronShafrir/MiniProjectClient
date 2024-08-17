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
    /// Interaction logic for AddStudentPage.xaml
    /// </summary>
    public partial class InsertPersonPage : Page
    {
        
        private BaseEntity person = null;
        private CityList cityLst;
       

        public InsertPersonPage()
        {
            InitializeComponent();
            CityDB city = new CityDB();
            cityLst = city.SelectAll();  // ממלא את רשימת הערים בדף
            this.CityCbox.ItemsSource = cityLst;

            
        }

        public InsertPersonPage(BaseEntity person) : this()
        {
                       

            this.person = person;

            
            this.DataContext = person;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // כפתור זהה להוספה ולעדכון
        {
            
           
            ShareData.Data = person;

                NavigationService nav = NavigationService.GetNavigationService(this);
                if (nav.CanGoBack)
                    nav.GoBack();
            
        }
    }
}
