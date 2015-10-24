using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Diploma
{

    public class GeneralViewModel : INotifyPropertyChanged
    {
        public List<Box> Boxes { get; set; }

        public string BoxPropertiesList { get; set; }
        public Visibility BoxPropertiesVisibility { get; set; }
        public BitmapImage BoxPropertiesImg { get; set; }

        public Visibility BoxListVisibility { get; set; }
        public BitmapImage BoxListImg { get; set; }

        public Box BoxListSelectedItem { get; set; }

        public List<ToolBarButtonBase> FirstGroupButtons { get; set; }
        public List<ToolBarButtonBase> SecondGroupButtons { get; set; }

        public GeneralViewModel()
        {
            Boxes = new List<Box> { };
            FirstGroupButtons = new List<ToolBarButtonBase> { };

            FirstGroupButtons.Add(new ToolBarButtonBase(false, new BitmapImage(new Uri("Images/selectAndMove.png", UriKind.Relative)), "SelectAndMove"));
            FirstGroupButtons.Add(new ToolBarButtonBase(false, new BitmapImage(new Uri("Images/selectAndRotate.png", UriKind.Relative)), "SelectAndRotate"));

            SecondGroupButtons = new List<ToolBarButtonBase> { };
            SecondGroupButtons.Add(new ToolBarButtonBase(false, new BitmapImage(new Uri("Images/selectObject.png", UriKind.Relative)), "SelectObject"));

            BoxPropertiesVisibility = Visibility.Collapsed;
            BoxPropertiesImg = new BitmapImage(new Uri("Images/plus.png", UriKind.Relative));
            OnPropertyChanged("BoxPropertiesVisibility");
            OnPropertyChanged("BoxPropertiesImg");
            BoxListVisibility = Visibility.Collapsed;
            BoxListImg = new BitmapImage(new Uri("Images/plus.png", UriKind.Relative));
            OnPropertyChanged("BoxListVisibility");
            OnPropertyChanged("BoxListImg");
        }
        public void SetVisibility(String propertyName, String propertyImgName)
        {
            System.Reflection.PropertyInfo prop = typeof(GeneralViewModel).GetProperty(propertyName);
            //System.Reflection.PropertyInfo[] prop1 = typeof(GeneralViewModel).
            System.Reflection.PropertyInfo propImg = typeof(GeneralViewModel).GetProperty(propertyImgName);
            if (prop.GetValue(this).ToString() == Visibility.Collapsed.ToString())
            {
                prop.SetValue(this, Visibility.Visible);
                propImg.SetValue(this, new BitmapImage(new Uri("Images/minus.png", UriKind.Relative)));
            }
            else
            {
                prop.SetValue(this, Visibility.Collapsed);
                propImg.SetValue(this, new BitmapImage(new Uri("Images/plus.png", UriKind.Relative)));
            }
            OnPropertyChanged(propertyName);
            OnPropertyChanged(propertyImgName);
        }

        public void InitializeBoxCollection()
        {
            Boxes.Add(new Box("21877/8 паллет 1", 3.17, 1.82, 1.59, 770, 1, false));
            Boxes.Add(new Box("21877/8 паллет 2", 2.27, 2.07, 1.45, 900, 1, false));
            Boxes.Add(new Box("21877/8 паллет 3", 2.67, 2.17, 1.25, 650, 1, false));
            Boxes.Add(new Box("21877/8 паллет 4", 3.2, 0.52, 0.71, 297, 1, false));
            OnPropertyChanged("Boxex");
        }

        public void BoxList_SelectionChanged()
        {
            BoxPropertiesList = "Маркировка: " + BoxListSelectedItem.Label + Environment.NewLine + "Длина: " + BoxListSelectedItem.Length + Environment.NewLine
                + "Ширина: " + BoxListSelectedItem.Width + Environment.NewLine + "Высота " + BoxListSelectedItem.Heigth + Environment.NewLine + "Вес: " + BoxListSelectedItem.Weight + Environment.NewLine
                + "Максимально в стопке: " + BoxListSelectedItem.MaxInPile + Environment.NewLine + "Кантовка: " + BoxListSelectedItem.Care;

            OnPropertyChanged("BoxPropertiesList");
        }

        public void ToggleButton_Checked(String tooltip)
        {
            foreach (var item in FirstGroupButtons)
            {
                if (item.ButtonToolTip != tooltip)
                {
                    item.IsChecked = false;
                }
                item.OnPropertyChanged("IsChecked");
            }
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
