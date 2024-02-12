using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;



namespace Autocad_Wpf_Autolip_Pipe_12_02_2024
{
    public class SaveFile
    {
        public static async void saveFileMetod(string text)
        { 
            // проверка по текущей дате
            CheckDateWork.CheckDate();
            // открываем диалог для сохранения файла в поток
            SaveFileDialog saveFile= new SaveFileDialog();
            
            saveFile.Filter = "Text files(*.lsp)|*.lsp|All files(*.*)|*.*";
            // если не сохраняем то выходим
            if (saveFile.ShowDialog() != true)
            { return; }
            // получаем выбранный файл
            string path = saveFile.FileName;
            // сохраняем текст в файл
            try
            {
                // полная перезапись файла 
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    // асинхронная перезапись  файла
                    await writer.WriteAsync(text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

