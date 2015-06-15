namespace CargaDados
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gravarButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listarClientesButton = new System.Windows.Forms.Button();
            this.clientesDataGridView = new System.Windows.Forms.DataGridView();
            this.cargaDadosBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gravarButton
            // 
            this.gravarButton.Location = new System.Drawing.Point(13, 13);
            this.gravarButton.Name = "gravarButton";
            this.gravarButton.Size = new System.Drawing.Size(228, 47);
            this.gravarButton.TabIndex = 0;
            this.gravarButton.Text = "Gravar";
            this.gravarButton.UseVisualStyleBackColor = true;
            this.gravarButton.Click += new System.EventHandler(this.gravarButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 66);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(475, 40);
            this.progressBar1.TabIndex = 1;
            // 
            // listarClientesButton
            // 
            this.listarClientesButton.Location = new System.Drawing.Point(260, 13);
            this.listarClientesButton.Name = "listarClientesButton";
            this.listarClientesButton.Size = new System.Drawing.Size(228, 47);
            this.listarClientesButton.TabIndex = 2;
            this.listarClientesButton.Text = "Listar Clientes";
            this.listarClientesButton.UseVisualStyleBackColor = true;
            this.listarClientesButton.Click += new System.EventHandler(this.listarClientesButton_Click);
            // 
            // clientesDataGridView
            // 
            this.clientesDataGridView.AllowUserToAddRows = false;
            this.clientesDataGridView.AllowUserToDeleteRows = false;
            this.clientesDataGridView.AllowUserToOrderColumns = true;
            this.clientesDataGridView.AllowUserToResizeColumns = false;
            this.clientesDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LemonChiffon;
            this.clientesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.clientesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesDataGridView.Location = new System.Drawing.Point(13, 112);
            this.clientesDataGridView.MultiSelect = false;
            this.clientesDataGridView.Name = "clientesDataGridView";
            this.clientesDataGridView.ReadOnly = true;
            this.clientesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientesDataGridView.Size = new System.Drawing.Size(475, 315);
            this.clientesDataGridView.TabIndex = 3;
            // 
            // cargaDadosBackgroundWorker
            // 
            this.cargaDadosBackgroundWorker.WorkerReportsProgress = true;
            this.cargaDadosBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.cargaDadosBackgroundWorker_DoWork);
            this.cargaDadosBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.cargaDadosBackgroundWorker_ProgressChanged);
            this.cargaDadosBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.cargaDadosBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 439);
            this.Controls.Add(this.clientesDataGridView);
            this.Controls.Add(this.listarClientesButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.gravarButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exemplo Threads";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gravarButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button listarClientesButton;
        private System.Windows.Forms.DataGridView clientesDataGridView;
        private System.ComponentModel.BackgroundWorker cargaDadosBackgroundWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

