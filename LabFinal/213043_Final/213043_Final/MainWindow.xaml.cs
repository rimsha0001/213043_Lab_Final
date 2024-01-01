using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace _213043_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-46PNOSO\\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True;");
        public void clearData()
        {
            id_txt.Clear();
            Name_txt.Clear();
            RegNo_txt.Clear();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("selct * from Student", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGrid1.ItemsSource = dt.DefaultView;
        }
        public bool isValid()
        {
            if (id_txt.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK);
                return false;
            }

            if (Name_txt.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK);
                return false;
            }
            private void  Button_Click_1(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (isValid())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Insert INTO Student Values (@id,@Name,@RegNo", con);
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@id", id_txt);
                        sqlCommand.Parameters.AddWithValue("@Name", Name_txt);
                        sqlCommand.Parameters.AddWithValue("@RegNo", RegNo_txt);
                        con.Open();
                        sqlCommand.ExecuteNonQuery();
                        con.Close();
                        LoadGrid();
                        MessageBox.Show("Sucessfully register", "Success", MessageBoxButton.OK);
                        clearData();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
            }
        }
    }
}