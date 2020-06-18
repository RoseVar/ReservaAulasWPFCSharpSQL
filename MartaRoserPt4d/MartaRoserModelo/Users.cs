using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartaRoserModelo
{
    public class Users
    {
        //atributs
        private string username;
        private string password;
        private string rol;
        private string mail;

        //propietats
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Mail { get => mail; set => mail = value; }

        public Users(string username, string password, string rol, string mail)
        {
            this.username = username;
            this.password = password;
            this.rol = rol;
            this.mail = mail;
        }

        public Users(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Users (string username)
        {
            this.username = username;
        }

        public override string ToString()
        {
            return "Nombre: " + username + " , Rol: " + rol + " , Email: " + mail + "."; 
        }

    }
}

