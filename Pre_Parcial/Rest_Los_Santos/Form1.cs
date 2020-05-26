using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_Los_Santos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var passw = ConnectionBD.ExecuteQuery("SELECT contraseña FROM USUARIO " +
                                                      $"WHERE usuario ='{comboBox1.SelectedItem}'");
                var password2 = passw.Rows[0];
                string passWord = password2[0].ToString();
                
                if (textBox1.Text.Equals(passWord))
                {
                    var ad = ConnectionBD.ExecuteQuery($"SELECT admins FROM USUARIO " +
                                                       $"WHERE usuario='{comboBox1.SelectedItem}'");
                    var adm = ad.Rows[0];
                    bool admin = Convert.ToBoolean(adm[0].ToString());

                    if (admin)
                    {
                        this.Hide();
                        this.Show(new AdminUC());
                    }
                    else
                    {
                        this.Hide();
                        this.Show(new UsuarioUC());
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