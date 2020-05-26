using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Rest_Los_Santos
{
    public partial class UsuarioUC : UserControl
    {
        private string usuarioAct = "";
        public UsuarioUC(string usuarioAct)
        {
            this.usuarioAct = usuarioAct;
            InitializeComponent();
        }

        private void UsuarioUC_Load(object sender, EventArgs e)
        {
            var nam = ConnectionBD.ExecuteQuery("SELECT nombre FROM inventario");
            var namcombo = new List<string>();

            foreach (DataRow row in nam.Rows)
            {
                namcombo.Add(row[0].ToString());
            }

            comboBox2.DataSource = namcombo;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Inserte la cantidad de pedidos");
                }
                else
                {
                    var actstock = ConnectionBD.ExecuteQuery("SELECT stock FROM inventario " +
                                                             $"WHERE nombre ='{comboBox2.SelectedItem}");

                    var idArtic = ConnectionBD.ExecuteQuery("SELECT idarticulo FROM inventario " +
                                                            $"WHERE nombre = '{comboBox2.SelectedItem}");

                    var newstock = actstock.Rows[0];
                    var newId = idArtic.Rows[0];

                    int actStock2 = Convert.ToInt32(newstock[0].ToString());
                    int newcant = Convert.ToInt32(textBox1.Text);
                    int tot = actStock2 - newcant;
                    string Nonquery = "";

                    Nonquery = "INSERT INTO pedidos(usuario,idarticulo,stock) " +
                               $"VALUES ('{usuarioAct}',{Convert.ToInt32(newId[0].ToString())},{newcant}";
                    ConnectionBD.ExecuteNonquery(Nonquery);

                    if (tot >= 0 && newcant > 0)
                    {
                        ConnectionBD.ExecuteNonquery("UPDATE INVENTARIO " +
                                                     $"SET stock = {tot} " +
                                                     $"WHERE nombre = '{comboBox2.SelectedItem}'");
                    }

                    MessageBox.Show("Pedido Hecho");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 win = new Form1();
            tabControl1.Controls.Clear();
            tabControl1.Controls.Add(win);
        }
    }
}