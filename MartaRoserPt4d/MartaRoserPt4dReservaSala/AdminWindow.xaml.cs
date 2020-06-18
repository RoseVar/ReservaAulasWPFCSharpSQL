using MartaRoserController;
using MartaRoserModelo;
using System;
using System.Collections;
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

namespace MartaRoserPt4dReservaSala
{
    /// <summary>
    /// Lógica de interacción para AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        UsersController myController;
        public AdminWindow(MartaRoserController.UsersController userController)
        {
            myController = userController;
            InitializeComponent();
        }

        private void darDeAltaUsuario(object sender, RoutedEventArgs e)
        {
            String nombre = tbUsername.Text;
            String password = pbPassword.Password;
            String rol = "teacher";
            String mail = tbEmail.Text;

            if (!"".Equals(nombre) & !"".Equals(password) & !"".Equals(mail)) {
                Users prov = myController.searchUserByName(nombre);
                //si usuario no existe, osea devuelve un null
                if (prov==null)
                {
                    Users myUser = new Users(nombre, password, rol, mail);
                    Boolean control = myController.addUser(myUser);
                    if(control){
                        tbvalidacion.Content = "El usuario se ha añadido correctamente.";
                        tbvalidacion.Foreground = Brushes.Green;

                    } else
                    {
                        tbvalidacion.Content = "El usuario no se ha podido añadir.";
                        tbvalidacion.Foreground = Brushes.Red;

                    }
                } else
                {
                    tbvalidacion.Content = "El usuario ya existe. No se puede añadir otra vez.";
                    tbvalidacion.Foreground = Brushes.Red;

                }
            }

        }



        private void ocultarLabelResultado(object sender, TextChangedEventArgs e)
        {
            tbvalidacion.Content = "";
        }

        private void ocultarLabelResultado(object sender, RoutedEventArgs e)
        {
            tbvalidacion.Content = "";
        }

        private void mostrarUsuarios(object sender, RoutedEventArgs e)
        {
            List<Users> provList = null;
            provList = myController.getAllUsers();
            if (provList!=null)
            {
                String result="";

                foreach (Users us in provList)
                {
                    result = result + us.ToString() + "\r\n";
                }
                Tblock.Text = result;
            }

        }

        private void borrarListado(object sender, RoutedEventArgs e)
        {
            Tblock.Text = "";
        }

        private void buscarParaModificar(object sender, RoutedEventArgs e)
        {
            String nombreUsuario = tbBuscaUserModif.Text;
            Users prov = new Users(nombreUsuario);

            Users result = myController.searchUserByName(nombreUsuario);
            if (result!=null)
            {
                tbShowUser.Text = result.Username;
                pbShowPassword.Password = result.Password;
                tbShowRol.Text = result.Rol;
                tbShowEmail.Text = result.Mail;

            } else
            {
                LbResultadoModificar.Content = "Usuario no encontrado";
                LbResultadoModificar.Foreground = Brushes.Red;
            }
        }

        private void guardarUsuarioModificado(object sender, RoutedEventArgs e)
        {
            Users prov = new Users(tbShowUser.Text);
            string nuevaPass = pbShowPassword.Password;
            string rolSinCambios = tbShowRol.Text;
            string nuevoMail = tbShowEmail.Text;
            prov.Password= nuevaPass;
            prov.Mail = nuevoMail;
            prov.Rol = rolSinCambios;
            Boolean control = false;
            control = myController.updateUser(prov);
            if (control)
            {
                LbResultadoModificar.Content = "Usuario modificado correctamente";
                LbResultadoModificar.Foreground = Brushes.Green;
            } else
            {
                LbResultadoModificar.Content = "No se ha podido modificar el usuario";
                LbResultadoModificar.Foreground = Brushes.Red;
            }

        }

        private void buscarParaEliminar(object sender, RoutedEventArgs e)
        {
            String nombreUsuario = tbBuscaUserElim.Text;
            Users prov = new Users(nombreUsuario);

            Users result = myController.searchUserByName(nombreUsuario);
            if (result != null)
            {
                tbShowUserElim.Text = result.Username;               
                tbShowRolElim.Text = result.Rol;
                tbShowEmailElim.Text = result.Mail;

            }
            else
            {
                LbResultadoEliminar.Content = "Usuario no encontrado";
                LbResultadoEliminar.Foreground = Brushes.Red;
            }
        }

        private void eliminarUsuario(object sender, RoutedEventArgs e)
        {
            Users prov = new Users(tbShowUserElim.Text);
            prov.Rol = tbShowRolElim.Text;
            Boolean control = false;
            control = myController.deleteUser(prov);
            if (control)
            {
                LbResultadoEliminar.Content = "Usuario eliminado correctamente";
                LbResultadoEliminar.Foreground = Brushes.Green;
            }
            else
            {
                LbResultadoEliminar.Content = "No se ha podido eliminar el usuario";
                LbResultadoEliminar.Foreground = Brushes.Red;
            }
        }

        private void ocultarLabel(object sender, TextChangedEventArgs e)
        {
            LbResultadoEliminar.Content = "";
            tbShowUserElim.Text = "";
            tbShowRolElim.Text = "";
            tbShowEmailElim.Text = "";

            LbResultadoModificar.Content = "";
            tbShowUser.Text = "";
            pbShowPassword.Password = "";
            tbShowRol.Text = "";
            tbShowEmail.Text = "";

        }

        private void salirMenuAdmin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
