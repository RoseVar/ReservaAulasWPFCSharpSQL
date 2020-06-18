using MartaRoserModelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartaRoserController
{
    public class UsersController
    {
        private UsersDAO model;
        public UsersController()
        {
            model = new UsersDAO();
        }

        public Users validate(string username, string password)
        {
            Users userProv = null;
            Users u = new Users(username, password);

            userProv = model.login(u);

            return userProv;
        }

        public Users searchUserByName (string username)
        {
            Users prov = null;
            prov = model.findUser(new Users(username));
            return prov;
        }

        public bool addUser(Users myUser)
        {
            Boolean control = false;
            control = model.addUser(myUser);
            return control; 
        }

        public List<Users> getAllUsers()
        {
            List<Users> prov = null;
            prov = model.listAllUsers();
            return prov;
        }

        public bool updateUser(Users prov)
        {
            Boolean control = false;
            control = model.updateUser(prov);
            return control;
        }

        public bool deleteUser(Users prov)
        {
            Boolean control = false;
            control = model.deleteUser(prov);
            return control;
        }
    }
}
