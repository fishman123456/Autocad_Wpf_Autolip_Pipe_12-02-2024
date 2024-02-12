
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

namespace Autocad_Wpf_Autolip_Pipe_12_02_2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> list_lay_name = new List<string>();
        public List<string> list_pipe_Diam = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            CheckDateWork.CheckDate();
        }

        private void Button_Clear_Lay_name_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Lay_name.Clear();
        }

        private void Button_Clear_Pipe_Diam_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Pipe_Diam.Clear();
        }

        private void Button_Save_as_Click(object sender, RoutedEventArgs e)
        {
            // строка по которой будем разбивать текстбокс
            // расделителем может служить один символ, поэтому строку создаём, т е массив символов
            string[] separator = { "\n", "\r" };
            // добавляем данные в список из текстбокса TextBox_Lay_name 
            string[] mass_textBox_Lay_name = TextBox_Lay_name.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            // добавляем данные в список из текстбокса TextBox_Block_name
            string[] mass_block_name = TextBox_Pipe_Diam.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;

            try
            {
                foreach (var item in mass_textBox_Lay_name)
                {
                    list_lay_name.Add(mass_textBox_Lay_name[count]);
                    list_pipe_Diam.Add(mass_block_name[count]);
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            SaveFile.saveFileMetod(String_Lisp.stringBuilder.ToString());
        }
    }
}