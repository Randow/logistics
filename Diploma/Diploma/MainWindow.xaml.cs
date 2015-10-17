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



namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string BoxPropertiesList { get; set; }
        public List<Box> Boxes { get; set; }
        public Visibility BoxPropertiesVisibility { get; set; }
        public Visibility BoxListVisibility { get; set; }

        public BitmapImage BoxPropertiesImg { get; set; }
        public BitmapImage BoxListImg { get; set; }

        
        public MainWindow()
        {
            Boxes = new List<Box> { };
            

            

            BoxPropertiesVisibility = Visibility.Collapsed;
            BoxPropertiesImg = new BitmapImage(new Uri("Images/plus.png", UriKind.Relative));
            OnPropertyChanged("BoxPropertiesVisibility");
            OnPropertyChanged("BoxPropertiesImg");
            BoxListVisibility = Visibility.Collapsed;
            BoxListImg = new BitmapImage(new Uri("Images/plus.png", UriKind.Relative));
            OnPropertyChanged("BoxListVisibility");
            OnPropertyChanged("BoxListImg");

            InitializeComponent();
            DataContext = this;

          
            

        }

        

        private void CheckBoxProperties(object sender, MouseButtonEventArgs e)
        {
            if (BoxPropertiesVisibility == Visibility.Collapsed)
            {
                SetBoxPropertiesVisibility(Visibility.Visible, "Images/minus.png");
            }
            else
            {
                SetBoxPropertiesVisibility(Visibility.Collapsed, "Images/plus.png");
            }
        }

        private void SetBoxPropertiesVisibility(Visibility vis, String uri)
        {
            BoxPropertiesVisibility = vis;
            BoxPropertiesImg = new BitmapImage(new Uri(uri, UriKind.Relative));
            OnPropertyChanged("BoxPropertiesVisibility");
            OnPropertyChanged("BoxPropertiesImg");
        }
        private void CheckBoxList(object sender, MouseButtonEventArgs e)
        {
            if (BoxListVisibility == Visibility.Collapsed)
            {
                SetBoxListVisibility(Visibility.Visible, "Images/minus.png");
            }
            else
            {
                SetBoxListVisibility(Visibility.Collapsed, "Images/plus.png");
            }
        }
        private void SetBoxListVisibility(Visibility vis, String uri)
        {
            BoxListVisibility = vis;
            BoxListImg = new BitmapImage(new Uri(uri, UriKind.Relative));
            OnPropertyChanged("BoxListVisibility");
            OnPropertyChanged("BoxListImg");
        }


        //события на вылетающие подсказки
        #region
        private void NewProjectEvt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пункт для создания нового проекта");
        }

        private void OpenProjectEvt(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Пункт для открытия проекта");
            OpenFileDialog odlg = new OpenFileDialog();
            odlg.DefaultExt = ".txt"; // Default file extension
            odlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            odlg.FileOk += new CancelEventHandler(odlg_FileOk);
            odlg.ShowDialog();
            
            
        }
        private void odlg_FileOk(object sender, CancelEventArgs e)
        {
            Boxes.Add(new Box("21877/8 паллет 1", 3.17, 1.82, 1.59, 770, false));
            Boxes.Add(new Box("21877/8 паллет 2", 2.27, 2.07, 1.45, 900, false));
            Boxes.Add(new Box("21877/8 паллет 3", 2.67, 2.17, 1.25, 650, false));
            Boxes.Add(new Box("21877/8 паллет 4", 3.2, 0.52, 0.71, 297, false));
            OnPropertyChanged("Boxex");
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

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
//стоит ли здесь убирать зависимость от view?
            foreach (var item in ToolBarPanel.Children)
            {
                if ((item.GetType().Name == sender.GetType().Name)) 
                {
                    
                    if (((ToggleButton)sender).Name != ((ToggleButton)item).Name)
                    {
                        ((ToggleButton)item).IsChecked = false;
                    }
                }
            }
        }




        

        private void BoxList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
//а здесь стоит?
            Box sBox = (Box)BoxList.SelectedItem;
            BoxPropertiesList = "Маркировка: " + sBox.Label + Environment.NewLine + "Длина: " + sBox.Length + Environment.NewLine + "Ширина: " + sBox.Width;
            
            OnPropertyChanged("BoxPropertiesList");
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
