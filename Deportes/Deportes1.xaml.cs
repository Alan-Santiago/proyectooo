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
using System.Windows.Shapes;

namespace Deportes
{
    /// <summary>
    /// Lógica de interacción para Deportes1.xaml
    /// </summary>
    public partial class Deportes1 : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorDeportes manejadorDeportes;
        IManejadorEquipo manejadorEquipo;
        IManejadorUsuario manejadorUsuario;
        IManejadorTorneo manejadorTorneo;

        List<DeporteVista> vista = new List<DeporteVista>();
        List<DeporteVista> nueva = new List<DeporteVista>();
        List<Aleatorios> lista1 = new List<Aleatorios>();
        List<Aleatorios> lista2 = new List<Aleatorios>();
        List<Torneo> torneoo = new List<Torneo>();
        string equipoA;
        string equipoB;


        accion accionDeporte;
        accion accionEquipo;
        accion accionUsuario;
        accion accionTorneo;

        public Deportes1()
        {
            InitializeComponent();
            manejadorDeportes = new ManejadorDeportes(new RepositorioGenerico<CateDeportes>());
            manejadorEquipo = new ManejadorEquipo(new  RepositorioGenerico<Equipo>());
            manejadorUsuario = new ManejadorUsuario(new RepositorioGenerico<Usuario>());
            manejadorTorneo = new ManejadorTorneo(new RepositorioGenerico<Torneo>());

            PonerBotonesDeportesEdicion(false);
            LimpiarCamposdeDeportes(false);
            ActualizarTablaDeportes();

            PonerBotonesEquipoEdicion(false);
            LimpiarCamposdeEquipo(false);
            ActualizarTablaEquipo();

            PonerBotonesUsuarioEdicion(false);
            LimpiarCamposdeUsuario();
            ActualizarTablaUsuario();


            LimpiarCamposdeTorneo(false);
            ActualizarTablaTorneo();

            
            LimpiarCamposPuntuacion();
            ActualizarTablaPuntuacion();
        }

        private void LimpiarCamposPuntuacion()
        {
            txbPuntuacionEquipoA.Clear();
            txbPuntuacionEquipoB.Clear();
            txbPuntuacionMarcadorA.Clear();
            txbPuntuacionMarcadorB.Clear();
            txbPuntuacionId.Clear();
        }

        private void ActualizarTablaPuntuacion()
        {
            dtgPuntuacion.ItemsSource = null;
            dtgPuntuacion.ItemsSource = manejadorTorneo.Listar;

            cmbPuntuacionDeporte.ItemsSource = null;
            cmbPuntuacionDeporte.ItemsSource = manejadorDeportes.Listar;
        }

        private void ActualizarTablaTorneo()
        {
            dtgTorneo.ItemsSource = null;
            dtgTorneo.ItemsSource = manejadorTorneo.Listar;

            cmbTorneoDeporte.ItemsSource = null;
            cmbTorneoDeporte.ItemsSource = manejadorDeportes.Listar;
        }

        private void LimpiarCamposdeTorneo(bool a)
        {
            cmbTorneoDeporte.ItemsSource = "";
            txbTorneoFecha.Text = "";

            cmbTorneoDeporte.IsEditable = a;
            txbTorneoFecha.IsEnabled = a;
            ActualizarTablaTorneo();

            btnTorneoCancelar.IsEnabled = a;
            btnTorneoEliminar.IsEnabled = !a;
            btnTorneoOrdenar.IsEnabled = a;
            btnTorneoNuevo.IsEnabled = !a;

        }



        private void ActualizarTablaUsuario()
        {
            dtgUsuario.ItemsSource = null;
            dtgUsuario.ItemsSource = manejadorUsuario.Listar;


        }

        private void LimpiarCamposdeUsuario()
        {
            txbUsuarioNombre.Clear();
            txbUsuarioDireccion.Clear();
            txbUsuarioApellidos.Clear();
            txbUsuarioContraseña.Clear();


        }

