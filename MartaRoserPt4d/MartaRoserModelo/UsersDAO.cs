using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartaRoserModelo
{
    public class UsersDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;
        public UsersDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        /// <summary>
        /// Este método me detecta si un usuario está en la tabla users
        /// </summary>
        /// <param name="user">user viene dado por el controlador</param>
        /// <returns></returns>
        public Users login(Users user)
        {
            Users provUser = null;
            String query = "SELECT * FROM users WHERE username=@user AND password=@pass"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@user", user.Username));
                        cmd.Parameters.Add(new MySqlParameter("@pass", user.Password));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String provName = reader.GetString(0);
                                String provPass = reader.GetString(1);
                                String provRol = reader.GetString(2);
                                String provMail = reader.GetString(3);
                                provUser = new Users(provName, provPass, provRol, provMail);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found in login - UserDAO.");
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException error1)
            {
                Console.WriteLine("Error MySql en el login d'UserDAO: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en el login - UserDAO: " + error2.Message);
            }
            return provUser;

        }

        public bool deleteUser(Users prov)
        {
            Boolean control = false;
            String query = "DELETE from `users` WHERE `UserName`=@nombre"; //la consulta que li fem a la BBDD
            //Si no es teacher, no se puede borrar
            if (prov.Rol.Equals("teacher"))
            {
                try
                {
                    con = dbConnect.getConnection();

                    if (con != null)
                    {
                        con.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@nombre", prov.Username));

                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {
                                control = true;
                            }
                            else
                            {
                                control = false;
                            }

                        }
                    }
                }
                catch (MySqlException error1)
                {
                    control = false;
                }
                catch (Exception error2)
                {
                    control = false;
                }
            } else
            {
                control = false;
            }
            return control;
        }
    

        public bool updateUser(Users prov)
        {
            Boolean control = false;
            String query = "UPDATE `users`  SET `Password`= @pass, `Email`=@mail WHERE `UserName`=@nombre"; //la consulta que li fem a la BBDD
            //Si no es teacher, no se puede modificar
            if (prov.Rol.Equals("teacher"))
            {
                try
                {
                    con = dbConnect.getConnection();

                    if (con != null)
                    {
                        con.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@nombre", prov.Username));
                            cmd.Parameters.Add(new MySqlParameter("@pass", prov.Password));
                            cmd.Parameters.Add(new MySqlParameter("@mail", prov.Mail));
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {
                                control = true;
                            }
                            else
                            {
                                control = false;
                            }

                        }
                    }
                }
                catch (MySqlException error1)
                {
                    control = false;
                }
                catch (Exception error2)
                {
                    control = false;
                }
            } else
            {
                control = false;
                Console.WriteLine(prov.Rol.ToString());
                Console.WriteLine("No es igual a teacher");
            }
            return control;
        }

        public List<Users> listAllUsers()
        {
            List<Users> listResult = null;
            String query = "SELECT * FROM users"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            listResult = new List<Users>();
                            while (reader.Read())
                            {
                                
                                String provName = reader.GetString(0);
                                String provPass = reader.GetString(1);
                                String provRol = reader.GetString(2);
                                String provMail = reader.GetString(3);
                                Console.WriteLine(provName + " " + provPass + " " + provRol + " " + provMail);
                                Users provUser = new Users(provName, provPass, provRol, provMail);
                                listResult.Add(provUser);
                            }
                        }
                        
                        reader.Close();

                    }
                }
            }
            catch (MySqlException error1)
            {
                listResult = null;
            }
            catch (Exception error2)
            {
                listResult = null;
            }
            return listResult;


        }

        public bool addUser(Users myUser)
        {
            Boolean control= false;
            String query = "INSERT INTO `users` (`UserName`, `Password`, `Rol`, `Email`) VALUES (@nombre, @pass, @rol, @mail)"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@nombre", myUser.Username));
                        cmd.Parameters.Add(new MySqlParameter("@pass", myUser.Password));
                        cmd.Parameters.Add(new MySqlParameter("@rol", myUser.Rol));
                        cmd.Parameters.Add(new MySqlParameter("@mail", myUser.Mail));
                        int result = cmd.ExecuteNonQuery();
                        if (result==1)
                        {
                            control = true;
                        }
                        else
                        {
                            control=false;
                        }

                    }
                }
            }
            catch (MySqlException error1)
            {
                control = false;
            }
            catch (Exception error2)
            {
                control = false;
            }
            return control;

        
    }

        public Users findUser(Users user)
    {
        Users provUser= null;
        String query = "SELECT * FROM users WHERE username=@user"; //la consulta que li fem a la BBDD
        try
        {
            con = dbConnect.getConnection();

            if (con != null)
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add(new MySqlParameter("@user", user.Username));
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Console.WriteLine("{0}\t{1}", reader.GetString(0),reader.GetString(1));
                            String provName = reader.GetString(0);
                            String provPass = reader.GetString(1);
                            String provRol = reader.GetString(2);
                            String provMail = reader.GetString(3);
                                provUser = new Users(provName, provPass, provRol, provMail);

                            }
                    }
                    else
                    {
                            provUser = null;
                    }
                    reader.Close();

                }
            }
        }
        catch (MySqlException error1)
        {
                provUser = null;
            }
        catch (Exception error2)
        {
                provUser = null;
            }
        return provUser;

        }
    }
}
