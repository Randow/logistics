using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Diploma
{
    public class ToolBarButtonBase : INotifyPropertyChanged
    {
        public String ButtonToolTip { get; set; }
        public bool IsChecked { get; set; }
        public BitmapImage ToogleButtonImg { get; set; } 
        

        public ToolBarButtonBase(bool ischecked, BitmapImage img, String name)
        {
            ButtonToolTip = name;
            IsChecked = ischecked;
            ToogleButtonImg = img;
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

    public class Box
    {
        //настроить модификаторы доступа
        private String _label;
        public String Label { get { return _label; } }

        private double _length;
        public double Length { get { return _length; } }

        private double _width;
        public double Width { get { return _width; } }

        private double _height;
        public double Heigth { get { return _height; } }

        private double _weight;
        public double Weight { get { return _weight; } }

        private int _maxInPile;
        public int MaxInPile { get { return _maxInPile; } }

        private bool _care;
        public String Care { get { return _care ? "возможна" : "невозможна"; } }


        public Box(string label, double length, double width, double height, double weight, int maxInPile, bool care)
        {
            _label = label;
            _length = length;
            _width = width;
            _height = height;
            _weight = weight;
            _maxInPile = maxInPile;
            _care = care;
        }

    }
}
