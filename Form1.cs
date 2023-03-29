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

namespace Aula1006
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection(
                "Persist Security Info=False; SSLmode = none;"+
                "Server = 127.0.0.1;"+
                "Port=3305;"+
                "Database=dbprojeto;"+
                "Uid = root;"+
                "Pwd = usbw;"
                );
            conexao.Open();
            MySqlCommand sql = new MySqlCommand(
                "SELECT * from tblamigo;", conexao);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexao.Close();
            dgvAmigo.DataSource = dt;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection(
                "Persist Security Info=False; SSLmode = none;" +
                "Server = 127.0.0.1;" +
                "Port=3305;" +
                "Database=dbprojeto;" +
                "Uid = root;" +
                "Pwd = usbw;"
                );
            conexao.Open();
            string comandoSql;
            if (txtCodigo.Text == String.Empty)
            {
                comandoSql =
                    "insert into tblamigo(nome, apelido, email) values" + "('" + txtNome.Text + "','" + txtApelido.Text + "','" + txtEmail.Text + "');";
            }
            else
            {
                comandoSql = "update tblamigo set nome = '" + txtNome.Text + "', apelido = '" + txtApelido.Text + "', email = '"+txtEmail.Text + "' where idAmigo = " + txtCodigo.Text;
            }

            MySqlCommand sql = new MySqlCommand(
                comandoSql, conexao);
            sql.ExecuteNonQuery();
            conexao.Close();
            txtCodigo.Clear();
            txtNome.Clear();
            txtApelido.Clear();
            txtEmail.Clear();
            MessageBox.Show("Salvo com sucesso", "Salvo");
        }



        private void dgvAmigo_DoubleClick(object sender, EventArgs e)
        { 
                txtCodigo.Text =
                    dgvAmigo.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text =
                    dgvAmigo.CurrentRow.Cells[1].Value.ToString();
                txtApelido.Text =
                    dgvAmigo.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text =
                dgvAmigo.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
             if(txtCodigo.Text != String.Empty)
            {
                MySqlConnection conexao = new MySqlConnection(
                "Persist Security Info=False; SSLmode = none;" +
                "Server = 127.0.0.1;" +
                "Port=3305;" +
                "Database=dbprojeto;" +
                "Uid = root;" +
                "Pwd = usbw;"
                );
                conexao.Open();

                MySqlCommand sql = new MySqlCommand("delete from tblamigo " +
                    "where idAmigo = " + txtCodigo.Text, conexao);
                sql.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Excluido com Sucesso", "Excluído");
            }

        }
    }
}
