﻿using System;
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
using System.Windows.Shapes;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for AlgorithmEditor.xaml
    /// </summary>
    public partial class AlgorithmEditor : Window
    {
        public AlgorithmEditor()
        {
            InitializeComponent();
        }

        private void CbxAlgorithms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Name;
            lblNoSettings.Visibility = Visibility.Hidden;

            switch (item)
            {
                case "RandomWalk": lblNoSettings.Visibility = Visibility.Visible; break;
            }

        }
    }
}
