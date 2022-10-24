using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_Salons
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login MonFormLogin = new Login();
            MonFormLogin.ShowDialog();
            if (MonFormLogin.DialogResult == DialogResult.OK)
            {
                string TypedeCO = MonFormLogin.TypedeCO;
                int NiveauUtilisateur = MonFormLogin.LevelUtilisateur;
                int IdNomUtilisateur = MonFormLogin.IdUtilisateur;
                MonFormLogin.Close();
                Application.Run(new Form1(NiveauUtilisateur, IdNomUtilisateur, TypedeCO));
            }
            else
                MonFormLogin.Close();
            MessageBox.Show("Au revoir");
            //Application.Run(new MonFormLogin());
            //Application.Run(new Form());
        }
    }
}
