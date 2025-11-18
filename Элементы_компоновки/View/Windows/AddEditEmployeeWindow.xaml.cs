using System;
using System.Collections.Generic;
using System.Configuration;
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
using Элементы_компоновки.Models;

namespace Элементы_компоновки.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {
        private EmployeeAppDbContext context = new();

        public AddEditEmployeeWindow()
        {
            InitializeComponent();

            PositionCmb.ItemsSource = context.Positions.ToList();
            DepartmentCmb.ItemsSource = context.Departments.ToList();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FullnameTb.Text) ||
                string.IsNullOrEmpty(EmailTb.Text) ||
                string.IsNullOrEmpty(PhoneTb.Text) ||
                DateOfBirthDp.SelectedDate.Value == null ||
                DateOfEmploymentDp.SelectedDate.Value == null ||
                PositionCmb.SelectedItem == null ||
                DepartmentCmb.SelectedItem == null ||
                GenderCmb.SelectedItem == null)
            {
                // Всплывающее окно (использоуется для реализации сообщения для пользователя)
                MessageBox.Show("Введены не все данные. Заполните все поля.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // 1. Создаём "шаблон" для записи (создаём объёктом с типом Employee)
                Employee newEmployee = new Employee();

                // 2. Заполняем столбцы в записи (добавляем данные в объект newEmployee)
                newEmployee.Fullname = FullnameTb.Text;
                newEmployee.DateOfBirth = DateOnly.FromDateTime(DateOfBirthDp.SelectedDate.Value);
                newEmployee.PositionId = Convert.ToInt32(PositionCmb.SelectedValue);
                newEmployee.Phone = PhoneTb.Text;
                newEmployee.Email = EmailTb.Text;
                newEmployee.DepartmentId = Convert.ToInt32(DepartmentCmb.SelectedValue);
                newEmployee.DateOfEmployment = DateOnly.FromDateTime(DateOfEmploymentDp.SelectedDate.Value);
                newEmployee.IsVacation = IsVacationCb.IsChecked.Value;
                newEmployee.Gender = (GenderCmb.SelectedItem as TextBlock).Text;

                // 3. Добавляем запись в таблицу 
                context.Employees.Add(newEmployee);

                // 4. Сохранить изменения
                context.SaveChanges();

                // 5. Оповещаем пользователя
                MessageBox.Show("Сотрудник успешно добавлен.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                // 6. Возвращаем результат работы окна
                DialogResult = true; 
            }
        }
    }
}
