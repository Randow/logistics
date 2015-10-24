using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Reflection;


namespace Diploma
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public GeneralViewModel generalVM = new GeneralViewModel();
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = generalVM;
        }

        

        private void CheckBoxProperties(object sender, MouseButtonEventArgs e)
        {
            generalVM.SetVisibility("BoxPropertiesVisibility", "BoxPropertiesImg");
        }
        private void CheckBoxList(object sender, MouseButtonEventArgs e)
        {
            generalVM.SetVisibility("BoxListVisibility", "BoxListImg");
        }


        //события на вылетающие подсказки
        #region
        private void NewProjectEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для создания нового проекта");
        }

        private void OpenProjectEvt(object sender, RoutedEventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();
            odlg.DefaultExt = ".txt";
            odlg.Filter = "Text documents (.txt)|*.txt";
            odlg.FileOk += new CancelEventHandler(odlg_FileOk);
            odlg.ShowDialog();
        }
        private void odlg_FileOk(object sender, CancelEventArgs e)
        {
            generalVM.InitializeBoxCollection();
            MessageBox.Show("данные открыты");
        }

        private void SaveProjectEvt(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.DefaultExt = ".txt";
            sdlg.Filter = "Text documents (.txt)|*.txt";
            sdlg.FileOk += new CancelEventHandler(sdlg_FileOk);
            sdlg.ShowDialog();
        }
        private void sdlg_FileOk(object sender, CancelEventArgs e)
        {
            MessageBox.Show("данные сохранены");
        }

        private void InvoiceImportEvt(object sender, RoutedEventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();
            odlg.DefaultExt = ".csv";
            odlg.Filter = "Text documents (.csv)|*.csv";
            odlg.FileOk += new CancelEventHandler(odlg_FileOk);
            odlg.ShowDialog();
        }
        private void FormPackListEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для формирования и последующей печати упаковочного листа");
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

        private void ToggleButton_CheckedEvt(object sender, RoutedEventArgs e)
        {
            generalVM.ToggleButton_Checked(((ToggleButton)sender).ToolTip.ToString());
        }
        

        private void BoxList_SelectionChangedEvt(object sender, SelectionChangedEventArgs e)
        {
            generalVM.BoxList_SelectionChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
