using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PPE_Salons
{
    public partial class FormAdminAddModif : Form
    {
        public string TypedeCO;
        Utilisateur User; 
        public FormAdminAddModif(string LaCon, Utilisateur UnUtilisateur)
        {
            User = UnUtilisateur;
            TypedeCO = LaCon;
            InitializeComponent();
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            string NomUser = "";
            string MDPUser = "";
            int lvlUser;
            NomUser = txtNom.Text;
            MDPUser = SHA.petitsha(txtMDP.Text);
            lvlUser = int.Parse(txtLVL.Text);
            int ResultatQuery;
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
                    String sqlString = "CreeUser";
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne

                    cmd.Parameters.Add("@Nom", MySqlDbType.VarChar);
                    cmd.Parameters["@Nom"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Nom"].Value = NomUser;
                    cmd.Parameters.Add("@LePass", MySqlDbType.Text);
                    cmd.Parameters["@LePass"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@LePass"].Value = MDPUser;

                    cmd.Parameters.Add("@Niveau", MySqlDbType.Int32);
                    cmd.Parameters["@Niveau"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Niveau"].Value = lvlUser;

                    cmd.Parameters.Add("@UserCree", MySqlDbType.Int32);
                    cmd.Parameters["@UserCree"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    ResultatQuery = (int)cmd.Parameters["@UserCree"].Value;

                    if (ResultatQuery == 1) 
                    {MessageBox.Show("Réussi");}
                    else { MessageBox.Show("Réussi"); }
                }
                dbCon.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
    }
    }
}
