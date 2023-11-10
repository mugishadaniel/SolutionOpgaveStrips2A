
using StripsBL.Interfaces;
using StripsBL.Model;
using StripsDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Repositories
{
    public class StripsRepository : IStripsRepository
    {
        private string connectionString;

        public StripsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Reeks GeefReeks(int id)
        {
            string query = "SELECT t1.*,t2.id AS stripID,t2.Nr AS nr, t2.Titel FROM Reeks t1 INNER JOIN Strip t2 ON t1.id = t2.Reeks WHERE t1.id = @id;";
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@id", id);
                    IDataReader reader = command.ExecuteReader();

                    List<Strip> strips = new List<Strip>();
                    Reeks reeks = null;

                    while (reader.Read())
                    {
                        if (reeks == null)
                        {
                            reeks = new Reeks((int)reader["ID"], (string)reader["Naam"]);
                        }
                        //handle if the nr strip property is null
                        if (reader["nr"] == DBNull.Value)
                        {
                            strips.Add(new Strip((int)reader["stripID"], (string)reader["Titel"], null));
                        }
                        else
                        {
                            strips.Add(new Strip((int)reader["stripID"], (string)reader["Titel"], (int)reader["nr"]));
                        }
                        
                    }

                    reader.Close();

                    if (reeks != null)
                    {
                        reeks.Strips = strips; // Assuming you have a property Strips in your Reeks class to set the list of strips.
                        return reeks;
                    }
                    else
                    {
                        return null; // Or handle the case where no rows were found for the given id.
                    }
                }
                catch (Exception ex)
                {
                    throw new StripsRepositoryException("GeefReeks", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}
