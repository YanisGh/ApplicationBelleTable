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
    public partial class PageAdmin : Form
    {
        public string TypedeCO;
        public PageAdmin(string LaCon)
        {
            TypedeCO = LaCon;
            InitializeComponent();
        }
        private void PageAdmin_Load(object sender, EventArgs e)
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
                string query = "SELECT id, identifiant, level FROM utilisateur ORDER BY identifiant;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();//Remplissage du curseur
                List<Utilisateur> Utilisateurs = new List<Utilisateur>();
                while (reader.Read())
                {
                    Utilisateur Unutilisateur = new Utilisateur
                    {
                        Id = (int)reader["id"],
                        Identifiant = (string)reader["identifiant"],
                        Level = (int)reader["level"],
                        TypedeCO = TypedeCO

                    };
                    Utilisateurs.Add(Unutilisateur);
                }

                GridAdmin.DataSource = null;
                GridAdmin.DataSource = Utilisateurs;
                GridAdmin.Columns["id"].Visible = false;
                GridAdmin.Columns["identifiant"].HeaderText = "Nom";
                GridAdmin.Columns["identifiant"].Width = 300;
                GridAdmin.Columns["level"].Width = 300;
                GridAdmin.MultiSelect = false;
                GridAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                GridAdmin.ReadOnly = true;
                reader.Close();
                dbCon.Close();
                GridAdmin.Visible = true;

            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Utilisateur Unutilisateur = new Utilisateur();
            FormAdminAddModif FormADD = new FormAdminAddModif(TypedeCO, Unutilisateur);
            FormADD.Show();
        }

        private void buttonModif_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GridAdmin.SelectedRows)
            {
                Utilisateur UnutilisateurModif= row.DataBoundItem as Utilisateur;
                FormAdminAddModif FormADD= new FormAdminAddModif(TypedeCO, UnutilisateurModif);
                FormADD.Show();

            }
        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GridAdmin.SelectedRows)
            {
                Utilisateur UnUtilisateur = row.DataBoundItem as Utilisateur;
                if (UnUtilisateur.Supprimer())
                    MessageBox.Show("Utilisateur Supprimé !");
                // Ici on rafraîchit la liste....
                else
                    MessageBox.Show("Impossible de  Supprimer !");

            }
        }
    }
}
