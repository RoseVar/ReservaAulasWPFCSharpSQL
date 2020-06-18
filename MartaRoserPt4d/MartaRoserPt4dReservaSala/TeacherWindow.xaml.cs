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
using MartaRoserController;
using MartaRoserModelo;

namespace MartaRoserPt4dReservaSala
{
    /// <summary>
    /// Lógica de interacción para TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private ClassroomsController myController;
        private DateTime dayReservation;
        private RadioButton aulaSelec;
        private Users userTeacher;
        private string[] datosAula;

        public TeacherWindow(ClassroomsController classController, Users userTeacher)
        {
            myController = classController;
            this.userTeacher = userTeacher;
            InitializeComponent();
            createRadioButtons();
        }

        private void createRadioButtons()
        {
            List<Classroom> provList = null;
            provList = myController.listAllClassrooms();
            if (provList != null)
            {
                foreach (Classroom cla in provList)
                {
                    RadioButton a = new RadioButton();
                    String contenido = cla.ClassroomName + "\t" + cla.Day + "\t" + cla.Schedule + "\t" + cla.Description;
                    a.Content= contenido;
                    a.Checked += (sender, args) =>
                    {
                        aulaSelec= sender as RadioButton;
                        LResultadoReserva.Content = "";
                    };
                    lbAulasReserva.Items.Add(a);
                }
            }
        }

        private void salirMenuAdmin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listarAulas(object sender, RoutedEventArgs e)
        {
            Tblock.Items.Clear();
            List<Classroom> provList = null;
            provList = myController.listAllClassrooms();
            if (provList != null)
            {

                foreach (Classroom cla in provList)
                {
                    Tblock.Items.Add(cla.ToString());
                }
            }
        }

        private void salirMenuTeacher(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void limpiarVistaAulas(object sender, RoutedEventArgs e)
        {
            Tblock.Items.Clear();
        }

        private void btDisponibilidad_Click(object sender, RoutedEventArgs e)
        {
            dayReservation = (DateTime) dtPicker.SelectedDate;
            string diaSemana=null;
            if (dtPicker.SelectedDate != null)
            {
                switch (dtPicker.SelectedDate.Value.Date.DayOfWeek.ToString())
                {
                    case "Monday":
                        diaSemana = "DL";
                        break;
                    case "Tuesday":
                        diaSemana = "DM";
                        break;
                    case "Wednesday":
                        diaSemana = "DC";
                        break;
                    case "Thursday":
                        diaSemana = "DJ";
                        break;
                    case "Friday":
                        diaSemana = "DV";
                        break;
                }
            }

            if (diaSemana!=null)
            {
                if (aulaSelec != null)
                {
                    datosAula = aulaSelec.Content.ToString().Split('\t');
                    string day = datosAula[1];
                    if (diaSemana.Equals(day))
                    {
                        Boolean controlDisp = myController.checkReservation(datosAula, dayReservation);
                        if (controlDisp)
                        {
                            LResultadoReserva.Content = "La clase está disponible. Puedes reservar";
                            LResultadoReserva.Foreground = Brushes.Green;
                        } else
                        {
                            LResultadoReserva.Content = "La clase no está disponible en esa fecha y franja";
                            LResultadoReserva.Foreground = Brushes.Red;
                        }
                    } else
                    {
                        LResultadoReserva.Content = "No coinciden los días de la semana seleccionados";
                        LResultadoReserva.Foreground = Brushes.Red;
                    }
                } else
                {
                    LResultadoReserva.Content = "Has de escoger una opción de aula";
                    LResultadoReserva.Foreground = Brushes.Red;
                }
                
            } else
            {
                LResultadoReserva.Content = "Has de escoger un dia del calendario";
                LResultadoReserva.Foreground = Brushes.Red;

            }

        }

        private void reservar(object sender, RoutedEventArgs e)
        {
            Boolean result = false;
            result = myController.makeReservation(datosAula, dayReservation, userTeacher);
            if (result)
            {
                LResultadoReserva.Content = "Reserva hecha";
                LResultadoReserva.Foreground = Brushes.Green;
            } else
            {
                LResultadoReserva.Content = "No se ha podido hacer la reserva";
                LResultadoReserva.Foreground = Brushes.Red;
            }
        }
    }
}
