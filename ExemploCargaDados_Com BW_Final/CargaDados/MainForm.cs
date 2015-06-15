using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace CargaDados
{
    public partial class MainForm : Form
    {
        private const int numRegistros = 100000;

        public MainForm()
        {
            InitializeComponent();
        }

        private void cargaDadosBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            #region ... Conexão e comandos ...
            var cn = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;
                    Initial Catalog=LAB_BD;
                    Integrated Security=True");

            var cmdPreparacao = new SqlCommand(
                "DELETE FROM CLIENTES; DBCC CHECKIDENT (CLIENTES, RESEED, 0)",
                cn);

            var cmdCarga = new SqlCommand(
                "INSERT INTO CLIENTES (NOME,TELEFONE) VALUES (@NOME,@TELEFONE)",
                cn);
            cmdCarga.Parameters.Add("@NOME", SqlDbType.VarChar);
            cmdCarga.Parameters.Add("@TELEFONE", SqlDbType.VarChar); 
            #endregion

            try
            {
                cn.Open();
                cmdPreparacao.ExecuteNonQuery();

                var r = new Random();
                for (int i = 1; i <= numRegistros; i++)
                {
                    cmdCarga.Parameters["@NOME"].Value = string.Format("Cliente {0:00000}", i);
                    cmdCarga.Parameters["@TELEFONE"].Value = 
                                    r.Next(minValue: 11111111, maxValue: 100000000);
                    cmdCarga.ExecuteNonQuery();

                    cargaDadosBackgroundWorker.ReportProgress(i);   // numero da inserção!!!!
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = numRegistros;
        }

        private void cargaDadosBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void gravarButton_Click(object sender, EventArgs e)
        {
            gravarButton.Enabled = false;
            gravarButton.Text = "Processando...";
            // Dispara o evento DoWork() do BW
            cargaDadosBackgroundWorker.RunWorkerAsync();
        }

        private void cargaDadosBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gravarButton.Text = "Gravar";
            gravarButton.Enabled = true;
            listarClientesButton.PerformClick();
            MessageBox.Show("Carga de dados concluída!");
        }

        private void listarClientesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var da = new SqlDataAdapter(
                    @"SELECT ID,NOME,TELEFONE FROM CLIENTES ORDER BY ID DESC",
                    @"Data Source=.\SQLEXPRESS;
                    Initial Catalog=LAB_BD;
                    Integrated Security=True");
                var dt = new DataTable();
                da.Fill(dt);

                clientesDataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
