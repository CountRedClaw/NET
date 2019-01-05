using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace lab9_EPAM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        String path = "";

        private void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(path = openFileDialog.FileName);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(path = saveFileDialog.FileName, txtEditor.Text);
        }

        private void SaveAs_Button_Click(object sender, RoutedEventArgs e)
        {
            if (path != "")
            {
                File.WriteAllText(path, txtEditor.Text);
            }
            else
            {
                Save_Button_Click(sender, e);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs cancelEventArgs)
        {
            MessageBoxResult result = MessageBox.Show("Сохранить перед выходом?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                SaveAs_Button_Click(sender, null);
                txtEditor.Text = "";
                path = "";
            }
            else if (UseLayoutRounding)
            {
                txtEditor.Text = "";
                path = "";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}