namespace Optec
{
    partial class Empleado
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empleado));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbCedula = new System.Windows.Forms.MaskedTextBox();
            this.tbTelefono = new System.Windows.Forms.MaskedTextBox();
            this.tbCelular = new System.Windows.Forms.MaskedTextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.tbCuenta = new System.Windows.Forms.MaskedTextBox();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkbHabilitado = new System.Windows.Forms.CheckBox();
            this.dtpfsalida = new System.Windows.Forms.DateTimePicker();
            this.tbNombres = new System.Windows.Forms.MaskedTextBox();
            this.tbApellidos = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbContacto = new System.Windows.Forms.MaskedTextBox();
            this.tbContacto2 = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.cbSubdepartamento = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpfentrada = new System.Windows.Forms.DateTimePicker();
            this.tbPuesto = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.cbIgualado = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rbCedula = new System.Windows.Forms.RadioButton();
            this.rbPasaporte = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDocumento = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tbSalario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo empleado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(44, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(410, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Celular";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(44, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Contacto 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(44, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Fecha de Entrada";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(44, 441);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Número de Cuenta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(410, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Apellidos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(43, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Teléfono";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(44, 489);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Salario Mensual";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(44, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "Dirección";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(410, 393);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Fecha de Salida";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(410, 441);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 20);
            this.label13.TabIndex = 1;
            this.label13.Text = "Habilitado";
            // 
            // tbCedula
            // 
            this.tbCedula.HidePromptOnLeave = true;
            this.tbCedula.Location = new System.Drawing.Point(549, 92);
            this.tbCedula.Mask = "000-0000000-0";
            this.tbCedula.Name = "tbCedula";
            this.tbCedula.Size = new System.Drawing.Size(162, 26);
            this.tbCedula.TabIndex = 4;
            // 
            // tbTelefono
            // 
            this.tbTelefono.HidePromptOnLeave = true;
            this.tbTelefono.Location = new System.Drawing.Point(195, 140);
            this.tbTelefono.Mask = "000-000-0000";
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(162, 26);
            this.tbTelefono.TabIndex = 5;
            // 
            // tbCelular
            // 
            this.tbCelular.HidePromptOnLeave = true;
            this.tbCelular.Location = new System.Drawing.Point(549, 140);
            this.tbCelular.Mask = "000-000-0000";
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(162, 26);
            this.tbCelular.TabIndex = 6;
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(195, 186);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(516, 26);
            this.tbDireccion.TabIndex = 7;
            // 
            // tbCuenta
            // 
            this.tbCuenta.HidePromptOnLeave = true;
            this.tbCuenta.Location = new System.Drawing.Point(195, 438);
            this.tbCuenta.Mask = "99999999999";
            this.tbCuenta.Name = "tbCuenta";
            this.tbCuenta.PromptChar = ' ';
            this.tbCuenta.Size = new System.Drawing.Size(162, 26);
            this.tbCuenta.TabIndex = 16;
            // 
            // btImprimir
            // 
            this.btImprimir.BackColor = System.Drawing.SystemColors.Highlight;
            this.btImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btImprimir.Image")));
            this.btImprimir.Location = new System.Drawing.Point(195, 518);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(84, 87);
            this.btImprimir.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btImprimir, "Imprimir\r\n");
            this.btImprimir.UseVisualStyleBackColor = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btGuardar.Image")));
            this.btGuardar.Location = new System.Drawing.Point(455, 518);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(79, 87);
            this.btGuardar.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btGuardar, "Guardar");
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // chkbHabilitado
            // 
            this.chkbHabilitado.Checked = true;
            this.chkbHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbHabilitado.Location = new System.Drawing.Point(549, 441);
            this.chkbHabilitado.Name = "chkbHabilitado";
            this.chkbHabilitado.Size = new System.Drawing.Size(43, 23);
            this.chkbHabilitado.TabIndex = 17;
            this.chkbHabilitado.UseVisualStyleBackColor = true;
            // 
            // dtpfsalida
            // 
            this.dtpfsalida.CustomFormat = "";
            this.dtpfsalida.Enabled = false;
            this.dtpfsalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfsalida.Location = new System.Drawing.Point(549, 388);
            this.dtpfsalida.Name = "dtpfsalida";
            this.dtpfsalida.Size = new System.Drawing.Size(162, 26);
            this.dtpfsalida.TabIndex = 15;
            this.dtpfsalida.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
            // tbNombres
            // 
            this.tbNombres.HidePromptOnLeave = true;
            this.tbNombres.Location = new System.Drawing.Point(195, 46);
            this.tbNombres.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLL";
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.PromptChar = ' ';
            this.tbNombres.Size = new System.Drawing.Size(162, 26);
            this.tbNombres.TabIndex = 0;
            this.tbNombres.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // tbApellidos
            // 
            this.tbApellidos.HidePromptOnLeave = true;
            this.tbApellidos.Location = new System.Drawing.Point(549, 46);
            this.tbApellidos.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLL";
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.PromptChar = ' ';
            this.tbApellidos.Size = new System.Drawing.Size(162, 26);
            this.tbApellidos.TabIndex = 1;
            this.tbApellidos.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(410, 236);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Contacto 2";
            // 
            // tbContacto
            // 
            this.tbContacto.HidePromptOnLeave = true;
            this.tbContacto.Location = new System.Drawing.Point(195, 236);
            this.tbContacto.Mask = "000-000-0000";
            this.tbContacto.Name = "tbContacto";
            this.tbContacto.Size = new System.Drawing.Size(162, 26);
            this.tbContacto.TabIndex = 8;
            // 
            // tbContacto2
            // 
            this.tbContacto2.HidePromptOnLeave = true;
            this.tbContacto2.Location = new System.Drawing.Point(549, 236);
            this.tbContacto2.Mask = "000-000-0000";
            this.tbContacto2.Name = "tbContacto2";
            this.tbContacto2.Size = new System.Drawing.Size(162, 26);
            this.tbContacto2.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(43, 289);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "Departamento";
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(195, 286);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(162, 28);
            this.cbDepartamento.TabIndex = 10;
            this.cbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cbDepartamento_SelectedIndexChanged);
            // 
            // cbSubdepartamento
            // 
            this.cbSubdepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubdepartamento.FormattingEnabled = true;
            this.cbSubdepartamento.Location = new System.Drawing.Point(549, 286);
            this.cbSubdepartamento.Name = "cbSubdepartamento";
            this.cbSubdepartamento.Size = new System.Drawing.Size(162, 28);
            this.cbSubdepartamento.TabIndex = 11;
            this.cbSubdepartamento.SelectedIndexChanged += new System.EventHandler(this.cbSubdepartamento_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(410, 289);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Subdepartamento";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label17.Location = new System.Drawing.Point(44, 342);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 20);
            this.label17.TabIndex = 17;
            this.label17.Text = "Puesto";
            // 
            // dtpfentrada
            // 
            this.dtpfentrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfentrada.Location = new System.Drawing.Point(195, 388);
            this.dtpfentrada.Name = "dtpfentrada";
            this.dtpfentrada.Size = new System.Drawing.Size(162, 26);
            this.dtpfentrada.TabIndex = 14;
            // 
            // tbPuesto
            // 
            this.tbPuesto.Location = new System.Drawing.Point(195, 339);
            this.tbPuesto.Name = "tbPuesto";
            this.tbPuesto.Size = new System.Drawing.Size(162, 26);
            this.tbPuesto.TabIndex = 12;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(410, 342);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 20);
            this.label18.TabIndex = 1;
            this.label18.Text = "Igualado?";
            // 
            // cbIgualado
            // 
            this.cbIgualado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIgualado.FormattingEnabled = true;
            this.cbIgualado.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cbIgualado.Location = new System.Drawing.Point(549, 339);
            this.cbIgualado.Name = "cbIgualado";
            this.cbIgualado.Size = new System.Drawing.Size(162, 28);
            this.cbIgualado.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label19.Location = new System.Drawing.Point(43, 95);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "Documento";
            // 
            // rbCedula
            // 
            this.rbCedula.AutoSize = true;
            this.rbCedula.Checked = true;
            this.rbCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCedula.Location = new System.Drawing.Point(195, 96);
            this.rbCedula.Name = "rbCedula";
            this.rbCedula.Size = new System.Drawing.Size(69, 20);
            this.rbCedula.TabIndex = 2;
            this.rbCedula.TabStop = true;
            this.rbCedula.Text = "Cédula";
            this.rbCedula.UseVisualStyleBackColor = true;
            this.rbCedula.CheckedChanged += new System.EventHandler(this.rbCedula_CheckedChanged);
            // 
            // rbPasaporte
            // 
            this.rbPasaporte.AutoSize = true;
            this.rbPasaporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPasaporte.Location = new System.Drawing.Point(268, 96);
            this.rbPasaporte.Name = "rbPasaporte";
            this.rbPasaporte.Size = new System.Drawing.Size(89, 20);
            this.rbPasaporte.TabIndex = 3;
            this.rbPasaporte.Text = "Pasaporte";
            this.rbPasaporte.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(410, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cédula";
            // 
            // tbDocumento
            // 
            this.tbDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDocumento.Location = new System.Drawing.Point(195, 114);
            this.tbDocumento.Name = "tbDocumento";
            this.tbDocumento.Size = new System.Drawing.Size(162, 20);
            this.tbDocumento.TabIndex = 21;
            this.tbDocumento.Text = "Cedula";
            this.tbDocumento.Visible = false;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "U:\\Optec\\Optec\\Optec\\Manual de usuario\\Nuevo empleado.htm";
            // 
            // tbSalario
            // 
            this.tbSalario.Location = new System.Drawing.Point(195, 486);
            this.tbSalario.Name = "tbSalario";
            this.tbSalario.Size = new System.Drawing.Size(162, 26);
            this.tbSalario.TabIndex = 18;
            this.tbSalario.Text = "0.0";
            this.tbSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSalario.TextChanged += new System.EventHandler(this.tbSalario_TextChanged_1);
            this.tbSalario.Enter += new System.EventHandler(this.textBox2_Enter);
            this.tbSalario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSalario_KeyPress);
            this.tbSalario.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // Empleado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(756, 612);
            this.Controls.Add(this.tbSalario);
            this.Controls.Add(this.tbDocumento);
            this.Controls.Add(this.rbCedula);
            this.Controls.Add(this.rbPasaporte);
            this.Controls.Add(this.cbIgualado);
            this.Controls.Add(this.tbPuesto);
            this.Controls.Add(this.dtpfentrada);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbSubdepartamento);
            this.Controls.Add(this.cbDepartamento);
            this.Controls.Add(this.tbApellidos);
            this.Controls.Add(this.tbNombres);
            this.Controls.Add(this.chkbHabilitado);
            this.Controls.Add(this.dtpfsalida);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.tbCuenta);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.tbContacto2);
            this.Controls.Add(this.tbContacto);
            this.Controls.Add(this.tbCelular);
            this.Controls.Add(this.tbCedula);
            this.Controls.Add(this.tbDireccion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "Ayuda");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Empleado";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo empleado";
            this.Load += new System.EventHandler(this.Empleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox tbCedula;
        private System.Windows.Forms.MaskedTextBox tbTelefono;
        private System.Windows.Forms.MaskedTextBox tbCelular;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.MaskedTextBox tbCuenta;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkbHabilitado;
        private System.Windows.Forms.DateTimePicker dtpfsalida;
        private System.Windows.Forms.MaskedTextBox tbNombres;
        private System.Windows.Forms.MaskedTextBox tbApellidos;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox tbContacto;
        private System.Windows.Forms.MaskedTextBox tbContacto2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.ComboBox cbSubdepartamento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpfentrada;
        private System.Windows.Forms.TextBox tbPuesto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbIgualado;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton rbPasaporte;
        private System.Windows.Forms.RadioButton rbCedula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDocumento;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox tbSalario;
    }
}