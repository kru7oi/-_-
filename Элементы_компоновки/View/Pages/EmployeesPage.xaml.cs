using Microsoft.Extensions.Options;
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
using Элементы_компоновки.View.Windows;

namespace Элементы_компоновки.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private EmployeeAppDbContext context = new();
        private List<Position> positions = new();
        public EmployeesPage()
        {
            InitializeComponent();

            positions = context.Positions.ToList();

            // Добавляем пункт "Все должности"
            positions.Insert(0, new Position() { Name = "Все должности" });

            FilterByPosition.ItemsSource = positions;
            EmployeesLv.ItemsSource = context.Employees.ToList();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow();
            addEditEmployeeWindow.Show();
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

        private void FilterByPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 1. Получить выбранный элемент (должность) из списка
            // 2. Получить полный список сотрудников
            // 3. Произвести фильтрацию в списке по условию
            // 4. Полученный список передать в качестве источника элементов в ListView

            Position? selectedPosition = FilterByPosition.SelectedItem as Position;

            if (selectedPosition.Name == "Все должности")
            {
                EmployeesLv.ItemsSource = context.Employees.ToList();
            }
            else
            {
                EmployeesLv.ItemsSource = context.Employees.Where(employee => employee.PositionId == selectedPosition.Id).ToList();
            }
        }
    }
}
