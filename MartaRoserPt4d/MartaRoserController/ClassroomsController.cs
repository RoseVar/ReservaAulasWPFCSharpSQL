using MartaRoserModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartaRoserController
{
    public class ClassroomsController
    {
        private ClassroomsDAO model;

        public ClassroomsController()
        {
            this.model = new ClassroomsDAO();
        }

        public List<Classroom> listAllClassrooms()
        {
            List<Classroom> prov = null;
            prov = model.listAllDisponibilities();
            return prov;
        }

        public bool checkReservation(string[] datosAula, DateTime dayReservation)
        {
            Boolean control = false;
            control = model.checkDisponibility(datosAula, dayReservation);
            return control;
        }

        public bool makeReservation(string[] datosAula, DateTime dayReservation, Users userTeacher)
        {
            Boolean control = false;
            control = model.makeReservation(datosAula, dayReservation, userTeacher);
            return control;
        }
    }

}
