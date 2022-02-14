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
    /// Логика взаимодействия для ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : Window
    {
        public CodeWindow codeWindow = new();
        public static String code;
        public ContentWindow()
        {
            InitializeComponent();
        }

        public void Open()
        {
            codeWindow.ShowDialog();
        }

        public void ChangeFrame(String source)
        {
            mainFrame.NavigationService.Navigate(new Uri(source, UriKind.Relative));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            codeWindow.Owner = this;
        }
    }
}
