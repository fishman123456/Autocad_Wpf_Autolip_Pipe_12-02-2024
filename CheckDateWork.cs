using Autocad_Wpf_Autolip_Pipe_12_02_2024;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Autocad_Wpf_Autolip_Pipe_12_02_2024
{
    // класс для проверки текущей даты
    public static class CheckDateWork
    {
        public static void CheckDate()
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("20/03/2024");
            if (dt1.Date > dt2.Date)
            {
                MessageBox.Show("Time is over 20/03/2024");
                // Выход из проложения добавил 01-01-2024. Чтобы порядок был....
                var mainWindow = (Application.Current.MainWindow as MainWindow);
                if (mainWindow != null)
                {
                    
                    mainWindow.Close();
                }
            }
            else
            {
                //MessageBox.Show("Работайте до   " + dt2.ToString());
            }
        }
    }
}
