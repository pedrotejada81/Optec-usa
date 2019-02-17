namespace Optec
{
    partial class Liquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Liquidacion));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSalComisiones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTotalComisiones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvNominasSemanales = new System.Windows.Forms.DataGridView();
            this.tbCedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbListaEmpleados = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tbtotalSalarioSemanal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNominasSemanales)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "Módulo Liquidación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Total Salarios y Comisiones";
            // 
            // tbSalComisiones
            // 
            this.tbSalComisiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSalComisiones.Location = new System.Drawing.Point(647, 505);
            this.tbSalComisiones.Name = "tbSalComisiones";
            this.tbSalComisiones.ReadOnly = true;
            this.tbSalComisiones.Size = new System.Drawing.Size(216, 29);
            this.tbSalComisiones.TabIndex = 19;
            this.tbSalComisiones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(584, 469);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Total Comisiones";
            // 
            // tbTotalComisiones
            // 
            this.tbTotalComisiones.Location = new System.Drawing.Point(720, 466);
            this.tbTotalComisiones.Name = "tbTotalComisiones";
            this.tbTotalComisiones.ReadOnly = true;
            this.tbTotalComisiones.Size = new System.Drawing.Size(143, 26);
            this.tbTotalComisiones.TabIndex = 17;
            this.tbTotalComisiones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 469);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Total Salarios Semanales";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvNominasSemanales
            // 
            this.dgvNominasSemanales.AllowUserToAddRows = false;
            this.dgvNominasSemanales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNominasSemanales.Location = new System.Drawing.Point(23, 104);
            this.dgvNominasSemanales.Name = "dgvNominasSemanales";
            this.dgvNominasSemanales.ReadOnly = true;
            this.dgvNominasSemanales.Size = new System.Drawing.Size(840, 347);
            this.dgvNominasSemanales.TabIndex = 14;
            // 
            // tbCedula
            // 
            this.tbCedula.Location = new System.Drawing.Point(455, 59);
            this.tbCedula.Name = "tbCedula";
            this.tbCedula.ReadOnly = true;
            this.tbCedula.Size = new System.Drawing.Size(192, 26);
            this.tbCedula.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Empleados";
            // 
            // cbListaEmpleados
            // 
            this.cbListaEmpleados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListaEmpleados.FormattingEnabled = true;
            this.cbListaEmpleados.Location = new System.Drawing.Point(119, 59);
            this.cbListaEmpleados.Name = "cbListaEmpleados";
            this.cbListaEmpleados.Size = new System.Drawing.Size(330, 28);
            this.cbListaEmpleados.TabIndex = 11;
            this.cbListaEmpleados.SelectedIndexChanged += new System.EventHandler(this.cbListaEmpleados_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(666, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 31);
            this.button3.TabIndex = 33;
            this.button3.Text = "Reporte";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbtotalSalarioSemanal
            // 
            this.tbtotalSalarioSemanal.Location = new System.Drawing.Point(428, 466);
            this.tbtotalSalarioSemanal.Name = "tbtotalSalarioSemanal";
            this.tbtotalSalarioSemanal.ReadOnly = true;
            this.tbtotalSalarioSemanal.Size = new System.Drawing.Size(143, 26);
            this.tbtotalSalarioSemanal.TabIndex = 15;
            this.tbtotalSalarioSemanal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Liquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(883, 540);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSalComisiones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTotalComisiones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbtotalSalarioSemanal);
            this.Controls.Add(this.dgvNominasSemanales);
            this.Controls.Add(this.tbCedula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbListaEmpleados);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Liquidacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidacion";
            this.Load += new System.EventHandler(this.Liquidacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNominasSemanales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSalComisiones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTotalComisiones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvNominasSemanales;
        private System.Windows.Forms.TextBox tbCedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbListaEmpleados;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbtotalSalarioSemanal;
    }
}