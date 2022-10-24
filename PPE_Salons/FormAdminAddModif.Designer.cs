namespace PPE_Salons
{
    partial class FormAdminAddModif
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtMDP = new System.Windows.Forms.TextBox();
            this.txtLVL = new System.Windows.Forms.TextBox();
            this.labelNom = new System.Windows.Forms.Label();
            this.labelMDP = new System.Windows.Forms.Label();
            this.labelLVL = new System.Windows.Forms.Label();
            this.buttonADD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(273, 132);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(317, 20);
            this.txtNom.TabIndex = 0;
            // 
            // txtMDP
            // 
            this.txtMDP.Location = new System.Drawing.Point(273, 188);
            this.txtMDP.Name = "txtMDP";
            this.txtMDP.Size = new System.Drawing.Size(317, 20);
            this.txtMDP.TabIndex = 1;
            // 
            // txtLVL
            // 
            this.txtLVL.Location = new System.Drawing.Point(273, 247);
            this.txtLVL.Name = "txtLVL";
            this.txtLVL.Size = new System.Drawing.Size(317, 20);
            this.txtLVL.TabIndex = 2;
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Location = new System.Drawing.Point(196, 136);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(29, 13);
            this.labelNom.TabIndex = 3;
            this.labelNom.Text = "Nom";
            // 
            // labelMDP
            // 
            this.labelMDP.AutoSize = true;
            this.labelMDP.Location = new System.Drawing.Point(178, 191);
            this.labelMDP.Name = "labelMDP";
            this.labelMDP.Size = new System.Drawing.Size(71, 13);
            this.labelMDP.TabIndex = 4;
            this.labelMDP.Text = "Mot de passe";
            // 
            // labelLVL
            // 
            this.labelLVL.AutoSize = true;
            this.labelLVL.Location = new System.Drawing.Point(196, 250);
            this.labelLVL.Name = "labelLVL";
            this.labelLVL.Size = new System.Drawing.Size(41, 13);
            this.labelLVL.TabIndex = 5;
            this.labelLVL.Text = "Niveau";
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(338, 319);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(139, 32);
            this.buttonADD.TabIndex = 6;
            this.buttonADD.Text = "Ajouter ";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // FormAdminAddModif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.labelLVL);
            this.Controls.Add(this.labelMDP);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.txtLVL);
            this.Controls.Add(this.txtMDP);
            this.Controls.Add(this.txtNom);
            this.Name = "FormAdminAddModif";
            this.Text = "FormAdminAddModif";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtMDP;
        private System.Windows.Forms.TextBox txtLVL;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelMDP;
        private System.Windows.Forms.Label labelLVL;
        private System.Windows.Forms.Button buttonADD;
    }
}