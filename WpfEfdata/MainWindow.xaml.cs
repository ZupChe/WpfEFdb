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

        
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow p = new SecondWindow(empList);
            p.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (db = new EmpEntities())
            {
                Employee employee = empList.SelectedItem as Employee;
                var udbe = db.Employees.Single(x => x.EmployeeID == employee.EmployeeID);
                udbe.FirstName = employee.FirstName;
                udbe.LastName = employee.LastName;
                udbe.BirthDate = employee.BirthDate;
                db.SaveChanges();
            }
            MessageBox.Show("Successfull update");

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = empList.SelectedItem as Employee;
            if (employee?.EmployeeID != null)
            {
                using (db = new EmpEntities())
                {

                    var udbe = db.Employees.Single(x => x.EmployeeID == employee.EmployeeID);
                    db.Employees.Remove(udbe);
                    db.SaveChanges();
                    empList.ItemsSource = db.Employees.ToList();
                }
                MessageBox.Show("Delete successfull");
            }
        }
    }
    
}
