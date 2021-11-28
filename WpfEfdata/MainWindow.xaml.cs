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
using System.Data.Sql;

namespace WpfEfdata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee model = new Employee();

        EmpEntities db;


        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new EmpEntities();
            empList.ItemsSource = db.Employees.ToList();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtBirthDate.Text = "";
            btnNew.Content = "New";
            btnUpdate.Content = "Update";
            btnDelete.IsEnabled = false;
            model.EmployeeID = 0;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow p = new SecondWindow();
            p.Show();
        }

     
           
       
       

     

    }
    
}
