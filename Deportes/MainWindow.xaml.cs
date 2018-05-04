using deportes.COMMON.Entidades;
using deportes.COMMON.Interfaces;
using Deportes.BIZ;
using Deportes.DAL;
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

namespace Deportes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorUsuario manejadorUsuario;
        public MainWindow()
        {
            InitializeComponent();
            manejadorUsuario = new ManejadorUsuario(new RepositorioGenerico<Usuario>());
            Actualizar();
       
        }

        private void Actualizar()
        {
            cmbUsuario.ItemsSource = null;
            cmbUsuario.ItemsSource = manejadorUsuario.Listar;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsuario.Text == "" )
            {
                MessageBox.Show("Error", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbContraseña.Password))
            {
                MessageBox.Show("Favor de ingresar la contraseña", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if(string.IsNullOrEmpty(txbContraseña.Password))
            {
                MessageBox.Show("No ha ingresado la contraseña", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(cmbUsuario.SelectedItem !=null)
            {
                Usuario a = cmbUsuario.SelectedItem as Usuario;
                if(txbContraseña.Password==a.Contraseña)
                {
                    Deportes1 b = new Deportes1();
                    b.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña Inconrrecta", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun usuario", "Uusario", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
