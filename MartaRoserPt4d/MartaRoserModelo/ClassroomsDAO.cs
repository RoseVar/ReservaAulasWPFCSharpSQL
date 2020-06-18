using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartaRoserModelo
{
    public class ClassroomsDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;

        public ClassroomsDAO()
        {
                dbConnect = DBConnection.getInstance();
         }

        public List<Classroom> listAllDisponibilities()
        {
            List<Classroom> listResult = null;
            String query = "SELECT disponibilidades.Aula, franjas.DiaSemana, franjas.FranjaHoraria, aulas.Descripcion " +
                "FROM((disponibilidades INNER JOIN aulas ON disponibilidades.Aula = aulas.Nombre)" +
                "INNER JOIN franjas ON disponibilidades.IdFranja = franjas.FranjaId) " +
                "ORDER BY disponibilidades.Aula, franjas.FranjaId;";
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
                            listResult = new List<Classroom>();
                            while (reader.Read())
                            {
                                String provName = reader.GetString(0);
                                String provDay = reader.GetString(1);
                                String provSchudle = reader.GetString(2);
                                String provDescription= reader.GetString(3);
                                Classroom provClassroom = new Classroom(provName, provDay, provSchudle, provDescription);
                                listResult.Add(provClassroom);
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

        public bool checkDisponibility(string[] datosAula, DateTime dayReservation)
        {
            Boolean result = false;
            String query = "SELECT `Aula`, `Fecha`, `Franja`, `User` FROM `reservas` WHERE `Aula`=@aulaNombre " +
                "AND `Fecha`=@fecha AND `Franja`= (SELECT `FranjaId` FROM `franjas` WHERE `DiaSemana`= @dia " +
                "AND `FranjaHoraria`= @franja);";
            
            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        int dia = dayReservation.Day;
                        int mes = dayReservation.Month;
                        int anno = dayReservation.Year;
                        DateTime fechaSQL = new DateTime(anno, mes, dia);

                        cmd.Parameters.Add(new MySqlParameter("@aulaNombre", datosAula[0]));
                        cmd.Parameters.Add(new MySqlParameter("@fecha", fechaSQL));
                        cmd.Parameters.Add(new MySqlParameter("@dia", datosAula[1]));
                        cmd.Parameters.Add(new MySqlParameter("@franja", datosAula[2]));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            result = false;
                        } else
                        {
                            result = true;
                        }

                        reader.Close();

                    }

                }
            }
            catch (MySqlException error1)
            {
                result = false; 
            }
            catch (Exception error2)
            {
                result = false; 
            }
            return result;
        }

        public bool makeReservation(string[] datosAula, DateTime dayReservation, Users user)
        {
            Boolean control= false;
            String query = "INSERT INTO `reservas`(`Aula`, `Fecha`, `Franja`, `User`) VALUES (@nombreAula, @fecha, " +
                "(SELECT `FranjaId` FROM `franjas` WHERE `DiaSemana`= @dia AND `FranjaHoraria`= @franja), @usuario);";
            try
            {
                con = dbConnect.getConnection();

                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        int dia = dayReservation.Day;
                        int mes = dayReservation.Month;
                        int anno = dayReservation.Year;
                        DateTime fechaSQL = new DateTime(anno, mes, dia);

                        cmd.Parameters.Add(new MySqlParameter("@nombreAula", datosAula[0]));
                        cmd.Parameters.Add(new MySqlParameter("@fecha", fechaSQL));
                        cmd.Parameters.Add(new MySqlParameter("@dia", datosAula[1]));
                        cmd.Parameters.Add(new MySqlParameter("@franja", datosAula[2]));
                        cmd.Parameters.Add(new MySqlParameter("@usuario", user.Username));
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
            return control;
        }
    }
}
