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
using System.Windows.Shapes;
using System.Data.Sql;

namespace WpfEfdata
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        Employee model = new Employee();
        EmpEntities db;

        protected DataGrid list;



        public SecondWindow(DataGrid list)
        {
            InitializeComponent();
            this.list = list;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            model.FirstName = txtFirstName.Text.Trim();
            model.LastName = txtLastName.Text.Trim();
            model.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());

            using (EmpEntities emp = new EmpEntities())
            {
                emp.Employees.Add(model);
                emp.SaveChanges();
                list.ItemsSource = emp.Employees.ToList();
            }
            this.Close();
            MessageBox.Show("New employee was add successfull");
            
        }

    }


    

    
}
