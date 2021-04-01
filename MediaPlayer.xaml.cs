﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace ADP2_Flight_Inspection_App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MediaPlayerView : Window
    {
        private MediaPlayerViewModel vm;

        public MediaPlayerView(MediaPlayerViewModel viewmodel)
        {
            vm = viewmodel;
            InitializeComponent();
            vm = viewmodel;
            vm.PropertyChanged+= delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged(e.PropertyName);
            };
            DataContext = vm;
            timeSlider.Maximum = (int)vm.numOfRows;
            
        }

        private void NotifyPropertyChanged(string propName) 
        {

            if (String.Compare(propName, "VM_Time") == 0)
            {
                this.Dispatcher.Invoke(()=>
                    timeSlider.Value = (int)vm.VM_Time);
            }    
            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)speedBox.SelectedItem;
            string newSpeed = cbi.Content.ToString();
            string [] arr = newSpeed.Split(' ');
            vm.VM_Speed = Double.Parse(arr[1]);
        }
    }
}