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
using Элементы_компоновки.Models;

namespace Элементы_компоновки.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private EmployeeAppDbContext context = new();
        public EmployeesPage()
        {
            InitializeComponent();

            EmployeesLv.ItemsSource = context.Employees.ToList();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchByNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchByNameTb.Text))
            {
                EmployeesLv.ItemsSource = context.Employees.ToList();
            }
            else
            {
                EmployeesLv.ItemsSource = context.Employees.Where(employee => employee.Fullname.Contains(SearchByNameTb.Text)).ToList();
            }
        }
    }
}
