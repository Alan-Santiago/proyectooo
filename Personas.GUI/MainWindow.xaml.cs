﻿using deportes.COMMON.Graficos;
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

namespace Personas.GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GraficaInfo graficaInfo;
        Random ran = new Random();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMostrarGrafica_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
