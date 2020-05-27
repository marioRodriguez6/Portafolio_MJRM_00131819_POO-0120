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
            try
            {
                var nam = ConnectionBD.ExecuteQuery("SELECT nombre FROM inventario");
                var namcombo = new List<string>();

                foreach (DataRow row in nam.Rows)
                    namcombo.Add(row[0].ToString());

                comboBox2.DataSource = namcombo;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
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
                                                             $"WHERE nombre ='{comboBox2.SelectedItem}'");

                    var idArtic = ConnectionBD.ExecuteQuery("SELECT idarticulos FROM inventario " + 
                                                            $"WHERE nombre = '{comboBox2.SelectedItem}'");

                    var newstock = actstock.Rows[0];    //50
                    var newId = idArtic.Rows[0];        //3

                    int actStock2 = Convert.ToInt32(newstock[0].ToString()); //50
                    int newcant = Convert.ToInt32(textBox1.Text); //5
                    int tot = actStock2 - newcant; //50 - 5 
                    string Nonquery = "";

                    Nonquery = "INSERT INTO pedidos(usuario,idarticulos,stock) " +
                               $"VALUES('{usuarioAct}','{Convert.ToInt32(newId[0].ToString())}','{newcant}')";
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
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT * FROM PEDIDOS " +
                               string.Format("WHERE usuario='{0}'", usuarioAct);
                
                var art = ConnectionBD.ExecuteQuery("SELECT nombre FROM INVENTARIO");
                var dataPedidos = ConnectionBD.ExecuteQuery(Query);
                var artCombo = new List<string>();
                
                foreach (DataRow row in art.Rows)
                    artCombo.Add(row[0].ToString());
                
                comboBox2.DataSource = artCombo;
                dataGridView1.DataSource = dataPedidos;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnBackUUC_Click(object sender, EventArgs e)
        {
            
        }
    }
}