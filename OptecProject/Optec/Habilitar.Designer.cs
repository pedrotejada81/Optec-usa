namespace Optec
{
    partial class Habilitar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Habilitar));
            this.btGuardar = new System.Windows.Forms.Button();
            this.chkbHabilitado = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPuesto = new System.Windows.Forms.TextBox();
            this.dtpfentrada = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpfsalida = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.tbApellidos = new System.Windows.Forms.MaskedTextBox();
            this.tbNombres = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btGuardar.Image")));
            this.btGuardar.Location = new System.Drawing.Point(397, 189);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(85, 83);
            this.btGuardar.TabIndex = 77;
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // chkbHabilitado
            // 
            this.chkbHabilitado.Checked = true;
            this.chkbHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbHabilitado.Enabled = false;
            this.chkbHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbHabilitado.Location = new System.Drawing.Point(206, 341);
            this.chkbHabilitado.Name = "chkbHabilitado";
            this.chkbHabilitado.Size = new System.Drawing.Size(43, 23);
            this.chkbHabilitado.TabIndex = 75;
            this.chkbHabilitado.UseVisualStyleBackColor = true;
            this.chkbHabilitado.CheckedChanged += new System.EventHandler(this.chkbHabilitado_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 343);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 20);
            this.label13.TabIndex = 74;
            this.label13.Text = "Habilitado";
            // 
            // tbPuesto
            // 
            this.tbPuesto.Enabled = false;
            this.tbPuesto.Location = new System.Drawing.Point(206, 203);
            this.tbPuesto.Name = "tbPuesto";
            this.tbPuesto.Size = new System.Drawing.Size(162, 26);
            this.tbPuesto.TabIndex = 70;
            // 
            // dtpfentrada
            // 
            this.dtpfentrada.Enabled = false;
            this.dtpfentrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfentrada.Location = new System.Drawing.Point(206, 247);
            this.dtpfentrada.Name = "dtpfentrada";
            this.dtpfentrada.Size = new System.Drawing.Size(162, 26);
            this.dtpfentrada.TabIndex = 71;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 206);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 20);
            this.label17.TabIndex = 73;
            this.label17.Text = "Puesto";
            // 
            // dtpfsalida
            // 
            this.dtpfsalida.CustomFormat = "";
            this.dtpfsalida.Enabled = false;
            this.dtpfsalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfsalida.Location = new System.Drawing.Point(206, 292);
            this.dtpfsalida.Name = "dtpfsalida";
            this.dtpfsalida.Size = new System.Drawing.Size(162, 26);
            this.dtpfsalida.TabIndex = 72;
            this.dtpfsalida.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 297);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 20);
            this.label12.TabIndex = 68;
            this.label12.Text = "Fecha de Salida";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 20);
            this.label6.TabIndex = 69;
            this.label6.Text = "Fecha de Entrada";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBuscar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbBuscar.Location = new System.Drawing.Point(255, 79);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(113, 31);
            this.tbBuscar.TabIndex = 62;
            this.tbBuscar.Text = "Código";
            this.tbBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBuscar.Click += new System.EventHandler(this.tbBuscar_Click);
            this.tbBuscar.TextChanged += new System.EventHandler(this.tbBuscar_TextChanged);
            this.tbBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBuscar_KeyPress);
            // 
            // tbApellidos
            // 
            this.tbApellidos.Enabled = false;
            this.tbApellidos.HidePromptOnLeave = true;
            this.tbApellidos.Location = new System.Drawing.Point(206, 161);
            this.tbApellidos.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLL";
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.Size = new System.Drawing.Size(162, 26);
            this.tbApellidos.TabIndex = 65;
            this.tbApellidos.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // tbNombres
            // 
            this.tbNombres.Enabled = false;
            this.tbNombres.HidePromptOnLeave = true;
            this.tbNombres.Location = new System.Drawing.Point(206, 118);
            this.tbNombres.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLL";
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.Size = new System.Drawing.Size(162, 26);
            this.tbNombres.TabIndex = 64;
            this.tbNombres.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 66;
            this.label8.Text = "Apellidos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Nombres";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 24);
            this.label1.TabIndex = 63;
            this.label1.Text = "Activar/Inactivar empleado";
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.Location = new System.Drawing.Point(397, 79);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(85, 83);
            this.btBuscar.TabIndex = 76;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "U:\\Optec\\Optec\\Optec\\Manual de usuario\\Activar-desactivar empleado.htm";
            // 
            // Habilitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(518, 413);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.chkbHabilitado);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbPuesto);
            this.Controls.Add(this.dtpfentrada);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dtpfsalida);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.tbApellidos);
            this.Controls.Add(this.tbNombres);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "Ayuda");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Habilitar";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activar/Inactivar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.CheckBox chkbHabilitado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbPuesto;
        private System.Windows.Forms.DateTimePicker dtpfentrada;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpfsalida;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.MaskedTextBox tbApellidos;
        public System.Windows.Forms.MaskedTextBox tbNombres;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}