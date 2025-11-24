using System.Configuration;
using System.Data;
using System.Windows;
using Элементы_компоновки.Models;

namespace Элементы_компоновки
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EmployeeAppDbContext context = new();
    }

}
