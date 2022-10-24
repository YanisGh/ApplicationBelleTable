using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace PPE_Salons
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Identifiant { get; set; }
        public int Level { get; set; }
        public string TypedeCO { get; set; }
        public bool Supprimer()
        {
            try
            {
                DBConnection dbCon = new DBConnection();
                if (TypedeCO == "Locale")
                {
                    dbCon.Server = "127.0.0.1";
                    dbCon.DatabaseName = "ppe";
                    dbCon.UserName = "root";
                    dbCon.Password = "";
                }
                else
                {
                    dbCon.Server = "ppebelletablecerfal.chaisgxhr4z6.eu-west-3.rds.amazonaws.com";
                    dbCon.DatabaseName = "PPE_Yanis";
                    dbCon.UserName = "admin";
                    dbCon.Password = "renard2020";
                }
                if (dbCon.IsConnect())
                {
                    String sqlString = "DELETE FROM utilisateur  WHERE Id = ?id_P";
                    sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }
    }

}
