using MartaRoserController;
using MartaRoserModelo;
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

namespace MartaRoserPt4dReservaSala
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UsersController userController;
        private ClassroomsController classController;
        private Users myUser;
        public MainWindow()
        {
            InitializeComponent();
            userController = new UsersController();
            classController = new ClassroomsController();
        }



        private void validate(object sender, RoutedEventArgs e)
        {
            //username es el nombre de mi textbox 
            //password es el nombre de mi textbox 
            String user = usuari.Text;
            String pass = contrasenya.Password;

            if (user.Equals("") || pass.Equals(""))
            {

                lb3.Content = "Username or password are empty! Please, introduce your credentials.";
            }
            else
            {

                myUser= userController.validate(user, pass);

                if (myUser==null)
                {
                    lb3.Content= "Users or password are incorrect";
                    cleanFields();
                }
                else if ("admin".Equals(myUser.Rol))
                {
                    AdminWindow menuAdmin = new AdminWindow(userController);
                    menuAdmin.ShowDialog();
                }
                else if ("teacher".Equals(myUser.Rol))
                {
                    TeacherWindow menuTeacher = new TeacherWindow(classController, myUser);
                    menuTeacher.ShowDialog();
                }



            }
        }

        private void cleanFields()
        {
            usuari.Text = "";
            contrasenya.Password = "";

        }
    }
}