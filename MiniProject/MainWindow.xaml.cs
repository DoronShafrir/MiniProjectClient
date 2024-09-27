using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;   //hide the Frame Navigation
                                                                              // XAML-אפשר גם ישירות מקובץ ה

            
        }

        //private void Button_Click(object sender, RoutedEventArgs e)

        //{
        //StudentDB db = new StudentDB();
        //    StudentList list = db.SelectAll();

        //    this.lstView3.ItemsSource = list;

        //}
        private void Item2_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new LecturerPage());
        }

        private void Item1_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new StudentPage());
        }

        private void Item3_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new CoursePage());
        }

        private void Item0_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new MainPage()); 
        }
    }
}