        private void PonerBotonesUsuarioEdicion(bool value)
        {
            btnUsuarioCancelar.IsEnabled = value;
            btnUsuarioEditar.IsEnabled = !value;
            btnUsuarioEliminar.IsEnabled = !value;
            btnUsuarioGuardar.IsEnabled = value;
            btnUsuarioNuevo.IsEnabled = !value;
        }

        private void ActualizarTablaEquipo()
        {
            dtgEquipos.ItemsSource = null;
            dtgEquipos.ItemsSource = manejadorEquipo.Listar;
        }

        private void LimpiarCamposdeEquipo(bool value)
        {
            txbEquipoNombre.Clear();
            txbEquipoNombre.IsEnabled = value;
            cmbEquipoDeporte.IsEnabled = value;
        }

        private void PonerBotonesEquipoEdicion(bool value)
        {
            btnEquipoCancelar.IsEnabled = value;
            btnEquipoEditar.IsEnabled = !value;
            btnEquipoEliminar.IsEnabled = !value;
            btnEquipoGuardar.IsEnabled = value;
            btnEquipoNuevo.IsEnabled = !value;
        }

        private void ActualizarTablaDeportes()
        {
            dtgDeportes.ItemsSource = null;
            dtgDeportes.ItemsSource = manejadorDeportes.Listar;
            cmbEquipoDeporte.ItemsSource = null;
            cmbEquipoDeporte.ItemsSource = manejadorDeportes.Listar;
        }

        private void LimpiarCamposdeDeportes(bool value)
        {
            txbNombreDeporte.Clear();
            txbNombreDeporte.IsEnabled = value;
        }

        private void PonerBotonesDeportesEdicion(bool value)
        {
            btnDeportesCancelar.IsEnabled = value;
            btnDeportesEditar.IsEnabled = !value;
            btnDeportesEliminar.IsEnabled = !value;
            btnDeportesGuardar.IsEnabled = value;
            btnDeportesNuevo.IsEnabled = !value;
        }

