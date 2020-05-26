using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Rest_Los_Santos
{
    public partial class Form1 : Form
    {
        private UserControl current;
        private Form1 current2;
        public Form1()
        {
            InitializeComponent();
            current2 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var password = ConnectionBD.ExecuteQuery("SELECT contraseña From usuario " +
                                                         $"WHERE usuario = '{comboBox1.SelectedItem}'");
                var password2 = password.Rows[0];
                string password3 = password2[0].ToString();


                if (textBox1.Text.Equals(password3))
                {
                    var ad = ConnectionBD.ExecuteQuery("SELECT tipo FROM usuario " +
                                                       $"WHERE usuario = '{comboBox1.SelectedItem}'");
                    var adm = ad.Rows[0];
                    bool admin = Convert.ToBoolean(adm[0].ToString());

                    if (admin)
                    {
                       AdminUC win = new AdminUC();
                       tableLayoutPanel1.Controls.Clear();
                       tableLayoutPanel1.Controls.Add(win, 0, 0);
                       tableLayoutPanel1.SetColumnSpan(win, 2);
                       tableLayoutPanel1.SetRowSpan(win,6);
                    }
                    else
                    {
                        UsuarioUC win2 = new UsuarioUC(comboBox1.SelectedItem.ToString());
                        tableLayoutPanel1.Controls.Clear();
                        tableLayoutPanel1.Controls.Add(win2, 0, 0);
                        tableLayoutPanel1.SetColumnSpan(win2, 2);
                        tableLayoutPanel1.SetRowSpan(win2,6);
                        
                        
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var users = ConnectionBD.ExecuteQuery("SELECT usuario FROM USUARIO");
            var usersCombo = new List<string>();

            foreach (DataRow row in users.Rows)
            {
                usersCombo.Add(row[0].ToString());
            }
            comboBox1.DataSource = usersCombo;
        }
    }
}