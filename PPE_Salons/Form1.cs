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
    public partial class Form1 : Form
    {
        public int LevelUtilisateur;
        public int IdUtilisateur;
        public string TypedeCO;
        public Form1(int LevelNiveau, int LeUser, string LaCon)
        {
            IdUtilisateur = LeUser;
            LevelUtilisateur = LevelNiveau;
            TypedeCO = LaCon;
            InitializeComponent();
            if (LevelUtilisateur != 2)
            {
                buttonAdmin.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                string query = "SELECT Id, Nom, Prenom, Email FROM contact ORDER BY Nom";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();//Remplissage du curseur
                List<Contact> contacts = new List<Contact>();
                while (reader.Read())
                {
                    Contact contact = new Contact
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"],
                        Email = (string)reader["Email"],

                    };
                    contacts.Add(contact);
                }

                MaGrid.DataSource = null;
                MaGrid.DataSource = contacts;
                FormaterListe();
                reader.Close();
                dbCon.Close();
                MaGrid.Visible = true;

            }
            else { MessageBox.Show("Erreur"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MaGrid.SelectedRows)
            {
                Contact UnParticipant = row.DataBoundItem as Contact;
                PageParticipant MonFormParticipant = new PageParticipant(UnParticipant);
                MonFormParticipant.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Contact UnParticipant = new Contact();
            UnParticipant.Id = 0;//Pour être sur qu'il soit inséré
            PageParticipant MonFormParticipant = new PageParticipant(UnParticipant);
            MonFormParticipant.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MaGrid.SelectedRows)
            {
                Contact UnParticipant = row.DataBoundItem as Contact;
                if (UnParticipant.Supprimer())
                    MessageBox.Show("Participant Supprimé !");
                // Ici on rafraîchit la liste....
                else
                    MessageBox.Show("Impossible de  Supprimer !");

            }
        }


        public void FormaterListe()
        {
            MaGrid.Columns["Id"].Visible = false;
            MaGrid.Columns["Nom"].HeaderText = "Nom du participant";
            MaGrid.Columns["Nom"].Width = 150;
            MaGrid.MultiSelect = false;
            MaGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MaGrid.ReadOnly = true;
        }
        private void button5_Click(object sender, EventArgs e)
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
                string query = "SELECT Id, Nom, Prenom, Email FROM contact where Nom =?nom_P ORDER BY Nom";
                query = Tools.PrepareLigne(query, "?nom_P", Tools.PrepareChamp(tbNom.Text, "Chaine"));

                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();//Remplissage du curseur
                List<Contact> contacts = new List<Contact>();
                while (reader.Read())
                {
                    Contact contact = new Contact
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"],
                        Email = (string)reader["Email"],
                        TypedeCO = TypedeCO,
                    };
                    contacts.Add(contact);
                }

                MaGrid.DataSource = null;
                MaGrid.DataSource = contacts;
                FormaterListe();
                reader.Close();
                dbCon.Close();
                MaGrid.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaGrid.Visible = false;
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            PageAdmin FormAdmin = new PageAdmin(TypedeCO);
            FormAdmin.Show();
        }
    }
}