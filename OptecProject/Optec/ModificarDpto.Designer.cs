namespace Optec
{
    partial class ModificarDpto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarDpto));
            this.lbDpto = new System.Windows.Forms.ListBox();
            this.tbModificar = new System.Windows.Forms.TextBox();
            this.btGuardar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbID = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lbDpto
            // 
            this.lbDpto.FormattingEnabled = true;
            this.lbDpto.ItemHeight = 20;
            this.lbDpto.Location = new System.Drawing.Point(38, 12);
            this.lbDpto.Name = "lbDpto";
            this.lbDpto.Size = new System.Drawing.Size(266, 304);
            this.lbDpto.TabIndex = 0;
            this.lbDpto.DoubleClick += new System.EventHandler(this.lbDpto_DoubleClick);
            this.lbDpto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDpto_MouseDoubleClick);
            this.lbDpto.MouseHover += new System.EventHandler(this.lbDpto_MouseHover);
            // 
            // tbModificar
            // 
            this.tbModificar.Enabled = false;
            this.tbModificar.Location = new System.Drawing.Point(38, 343);
            this.tbModificar.Name = "tbModificar";
            this.tbModificar.Size = new System.Drawing.Size(266, 26);
            this.tbModificar.TabIndex = 1;
            // 
            // btGuardar
            // 
            this.btGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btGuardar.Image")));
            this.btGuardar.Location = new System.Drawing.Point(342, 75);
            this.btGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(95, 104);
            this.btGuardar.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btGuardar, "Guardar cambios.");
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(342, 343);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(95, 26);
            this.tbID.TabIndex = 6;
            this.tbID.Visible = false;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "U:\\Optec\\Optec\\Optec\\Manual de usuario\\Modificar departamentos.htm";
            // 
            // ModificarDpto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(487, 381);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.tbModificar);
            this.Controls.Add(this.lbDpto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "Ayuda");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarDpto";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Departamento";
            this.Load += new System.EventHandler(this.ModificarDpto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDpto;
        private System.Windows.Forms.TextBox tbModificar;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}