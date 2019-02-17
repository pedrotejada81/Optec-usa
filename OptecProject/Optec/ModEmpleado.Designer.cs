﻿namespace Optec
{
    partial class ModEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModEmpleado));
            this.tbPuesto = new System.Windows.Forms.TextBox();
            this.dtpfentrada = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.cbSubdepartamento = new System.Windows.Forms.ComboBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.tbApellidos = new System.Windows.Forms.MaskedTextBox();
            this.tbNombres = new System.Windows.Forms.MaskedTextBox();
            this.dtpfsalida = new System.Windows.Forms.DateTimePicker();
            this.btGuardar = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            this.tbCuenta = new System.Windows.Forms.MaskedTextBox();
            this.tbTelefono = new System.Windows.Forms.MaskedTextBox();
            this.tbContacto2 = new System.Windows.Forms.MaskedTextBox();
            this.tbContacto = new System.Windows.Forms.MaskedTextBox();
            this.tbCelular = new System.Windows.Forms.MaskedTextBox();
            this.tbCedula = new System.Windows.Forms.MaskedTextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rbCedula = new System.Windows.Forms.RadioButton();
            this.rbPasaporte = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.cbIgualado = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbDocumento = new System.Windows.Forms.TextBox();
            this.tbSalario = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label13 = new System.Windows.Forms.Label();
            this.tbTasa = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbSalarious = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbPuesto
            // 
            this.tbPuesto.Enabled = false;
            this.tbPuesto.Location = new System.Drawing.Point(196, 325);
            this.tbPuesto.Name = "tbPuesto";
            this.tbPuesto.Size = new System.Drawing.Size(162, 26);
            this.tbPuesto.TabIndex = 44;
            // 
            // dtpfentrada
            // 
            this.dtpfentrada.Enabled = false;
            this.dtpfentrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfentrada.Location = new System.Drawing.Point(196, 370);
            this.dtpfentrada.Name = "dtpfentrada";
            this.dtpfentrada.Size = new System.Drawing.Size(162, 26);
            this.dtpfentrada.TabIndex = 46;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label17.Location = new System.Drawing.Point(45, 328);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 20);
            this.label17.TabIndex = 52;
            this.label17.Text = "Puesto";
            // 
            // cbSubdepartamento
            // 
            this.cbSubdepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubdepartamento.Enabled = false;
            this.cbSubdepartamento.FormattingEnabled = true;
            this.cbSubdepartamento.Location = new System.Drawing.Point(550, 280);
            this.cbSubdepartamento.Name = "cbSubdepartamento";
            this.cbSubdepartamento.Size = new System.Drawing.Size(162, 28);
            this.cbSubdepartamento.TabIndex = 43;
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.Enabled = false;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(196, 280);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(162, 28);
            this.cbDepartamento.TabIndex = 42;
            this.cbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cbDepartamento_SelectedIndexChanged);
            // 
            // tbApellidos
            // 
            this.tbApellidos.Enabled = false;
            this.tbApellidos.HidePromptOnLeave = true;
            this.tbApellidos.Location = new System.Drawing.Point(550, 51);
            this.tbApellidos.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLL";
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.Size = new System.Drawing.Size(162, 26);
            this.tbApellidos.TabIndex = 28;
            this.tbApellidos.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // tbNombres
            // 
            this.tbNombres.Enabled = false;
            this.tbNombres.HidePromptOnLeave = true;
            this.tbNombres.Location = new System.Drawing.Point(196, 51);
            this.tbNombres.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLL";
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.Size = new System.Drawing.Size(162, 26);
            this.tbNombres.TabIndex = 19;
            this.tbNombres.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // dtpfsalida
            // 
            this.dtpfsalida.CustomFormat = "";
            this.dtpfsalida.Enabled = false;
            this.dtpfsalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfsalida.Location = new System.Drawing.Point(550, 370);
            this.dtpfsalida.Name = "dtpfsalida";
            this.dtpfsalida.Size = new System.Drawing.Size(162, 26);
            this.dtpfsalida.TabIndex = 47;
            this.dtpfsalida.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btGuardar.Enabled = false;
            this.btGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btGuardar.Image")));
            this.btGuardar.Location = new System.Drawing.Point(476, 504);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(78, 81);
            this.btGuardar.TabIndex = 53;
            this.toolTip1.SetToolTip(this.btGuardar, "Guardar");
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.BackColor = System.Drawing.SystemColors.Highlight;
            this.btImprimir.Enabled = false;
            this.btImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btImprimir.Image")));
            this.btImprimir.Location = new System.Drawing.Point(197, 504);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(86, 81);
            this.btImprimir.TabIndex = 52;
            this.toolTip1.SetToolTip(this.btImprimir, "Imprimir");
            this.btImprimir.UseVisualStyleBackColor = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // tbCuenta
            // 
            this.tbCuenta.Enabled = false;
            this.tbCuenta.HidePromptOnLeave = true;
            this.tbCuenta.Location = new System.Drawing.Point(196, 416);
            this.tbCuenta.Mask = "99999999999";
            this.tbCuenta.Name = "tbCuenta";
            this.tbCuenta.Size = new System.Drawing.Size(162, 26);
            this.tbCuenta.TabIndex = 48;
            // 
            // tbTelefono
            // 
            this.tbTelefono.Enabled = false;
            this.tbTelefono.HidePromptOnLeave = true;
            this.tbTelefono.Location = new System.Drawing.Point(196, 145);
            this.tbTelefono.Mask = "000-000-0000";
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(162, 26);
            this.tbTelefono.TabIndex = 37;
            // 
            // tbContacto2
            // 
            this.tbContacto2.Enabled = false;
            this.tbContacto2.HidePromptOnLeave = true;
            this.tbContacto2.Location = new System.Drawing.Point(550, 235);
            this.tbContacto2.Mask = "000-000-0000";
            this.tbContacto2.Name = "tbContacto2";
            this.tbContacto2.Size = new System.Drawing.Size(162, 26);
            this.tbContacto2.TabIndex = 41;
            // 
            // tbContacto
            // 
            this.tbContacto.Enabled = false;
            this.tbContacto.HidePromptOnLeave = true;
            this.tbContacto.Location = new System.Drawing.Point(196, 235);
            this.tbContacto.Mask = "000-000-0000";
            this.tbContacto.Name = "tbContacto";
            this.tbContacto.Size = new System.Drawing.Size(162, 26);
            this.tbContacto.TabIndex = 40;
            // 
            // tbCelular
            // 
            this.tbCelular.Enabled = false;
            this.tbCelular.HidePromptOnLeave = true;
            this.tbCelular.Location = new System.Drawing.Point(550, 145);
            this.tbCelular.Mask = "000-000-0000";
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(162, 26);
            this.tbCelular.TabIndex = 38;
            // 
            // tbCedula
            // 
            this.tbCedula.Enabled = false;
            this.tbCedula.HidePromptOnLeave = true;
            this.tbCedula.Location = new System.Drawing.Point(550, 97);
            this.tbCedula.Mask = "000-0000000-0";
            this.tbCedula.Name = "tbCedula";
            this.tbCedula.Size = new System.Drawing.Size(162, 26);
            this.tbCedula.TabIndex = 36;
            // 
            // tbDireccion
            // 
            this.tbDireccion.Enabled = false;
            this.tbDireccion.Location = new System.Drawing.Point(196, 191);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(516, 26);
            this.tbDireccion.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(411, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "Fecha de Salida";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(45, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Número de Cuenta";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(45, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Dirección";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(411, 283);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 20);
            this.label16.TabIndex = 23;
            this.label16.Text = "Subdepartamento";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(44, 283);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 20);
            this.label15.TabIndex = 24;
            this.label15.Text = "Departamento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(45, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Fecha de Entrada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(411, 419);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Salario Mensual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(411, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Celular";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(411, 235);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "Contacto 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(45, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Teléfono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(45, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Contacto 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(411, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "Apellidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(411, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Cédula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(45, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Nombres";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ver/Modificar empleado";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBuscar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbBuscar.Location = new System.Drawing.Point(550, 13);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(121, 31);
            this.tbBuscar.TabIndex = 0;
            this.tbBuscar.Text = "Código";
            this.tbBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbBuscar, "Digite el codigo a modificar");
            this.tbBuscar.Click += new System.EventHandler(this.tbBuscar_Click);
            this.tbBuscar.TextChanged += new System.EventHandler(this.tbBuscar_TextChanged);
            this.tbBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBuscar_KeyPress);
            this.tbBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBuscar_KeyUp);
            // 
            // rbCedula
            // 
            this.rbCedula.AutoSize = true;
            this.rbCedula.Checked = true;
            this.rbCedula.Enabled = false;
            this.rbCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCedula.Location = new System.Drawing.Point(197, 101);
            this.rbCedula.Name = "rbCedula";
            this.rbCedula.Size = new System.Drawing.Size(69, 20);
            this.rbCedula.TabIndex = 54;
            this.rbCedula.TabStop = true;
            this.rbCedula.Text = "Cédula";
            this.rbCedula.UseVisualStyleBackColor = true;
            this.rbCedula.CheckedChanged += new System.EventHandler(this.rbCedula_CheckedChanged);
            // 
            // rbPasaporte
            // 
            this.rbPasaporte.AutoSize = true;
            this.rbPasaporte.Enabled = false;
            this.rbPasaporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPasaporte.Location = new System.Drawing.Point(270, 101);
            this.rbPasaporte.Name = "rbPasaporte";
            this.rbPasaporte.Size = new System.Drawing.Size(89, 20);
            this.rbPasaporte.TabIndex = 55;
            this.rbPasaporte.Text = "Pasaporte";
            this.rbPasaporte.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label19.Location = new System.Drawing.Point(45, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 20);
            this.label19.TabIndex = 53;
            this.label19.Text = "Documento";
            // 
            // cbIgualado
            // 
            this.cbIgualado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIgualado.Enabled = false;
            this.cbIgualado.FormattingEnabled = true;
            this.cbIgualado.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cbIgualado.Location = new System.Drawing.Point(550, 325);
            this.cbIgualado.Name = "cbIgualado";
            this.cbIgualado.Size = new System.Drawing.Size(162, 28);
            this.cbIgualado.TabIndex = 45;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(411, 328);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 20);
            this.label18.TabIndex = 56;
            this.label18.Text = "Igualado?";
            // 
            // tbDocumento
            // 
            this.tbDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDocumento.Location = new System.Drawing.Point(197, 121);
            this.tbDocumento.Name = "tbDocumento";
            this.tbDocumento.Size = new System.Drawing.Size(162, 20);
            this.tbDocumento.TabIndex = 58;
            this.tbDocumento.Text = "Cedula";
            this.tbDocumento.Visible = false;
            // 
            // tbSalario
            // 
            this.tbSalario.Enabled = false;
            this.tbSalario.Location = new System.Drawing.Point(550, 416);
            this.tbSalario.Name = "tbSalario";
            this.tbSalario.Size = new System.Drawing.Size(162, 26);
            this.tbSalario.TabIndex = 49;
            this.tbSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.Location = new System.Drawing.Point(677, 10);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(35, 34);
            this.btBuscar.TabIndex = 59;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "U:\\Optec\\Optec\\Optec\\Manual de usuario\\Consultar y modificar directamente.htm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(411, 466);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 20);
            this.label13.TabIndex = 60;
            this.label13.Text = "TASA US$";
            // 
            // tbTasa
            // 
            this.tbTasa.Enabled = false;
            this.tbTasa.Location = new System.Drawing.Point(550, 463);
            this.tbTasa.Name = "tbTasa";
            this.tbTasa.Size = new System.Drawing.Size(162, 26);
            this.tbTasa.TabIndex = 51;
            this.tbTasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTasa.Leave += new System.EventHandler(this.tbTasa_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label20.Location = new System.Drawing.Point(45, 466);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(116, 20);
            this.label20.TabIndex = 61;
            this.label20.Text = "Salario en US$";
            // 
            // tbSalarious
            // 
            this.tbSalarious.Enabled = false;
            this.tbSalarious.Location = new System.Drawing.Point(197, 463);
            this.tbSalarious.Name = "tbSalarious";
            this.tbSalarious.Size = new System.Drawing.Size(162, 26);
            this.tbSalarious.TabIndex = 50;
            this.tbSalarious.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSalarious.Leave += new System.EventHandler(this.tbSalarious_Leave);
            // 
            // ModEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(769, 597);
            this.Controls.Add(this.tbSalarious);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.tbDocumento);
            this.Controls.Add(this.cbIgualado);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.rbCedula);
            this.Controls.Add(this.rbPasaporte);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.tbPuesto);
            this.Controls.Add(this.dtpfentrada);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbSubdepartamento);
            this.Controls.Add(this.cbDepartamento);
            this.Controls.Add(this.tbTasa);
            this.Controls.Add(this.tbSalario);
            this.Controls.Add(this.tbApellidos);
            this.Controls.Add(this.tbNombres);
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
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "Ayuda");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModEmpleado";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Empleado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPuesto;
        private System.Windows.Forms.DateTimePicker dtpfentrada;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbSubdepartamento;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.MaskedTextBox tbApellidos;
        private System.Windows.Forms.DateTimePicker dtpfsalida;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.MaskedTextBox tbCuenta;
        private System.Windows.Forms.MaskedTextBox tbTelefono;
        private System.Windows.Forms.MaskedTextBox tbContacto2;
        private System.Windows.Forms.MaskedTextBox tbContacto;
        private System.Windows.Forms.MaskedTextBox tbCelular;
        private System.Windows.Forms.MaskedTextBox tbCedula;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.MaskedTextBox tbNombres;
        private System.Windows.Forms.RadioButton rbCedula;
        private System.Windows.Forms.RadioButton rbPasaporte;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbIgualado;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbDocumento;
        private System.Windows.Forms.TextBox tbSalario;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbTasa;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbSalarious;
    }
}