        private void btnDeportesNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposdeDeportes(true);
            PonerBotonesDeportesEdicion(true);
            accionDeporte = accion.Nuevo;
        }

        private void btnDeportesEditar_Click(object sender, RoutedEventArgs e)
        {

            if (dtgDeportes.SelectedItem != null)
            {
                accionDeporte = accion.Editar;
                LimpiarCamposdeDeportes(true);
                PonerBotonesDeportesEdicion(true);
                CateDeportes cate = dtgDeportes.SelectedItem as CateDeportes;

                txbNombreDeporte.Text = cate.NombreDeporte;

            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeportesGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreDeporte.Text))
            {
                MessageBox.Show("Faltan Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (accionDeporte == accion.Nuevo)
            {
                CateDeportes cate = new CateDeportes();


                cate.NombreDeporte = txbNombreDeporte.Text;

                if (manejadorDeportes.Agregar(cate))
                {
                    MessageBox.Show("Deporte agregada correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposdeDeportes(false);
                    ActualizarTablaDeportes();
                    PonerBotonesDeportesEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Deporte no se pudo agregar", "Deporte", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                CateDeportes cate = dtgDeportes.SelectedItem as CateDeportes;
                cate.NombreDeporte = txbNombreDeporte.Text;
                if (manejadorDeportes.Modificar(cate))
                {
                    MessageBox.Show("Deporte modificado correctamente", "Deporte", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposdeDeportes(false);
                    ActualizarTablaDeportes();
                    PonerBotonesDeportesEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Deporte no se pudo actualizar", "Deporte", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
        }

        private void btnDeportesCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposdeDeportes(false);
            PonerBotonesDeportesEdicion(false);
        }

        private void btnDeportesEliminar_Click(object sender, RoutedEventArgs e)
        {

            if (dtgDeportes.SelectedItem != null)

            {
                CateDeportes cate = dtgDeportes.SelectedItem as CateDeportes;
                if (MessageBox.Show("Realmente quieres Eliminar este Deporte?", "Deporte", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorDeportes.Eliminar(cate.Id);
                    ActualizarTablaDeportes();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEquipoNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposdeEquipo(true);
            PonerBotonesEquipoEdicion(true);
            accionEquipo = accion.Nuevo;
        }

        private void btnEquipoEditar_Click(object sender, RoutedEventArgs e)
        {
            Equipo equi = dtgEquipos.SelectedItem as Equipo;
            if (equi != null)
            {
                PonerBotonesEquipoEdicion(true);
                LimpiarCamposdeEquipo(true);
                txbEquipoNombre.Text = equi.Nombre;
                cmbEquipoDeporte.Text = equi.Deporte;
                accionEquipo = accion.Editar;

            }
        }

        private void btnEquipoGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbEquipoNombre.Text))
            {
                MessageBox.Show("Faltan Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (accionEquipo == accion.Nuevo)
            {
                Equipo equi = new Equipo();

                equi.Nombre = txbEquipoNombre.Text;
                equi.Deporte = cmbEquipoDeporte.Text;


                if (manejadorEquipo.Agregar(equi))
                {
                    MessageBox.Show("Equipo agregado correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposdeEquipo(false);
                    ActualizarTablaEquipo();
                    PonerBotonesEquipoEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Equipo no se pudo agregar", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                Equipo equi = dtgEquipos.SelectedItem as Equipo;
                equi.Nombre = txbEquipoNombre.Text;
                equi.Deporte = cmbEquipoDeporte.Text;

                if (manejadorEquipo.Modificar(equi))
                {
                    MessageBox.Show("Equipo modificado correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposdeEquipo(false);
                    ActualizarTablaEquipo();
                    PonerBotonesEquipoEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Equipo no se pudo actualizar", "Equipo", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
        }

        private void btnEquipoCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposdeEquipo(false);
            PonerBotonesEquipoEdicion(false);
        }

        private void btnEquipoEliminar_Click(object sender, RoutedEventArgs e)
        {

            if (dtgEquipos.SelectedItem != null)
            {
                Equipo equi = dtgEquipos.SelectedItem as Equipo;
                if (MessageBox.Show("Realmente quieres Eliminar este Equipo?", "Deportes", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEquipo.Eliminar(equi.Id))
                    {
                        MessageBox.Show("Equipo eliminado", "Deportes", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEquipo();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el Equipo lo siento", "Equipo", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
            }
        }

        private void btnUsuarioNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposdeUsuario();
            PonerBotonesUsuarioEdicion(true);
            accionUsuario = accion.Nuevo;
        }

        private void btnUsuarioEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUsuario.SelectedItem != null)
            {

                Usuario usua = dtgUsuario.SelectedItem as Usuario;


                txbUsuarioId.Text = usua.Id.ToString();
                txbUsuarioNombre.Text = usua.UsuarioNombre;
                txbUsuarioApellidos.Text = usua.Apellidos;
                txbUsuarioDireccion.Text = usua.Direccion;
                txbUsuarioContraseña.Password = usua.Contraseña;

                accionUsuario = accion.Editar;
                PonerBotonesUsuarioEdicion(true);
            }
            else
            {
                MessageBox.Show("No selecciono  ni un elemento de la tabla de los ususarios", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUsuarioGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbUsuarioNombre.Text) || string.IsNullOrEmpty(txbUsuarioApellidos.Text) || string.IsNullOrEmpty(txbUsuarioDireccion.Text) || string.IsNullOrEmpty(txbUsuarioContraseña.Password))
            {
                MessageBox.Show("Faltan Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (accionUsuario == accion.Nuevo)
            {
                Usuario usua = new Usuario()
                {
                    UsuarioNombre = txbUsuarioNombre.Text,
                    Apellidos = txbUsuarioApellidos.Text,
                    Direccion = txbUsuarioDireccion.Text,
                    Contraseña = txbUsuarioContraseña.Password

                };
                manejadorUsuario.Agregar(usua);
                ActualizarTablaUsuario();
                LimpiarCamposdeUsuario();
                PonerBotonesUsuarioEdicion(false);
            }
            else
            {
                Usuario usua = dtgUsuario.SelectedItem as Usuario;
                usua.UsuarioNombre = txbUsuarioNombre.Text;
                usua.Apellidos = txbUsuarioApellidos.Text;
                usua.Direccion = txbUsuarioDireccion.Text;
                usua.Contraseña = txbUsuarioContraseña.Password;
                if (manejadorUsuario.Modificar(usua))
                {
                    ActualizarTablaUsuario();
                    LimpiarCamposdeUsuario();
                    PonerBotonesUsuarioEdicion(false);
                    MessageBox.Show("Usuario editado correctamente", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se puedo editar correctamente el usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnUsuarioCancelar_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta seguro de que  desea cancelar esta operacion", "Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                LimpiarCamposdeUsuario();
                PonerBotonesUsuarioEdicion(false);
            }
        }

        private void btnUsuarioEliminar_Click_1(object sender, RoutedEventArgs e)
        {
            Usuario a = dtgUsuario.SelectedItem as Usuario;
            if (a != null)
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar el usuario: " + a.UsuarioNombre, "Eliminar Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorUsuario.Eliminar(a.Id);
                    ActualizarTablaUsuario();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Usuarios", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnTorneoNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposdeTorneo(true);
            //PonerBotonesTorneoEdicion(true);
            torneoo = new List<Torneo>();
        }

        public void PrimerEquipoTorneo()
        {
            int contador = 0;
            Aleatorios a = new Aleatorios();
            foreach (var item in lista1)
            {
                contador++;
                if (contador == 1)
                {
                    equipoA = item.datos;
                    a.datos = item.datos;
                    lista1.Remove(item);
                    lista2.Add(a);
                    break;
                }
            }

        }
        private void SegundoEquipotorneoImpar()
        {
            if (lista1.Count >= 1)
            {
                Random r = new Random();
                int val = r.Next(1, lista1.Count);
                int contador = 0;

                foreach (var item2 in lista1)
                {
                    contador++;

                    if (contador == val)
                    {
                        equipoB = item2.datos;
                        lista1.Remove(item2);
                        break;
                    }
                }
            }
        }
        private void AgregarListaNumerosImpares(string palabra)
        {
            PrimerEquipoTorneo();
            SegundoEquipotorneoImpar();
            Torneo a = new Torneo()
            {
                EquipoA = equipoA,
                EquipoB = equipoB,
                MarcadorA = 0,
                MarcadorB = 0,
                Deporte = palabra,
                fechaDeJuego = txbTorneoFecha.Text,
            };
            torneoo.Add(a);
            manejadorTorneo.Agregar(a);
            dtgTorneo.ItemsSource = null;
            dtgTorneo.ItemsSource = manejadorTorneo.Listar;
        }



        private void btnTorneoCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la operación?", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ActualizarTablaTorneo();
                LimpiarCamposdeTorneo(false);
                //PonerBotonesTorneoEdicion(false);
            }

        }

        private void btnTorneoEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgTorneo.SelectedItem != null)
            {
                Torneo a = dtgTorneo.SelectedItem as Torneo;
                if (MessageBox.Show("Esta realmente seguro de eliminar los equipos: " + a.EquipoA + " & " + a.EquipoB, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorTorneo.Eliminar(a.Id))
                    {
                        MessageBox.Show("Equipos eliminados", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaTorneo();
                    }
                    else
                    {
                        MessageBox.Show("No se puedo eliminar el los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla para eliminar\nSeleccione uno", "Torneo Eliminación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnTorneoOrdenar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTorneoDeporte.SelectedItem == null)
            {
                MessageBox.Show("Error.... Por favor selecciona un deporte!!!", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string pal = cmbTorneoDeporte.Text;
            if (manejadorEquipo.ContadorDeBuscarEquipo(pal) <= 1)
            {
                MessageBox.Show("No se puede realizar los torneos con un solo equipo\nAgregue más equipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(txbTorneoFecha.Text))
            {
                MessageBox.Show("Agregue la fecha programada del torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorEquipo.Listar)
            {
                if (item.Deporte == pal)
                {
                    Aleatorios equi = new Aleatorios();
                    equi.datos = item.Nombre;
                    lista1.Add(equi);
                }
            }


            if (lista1.Count % 2 == 0)
            {
                while (((lista1.Count) / 2) > 0)
                {
                    AgregarListaNumerosImpares(pal);
                }
            }
            else
            {
                while (((lista1.Count) / 2) > 0)
                {
                    AgregarListaNumerosImpares(pal);
                }
                UltimoElemntoRestante(pal);
            }


            LimpiarCamposdeTorneo(false);
            //PonerBotonesTorneoEdicion(false);


        }

        private void UltimoElemntoRestante(string pal)
        {
            PrimerEquipoTorneo();
            if (lista1.Count >= 1)
            {
                Random r = new Random();
                int val = r.Next(2, lista2.Count);
                int contador = 0;

                foreach (var item2 in lista2)
                {
                    contador++;

                    if (contador == val)
                    {
                        equipoB = item2.datos;
                        break;
                    }
                }
            }
            Torneo a = new Torneo()
            {
                EquipoA = equipoA,
                EquipoB = equipoB,
                Deporte = pal,
                MarcadorA = 0,
                MarcadorB = 0,
                fechaDeJuego = txbTorneoFecha.Text,
            };
            torneoo.Add(a);
            manejadorTorneo.Agregar(a);
            dtgTorneo.ItemsSource = null;
            dtgTorneo.ItemsSource = manejadorTorneo.Listar;

        }

        private void btnPuntuacionBuscarInfo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPuntuacionDeporte.Text))
            {
                MessageBox.Show("Por favor selecciona un Deporte", "Puntos Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbPuntuacionFecha.Text))
            {
                MessageBox.Show("Por favor selecciona la fecha del Juego", "Puntos Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<Puntos> tipo = new List<Puntos>();
            if (cmbPuntuacionDeporte.SelectedItem != null)
            {
                foreach (var item in manejadorTorneo.Listar)
                {
                    if (item.Deporte == cmbPuntuacionDeporte.Text && item.fechaDeJuego == txbPuntuacionFecha.Text)
                    {
                        Puntos TipoPuntosTemporal = new Puntos()
                        {
                            EquipoA = item.EquipoA,
                            EquipoB = item.EquipoB,
                            Deportes = item.Deporte,
                            FechaDeJuego = item.fechaDeJuego,
                            Id = item.Id.ToString(),
                            MarcadorA = item.MarcadorA,
                            MarcadorB = item.MarcadorB,

                        };
                        tipo.Add(TipoPuntosTemporal);
                    }
                }
                dtgPuntuacion.ItemsSource = null;
                dtgPuntuacion.ItemsSource = tipo;
            }
            else
            {
                MessageBox.Show("Error hubo un problema", "Puntuacion Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPuntuacionCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Realmente quieres  cancelar la operación?", "Puntuacion Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ActualizarTablaPuntuacion();
                LimpiarCamposPuntuacion();
            }

        }

        private void btnPuntuacionEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPuntuacion.SelectedItem != null)
            {
                Torneo a = dtgPuntuacion.SelectedItem as Torneo;
                if (a != null)
                {
                    if (MessageBox.Show("Esta  seguro de eliminar los equipos: " + a.EquipoA + " & " + a.EquipoB, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (manejadorTorneo.Eliminar(a.Id))
                        {
                            MessageBox.Show("Equipos eliminados", "Puntuacion Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTablaPuntuacion();
                            LimpiarCamposPuntuacion();
                        }
                        else
                        {
                            MessageBox.Show("Error lo siento no se puede eliminar los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        {
                            Puntos b = dtgPuntuacion.SelectedItem as Puntos;
                            foreach (var item in manejadorTorneo.Listar)
                            {
                                if (b.Id == item.Id.ToString()) 
                                {
                                    if (MessageBox.Show("Esta  seguro de eliminar a los equipos: " + item.EquipoA + " & " + item.EquipoB, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        if (manejadorTorneo.Eliminar(item.Id))
                                        {
                                            MessageBox.Show("Equipos eliminados", "Puntuacion Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                                            ActualizarTablaPuntuacion();
                                            LimpiarCamposPuntuacion();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error lo siento nno se pudo eliminar  los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erro seleccione un elemento de la tabla", "Puntuacion Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void dtgPuntuacion_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgPuntuacion.SelectedItem != null)
            {
                Torneo a = dtgPuntuacion.SelectedItem as Torneo;
                if (a != null)
                {
                    txbPuntuacionId.Text = a.Id.ToString();
                    txbPuntuacionEquipoA.Text = a.EquipoA;
                    txbPuntuacionEquipoB.Text = a.EquipoB;
                    txbPuntuacionMarcadorA.Text = a.MarcadorA.ToString();
                    txbPuntuacionMarcadorB.Text = a.MarcadorB.ToString();
                }
                else
                {
                    Puntos b = dtgPuntuacion.SelectedItem as Puntos;
                    foreach (var item in manejadorTorneo.Listar)
                    {
                        if (b.Id == item.Id.ToString())
                        {
                            txbPuntuacionId.Text = item.Id.ToString();
                            txbPuntuacionEquipoA.Text = item.EquipoA;
                            txbPuntuacionEquipoB.Text = item.EquipoB;
                            txbPuntuacionMarcadorA.Text = item.MarcadorA.ToString();
                            txbPuntuacionMarcadorB.Text = item.MarcadorB.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lo siento  selecciona un elemento de la tabla", "Puntuacion Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPuntuacionEditar_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbPuntuacionId.Text))
            {
                MessageBox.Show("Error no Por favor  seleccione un campo de la tabla para actualizar", "Puntuacion Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (manejadorTorneo.VerificarSiEsNumero(txbPuntuacionMarcadorA.Text) == 1)
            {
                MessageBox.Show("Error no puede ingresar  letras, solo numeros en el Marcador A ", "Puntuacion Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (manejadorTorneo.VerificarSiEsNumero(txbPuntuacionMarcadorB.Text) == 1)
            {
                MessageBox.Show("Error se pueden ingresar letras, solo numeros en Marcador B", "Puntuacion Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int equiA = 0;
            int equiB = 0;
            if (int.Parse(txbPuntuacionMarcadorA.Text) > int.Parse(txbPuntuacionMarcadorB.Text))
            {
                equiA = 3;
                equiB = 1;
            }
            if (int.Parse(txbPuntuacionMarcadorA.Text) < int.Parse(txbPuntuacionMarcadorB.Text))
            {
                equiA = 1;
                equiB = 3;
            }
            if (int.Parse(txbPuntuacionMarcadorA.Text) == int.Parse(txbPuntuacionMarcadorB.Text))
            {
                equiA = 2;
                equiB = 2;
            }
            foreach (var item in manejadorTorneo.Listar)
            {
                if (item.Id.ToString() == txbPuntuacionId.Text.ToString())
                {
                    item.EquipoA = txbPuntuacionEquipoA.Text;
                    item.EquipoB = txbPuntuacionEquipoB.Text;
                    item.MarcadorA = equiA;
                    item.MarcadorB = equiB;
                    if (manejadorTorneo.Modificar(item))
                    {
                        ActualizarTablaPuntuacion();
                        LimpiarCamposPuntuacion();
                        MessageBox.Show("El torneo se editado de manera  correcta", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lo siento no se pudo editar correctamente el Torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }

        }
    }
}
