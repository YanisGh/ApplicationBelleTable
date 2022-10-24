using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PPE_Salons
{
    public partial class Login : Form
    {
        public int LevelUtilisateur;
        public int IdUtilisateur;
        public string TypedeCO;
        public Login()
        {
            InitializeComponent();
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            string MDP ="";
            TypedeCO = comboBox1.Text;
            MDP = SHA.petitsha(textBoxMDP.Text);
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
                int Identifiant = -1;
                if (dbCon.IsConnect())
                {
                    String sqlString = "ChercherUtilisateur";
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne

                    cmd.Parameters.Add("@NomEntree", MySqlDbType.VarChar);
                    cmd.Parameters["@NomEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NomEntree"].Value = textBoxID.Text;
                    cmd.Parameters.Add("@LePass", MySqlDbType.Text);
                    cmd.Parameters["@LePass"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@LePass"].Value = MDP;

                    cmd.Parameters.Add("@IdSortie", MySqlDbType.Int32);
                    cmd.Parameters["@IdSortie"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@LevelSortie", MySqlDbType.Int32);
                    cmd.Parameters["@LevelSortie"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    Identifiant = (int)cmd.Parameters["@IdSortie"].Value;
                    if (Identifiant > 0)
                    {
                        LevelUtilisateur = (int)cmd.Parameters["@LevelSortie"].Value;
                        dbCon.Close();
                        //labelResponse.Text = "Bienvenue";
                        this.DialogResult = DialogResult.OK;//Modale est validée par OK
                    }
                    else //labelResponse.Text = "Je ne vous connais pas";
                        dbCon.Close();



                }
                dbCon.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Erreur");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
