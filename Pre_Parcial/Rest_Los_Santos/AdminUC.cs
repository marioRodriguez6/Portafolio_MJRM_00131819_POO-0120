using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Rest_Los_Santos
{
    public partial class AdminUC : UserControl
    {
        public AdminUC()
        {
            InitializeComponent();
        }
                   
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Equals("") || textBox1.Text.Equals(""))
                MessageBox.Show("Por favor inserta los datos necesarios");
            else
            {
                try
                {
                    string Query = "";
                    if (radioButton1.Checked)
                        Query = $"INSERT " +
                                $"INTO " +
                                $"USUARIO(usuario,contraseña,tipo) VALUES('{textBox9.Text}','{textBox1.Text}',true) ";
                    else
                        Query = $"INSERT " +
                                $"INTO " +
                                $"USUARIO(usuario,contraseña,tipo) VALUES('{textBox9.Text}'," +
                                $"'{textBox1.Text}',false)";
                    
                    ConnectionBD.ExecuteNonquery(Query);
                    
                    MessageBox.Show("Usuario insertado con exito");

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Usuario no ingresado");
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(""))
                MessageBox.Show("Ingrese la nueva contraseña por favor");
            else
            {
                try
                {
                    string Query = $"UPDATE USUARIO SET contraseña= '{textBox3.Text}' WHERE usuario=" +
                                   $"'{comboBox2.SelectedItem}'";
                    
                    ConnectionBD.ExecuteNonquery(Query);
                    
                    if (radioButton1.Checked)
                        Query = "UPDATE USUARIO SET tipo = true WHERE usuario= " +
                                $"'{comboBox2.SelectedItem}'";
                    else
                        Query = "UPDATE USUARIO SET tipo = false WHERE usuario= " +
                                $"'{comboBox2.SelectedItem}'";

                    ConnectionBD.ExecuteNonquery(Query);

                    MessageBox.Show("Se actualizo el usuario");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("No se logro actualizar al usuario");
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string NonQuery = $"DELETE FROM USUARIO WHERE usuario='{comboBox3.SelectedItem}'";
                        try
                        {
                            ConnectionBD.ExecuteNonquery(NonQuery);
                            MessageBox.Show("Usuario eliminado");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Usuario no eliminado");
                        }
        }

        private void AdminUC_Load(object sender, EventArgs e)
        {
            var users = ConnectionBD.ExecuteQuery("SELECT usuario FROM USUARIO");
                        var stocks = ConnectionBD.ExecuteQuery("SELECT nombre FROM INVENTARIO");
                        string Query="SELECT * FROM PEDIDOS";
                        var dt = ConnectionBD.ExecuteQuery(Query);
                        var userCombo = new List<string>();
                        var stocksCombo = new List<string>();
            
                        foreach (DataRow dataRow in users.Rows)
                            userCombo.Add(dataRow[0].ToString());
                        
                        foreach (DataRow dr in stocks.Rows)
                            stocksCombo.Add(dr[0].ToString());
                        
                        comboBox2.DataSource = userCombo;
                        comboBox3.DataSource = userCombo;
                        
                        comboBox6.DataSource = stocksCombo;
                        comboBox5.DataSource = stocksCombo;
            
                        dataGridView1.DataSource = dt;
        }


        private void button6_Click(object sender, EventArgs e) //Agregar Pedido
        {
            if (textBox8.Text.Equals("") ||
                textBox4.Text.Equals("") ||
                textBox5.Text.Equals("") || Convert.ToInt32(textBox5.Text)<0 ||
                textBox6.Text.Equals("") || Convert.ToInt32(textBox6.Text)<0)
                MessageBox.Show("Por favor, rellene los campos correctamente");
            else 
            {
                try
                {
                    int precio = Convert.ToInt32(textBox5.Text);
                    int stock = Convert.ToInt32(textBox6.Text);
                    string query = "";
                    
                    query=
                        "INSERT " +
                        "INTO " +
                        $"INVENTARIO(nombre,descripcion,precio,stock) VALUES('{textBox8.Text}'," +
                        $"'{textBox4.Text}',{precio},{stock}) ";
                    
                    ConnectionBD.ExecuteNonquery(query);
                    
                    MessageBox.Show("Agregado con exito");
                }
                catch (Exception)
                {
                    MessageBox.Show("Inventario no actualizado");
                    throw;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Equals("") || Convert.ToInt32(textBox7.Text)<0)
                MessageBox.Show("Ingresa datos validos");
            else
            {
                try
                {
                    string Query = "";
                    Query = "UPDATE " +
                            "INVENTARIO " +
                            $"SET stock={Convert.ToInt32(textBox7.Text)} WHERE nombre='{comboBox5.SelectedItem}'";

                    ConnectionBD.ExecuteNonquery(Query);
                    
                    MessageBox.Show("Se modifico correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se ha modifico");
                }
            }
        }
        
         private void button8_Click(object sender, EventArgs e)
         {
             string NonQuery = $"DELETE FROM INVENTARIO WHERE nombre='{comboBox6.SelectedItem}'";
             try
             {
                 ConnectionBD.ExecuteNonquery(NonQuery);
                 MessageBox.Show("Producto eliminado");
             }
             catch (Exception exception)
             {
                 MessageBox.Show("Producto no eliminado");
             }
         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             string Query="SELECT * FROM PEDIDOS";
             var dt = ConnectionBD.ExecuteQuery(Query);
             try
             {
                 dataGridView1.DataSource = dt;
             }
             catch (Exception exception)
             {
                 MessageBox.Show("Error");
             }

         }


         private void button1_Click(object sender, EventArgs e)
         {
             string Query="SELECT * FROM PEDIDOS";
             var dt = ConnectionBD.ExecuteQuery(Query);
             try
             {
                 dataGridView1.DataSource = dt;
             }
             catch (Exception exception)
             {
                 MessageBox.Show("Error");
             }
         }
    }
}