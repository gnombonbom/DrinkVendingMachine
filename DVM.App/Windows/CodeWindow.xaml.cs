using DVM.API.Controllers;
using DVM.API.Models.Domain;
using DVM.App.Pages;
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

namespace DVM.App.Windows
{
    /// <summary>
    /// Логика взаимодействия для CodeWindow.xaml
    /// </summary>
    public partial class CodeWindow : Window
    {
        private VendingMachineController _vmController = new();
        public CodeWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            String code = codeTB.Text;
            VendingMachine vm = _vmController.GetVendingMachineBySecretCode(code);
            VendingMachinePage.vm = vm;
            if (vm.SecretCode != "" && vm.SecretCode != null)
                Hide();
            errorLabel.Content = "Вы ввели неправильный код";
        }
    }
}
