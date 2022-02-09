using DVM.API.Controllers;
using DVM.API.Models.Domain;
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

namespace DVM.App.Pages
{
    /// <summary>
    /// Логика взаимодействия для VendingMachinePage.xaml
    /// </summary>
    public partial class VendingMachinePage : Page
    {
        private Guid _VmId = Guid.Parse("50d5ed51-d49c-4bd6-b843-0a498b1dd003");
        private VMDrinkController _VMDcontroller = new();
        private VMCoinController _VMCcontroller = new();

        public VendingMachinePage()
        {
            InitializeComponent();
            ShowItems();
        }

        private void ShowItems()
        {
            List<VMDrink> drinks = _VMDcontroller.GetVMDrinks(_VmId);
            VMDrinkList.ItemsSource = drinks;
            List<VMCoin> coins = _VMCcontroller.GetVMCoins(_VmId);
            coinList.ItemsSource = coins;
        }
    }
}
