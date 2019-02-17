namespace Optec
{
    partial class ReporteNomina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteNomina));
            this.cbNominas = new System.Windows.Forms.ComboBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.btImprimir = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSaveTxt = new System.Windows.Forms.Button();
            this.dgvNomina = new System.Windows.Forms.DataGridView();
            this.btVolantes = new System.Windows.Forms.Button();
            this.btImportar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNominas
            // 
            this.cbNominas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNominas.FormattingEnabled = true;
            this.cbNominas.Location = new System.Drawing.Point(82, 12);
            this.cbNominas.Name = "cbNominas";
            this.cbNominas.Size = new System.Drawing.Size(243, 33);
            this.cbNominas.TabIndex = 0;
            this.cbNominas.SelectedIndexChanged += new System.EventHandler(this.cbNominas_SelectedIndexChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 58);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowCopyButton = false;
            this.crystalReportViewer1.ShowExportButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowPrintButton = false;
            this.crystalReportViewer1.ShowTextSearchButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1222, 524);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha";
            // 
            // btImprimir
            // 
            this.btImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btImprimir.Image")));
            this.btImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImprimir.Location = new System.Drawing.Point(539, 12);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(169, 33);
            this.btImprimir.TabIndex = 3;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 607);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1222, 31);
            this.progressBar1.TabIndex = 5;
            // 
            // btnSaveTxt
            // 
            this.btnSaveTxt.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveTxt.Image")));
            this.btnSaveTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveTxt.Location = new System.Drawing.Point(921, 12);
            this.btnSaveTxt.Name = "btnSaveTxt";
            this.btnSaveTxt.Size = new System.Drawing.Size(169, 33);
            this.btnSaveTxt.TabIndex = 34;
            this.btnSaveTxt.Text = "Exportar TXT";
            this.btnSaveTxt.UseVisualStyleBackColor = true;
            this.btnSaveTxt.Click += new System.EventHandler(this.btnSaveTxt_Click);
            // 
            // dgvNomina
            // 
            this.dgvNomina.AllowUserToAddRows = false;
            this.dgvNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNomina.Location = new System.Drawing.Point(16, 588);
            this.dgvNomina.Name = "dgvNomina";
            this.dgvNomina.Size = new System.Drawing.Size(187, 33);
            this.dgvNomina.TabIndex = 35;
            this.dgvNomina.Visible = false;
            this.dgvNomina.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNomina_CellContentClick);
            // 
            // btVolantes
            // 
            this.btVolantes.Image = ((System.Drawing.Image)(resources.GetObject("btVolantes.Image")));
            this.btVolantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVolantes.Location = new System.Drawing.Point(729, 12);
            this.btVolantes.Name = "btVolantes";
            this.btVolantes.Size = new System.Drawing.Size(169, 33);
            this.btVolantes.TabIndex = 36;
            this.btVolantes.Text = "Imprimir volantes";
            this.btVolantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btVolantes.UseVisualStyleBackColor = true;
            this.btVolantes.Click += new System.EventHandler(this.btVolantes_Click);
            // 
            // btImportar
            // 
            this.btImportar.Image = ((System.Drawing.Image)(resources.GetObject("btImportar.Image")));
            this.btImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImportar.Location = new System.Drawing.Point(351, 12);
            this.btImportar.Name = "btImportar";
            this.btImportar.Size = new System.Drawing.Size(169, 33);
            this.btImportar.TabIndex = 37;
            this.btImportar.Text = "Importar";
            this.btImportar.UseVisualStyleBackColor = true;
            this.btImportar.Click += new System.EventHandler(this.btImportar_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "U:\\Optec\\Optec\\Optec\\Manual de usuario\\Imprimir nomina.htm";
            // 
            // ReporteNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1246, 649);
            this.Controls.Add(this.btImportar);
            this.Controls.Add(this.btVolantes);
            this.Controls.Add(this.dgvNomina);
            this.Controls.Add(this.btnSaveTxt);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.cbNominas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "Ayuda");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteNomina";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Nómina";
            this.Load += new System.EventHandler(this.ReporteNomina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNominas;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSaveTxt;
        private System.Windows.Forms.DataGridView dgvNomina;
        private System.Windows.Forms.Button btVolantes;
        private System.Windows.Forms.Button btImportar;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}