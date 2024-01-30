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
using WpfClient.ServiceReferenceUFC;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for WindowFighter.xaml
    /// </summary>
    public partial class FighterWindow : Window
    {
        public FighterWindow(Fighter fighter)
        {
            InitializeComponent();
            this.DataContext = fighter;
            tbAge.Text=(DateTime.Today.Year-fighter.Age.Year).ToString();
            try
            {
                image.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/Fighters/"+fighter.Name+".png"));
            }
            catch (Exception ex)
            {
                image.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/logo.png"));
            }

        }
    }
}