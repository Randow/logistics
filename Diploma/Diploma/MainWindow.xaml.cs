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

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> Boxes;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CheckBoxProperties(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("" + ((StackPanel)sender).Name + " " + e.Source);

            if (BoxProperties.Visibility == Visibility.Collapsed)
            {
                BoxProperties.Visibility = Visibility.Visible;
                BoxPropertiesImg.Source = new BitmapImage(new Uri("Images/minus.png", UriKind.Relative));
            }
            else
            {
                if (BoxProperties.Visibility == Visibility.Visible)
                {
                    BoxProperties.Visibility = Visibility.Collapsed;
                    BoxPropertiesImg.Source = new BitmapImage(new Uri("Images/plus.png", UriKind.Relative));
                }
            }
        }


        private void CheckBoxList(object sender, MouseButtonEventArgs e)
        {
            if (BoxList.Visibility == Visibility.Collapsed)
            {
                BoxList.Visibility = Visibility.Visible;
                BoxListImg.Source = new BitmapImage(new Uri("Images/minus.png", UriKind.Relative));
            }
            else
            {
                if (BoxList.Visibility == Visibility.Visible)
                {

                    BoxList.Visibility = Visibility.Collapsed;
                    BoxListImg.Source = new BitmapImage(new Uri("Images/plus.png", UriKind.Relative));
                }
            }
        }

        //события на вылетающие подсказки
        #region
        private void NewProjectEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для создания нового проекта");
        }

        private void OpenProjectEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для открытия проекта");
            #region
            //Microsoft.Win32.OpenFileDialog odlg = new Microsoft.Win32.OpenFileDialog();
            //odlg.DefaultExt = ".txt"; // Default file extension
            //odlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            //// Show open file dialog box
            //Nullable<bool> result = odlg.ShowDialog();
            #endregion
        }

        private void SaveProjectEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для сохранения проекта");
            // Microsoft.Win32.SaveFileDialog sdlg = new Microsoft.Win32.SaveFileDialog();
        }
        private void InvoiceImportEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для импорта инвойса");
        }
        private void UndoEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для отмены действия");
        }
        private void RedoEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для возврата действия");
        }
        private void SelectAllEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для выделения всех объектов в проекте");
        }
        private void InverseSelectEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для инверсии выделения");
        }
        private void RemoveEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для удаления объекта");
        }
        private void ShowReferenceEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для удаления объекта");
        }
        private void AboutEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для удаления объекта");
        }
        private void FieldEvt(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Здесь будут объекты");
        }
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Выбранный элемент");
        }
        #endregion
    }
}
