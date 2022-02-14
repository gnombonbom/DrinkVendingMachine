using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using System.Drawing;

namespace DVM.AddPict
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String _connectionString = @"Data Source=Mikhuil;Initial Catalog=DrinkVendingMachine;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
            AddPict();
        }

        public void AddPict()
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new($"INSERT INTO drink VALUES (@p_id, @p_name, @p_image, @p_cost)", connect);
                cmd.Parameters.AddWithValue("@p_id", Guid.Parse("aa2c4cec-ea35-4279-ac63-c8ad71d2c72c"));
                cmd.Parameters.AddWithValue("@p_name", "Байкал");
                String fileName = "C:/Users/Михуил/Downloads/картинки/baikal.png";
                //ImageSourceConverter converter = new();
                //Image image = new();
                //image.Source = (ImageSource)converter.ConvertFromString(fileName);
                //MemoryStream ms = new();
                Byte[] imgData = File.ReadAllBytes(fileName);
                cmd.Parameters.AddWithValue("@p_image", imgData);
                cmd.Parameters.AddWithValue("@p_cost", 55);
                cmd.ExecuteNonQuery();
                
               // cmd.Parameters.AddWithValue("@p_image");
            }
        }
    }
}
