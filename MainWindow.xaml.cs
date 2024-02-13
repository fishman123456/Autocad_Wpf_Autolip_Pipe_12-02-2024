
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
        // список для значений тексбокса имя слоя
        public List<string> list_lay_name = new List<string>();
        // список для значений текстбокса диаметры
        public List<string> list_pipe_Diam = new List<string>();
        StringBuilder sb = new StringBuilder();
        
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
            string[] mass_Lay_name = TextBox_Lay_name.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            // добавляем данные в список из текстбокса TextBox_Block_name
            string[] mass_diam_cable = TextBox_Pipe_Diam.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;

            try
            {
                foreach (var item in mass_Lay_name)
                {     
                    list_pipe_Diam.Add(mass_diam_cable[count]);
                    list_lay_name.Add(mass_Lay_name[count]);
                    count++;
                }
                // собираем lisp
                sb.Append(String_Lisp.begin);
                sb.Append("\n");
                // добавляем диаметры из текстбокса
                foreach (var item in list_pipe_Diam)
                {
                    sb.Append(item);
                    sb.Append("\n");
                }
                //sb.Append(String_Lisp.diam); 
                //sb.Append("\n");
                sb.Append(String_Lisp.middle);
                sb.Append("\n");
                // добавляем имя слоя из текстбокса
                foreach (var item in list_lay_name)
                {
                    sb.Append("\"" + item + "\"");
                    sb.Append("\n");
                }
                //sb.Append(String_Lisp.laystr);
                //sb.Append("\n");
                sb.Append(String_Lisp.endstr);
                sb.Append("\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            SaveFile.saveFileMetod(sb.ToString());
            Array.Clear(mass_diam_cable, 0, mass_diam_cable.Length);
            Array.Clear(mass_Lay_name, 0, mass_Lay_name.Length);
            list_pipe_Diam.Clear();
            list_lay_name.Clear();
            sb.Clear();
        }
    }
}