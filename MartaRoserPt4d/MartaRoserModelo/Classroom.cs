using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartaRoserModelo
{
    public class Classroom
    {
        //Atributos
        private string classroomName;
        private string day;
        private string schedule;
        private string description;

        public string ClassroomName { get => classroomName; set => classroomName = value; }
        public string Day { get => day; set => day = value; }
        public string Schedule { get => schedule; set => schedule = value; }
        public string Description { get => description; set => description = value; }

        public Classroom(string classroomName, string day, string schedule, string description)
        {
            this.classroomName = classroomName;
            this.day = day;
            this.schedule = schedule;
            this.description = description;
        }

        public override string ToString()
        {
            return "Nombre aula: " + classroomName + ", Dia: " + day + ", Franja: " + schedule + ", Descripción: "+ description + ".";
        }
    }
}
