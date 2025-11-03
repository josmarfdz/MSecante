namespace MSecante
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFuncion = new System.Windows.Forms.TextBox();
            this.dataIteracion = new System.Windows.Forms.DataGridView();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblFuncion = new System.Windows.Forms.Label();
            this.lblRango = new System.Windows.Forms.Label();
            this.txtX0 = new System.Windows.Forms.TextBox();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataIteracion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFuncion
            // 
            this.txtFuncion.Location = new System.Drawing.Point(115, 41);
            this.txtFuncion.Name = "txtFuncion";
            this.txtFuncion.Size = new System.Drawing.Size(161, 22);
            this.txtFuncion.TabIndex = 0;
            // 
            // dataIteracion
            // 
            this.dataIteracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataIteracion.Location = new System.Drawing.Point(50, 199);
            this.dataIteracion.Name = "dataIteracion";
            this.dataIteracion.RowHeadersWidth = 51;
            this.dataIteracion.RowTemplate.Height = 24;
            this.dataIteracion.Size = new System.Drawing.Size(684, 219);
            this.dataIteracion.TabIndex = 2;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(360, 41);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 3;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(360, 103);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblFuncion
            // 
            this.lblFuncion.AutoSize = true;
            this.lblFuncion.Location = new System.Drawing.Point(55, 44);
            this.lblFuncion.Name = "lblFuncion";
            this.lblFuncion.Size = new System.Drawing.Size(54, 16);
            this.lblFuncion.TabIndex = 5;
            this.lblFuncion.Text = "Función";
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.Location = new System.Drawing.Point(55, 75);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(90, 16);
            this.lblRango.TabIndex = 6;
            this.lblRango.Text = "[            ,            ]";
            // 
            // txtX0
            // 
            this.txtX0.Location = new System.Drawing.Point(70, 72);
            this.txtX0.Name = "txtX0";
            this.txtX0.Size = new System.Drawing.Size(27, 22);
            this.txtX0.TabIndex = 7;
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(127, 72);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(27, 22);
            this.txtX1.TabIndex = 8;
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(115, 100);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(161, 22);
            this.txtError.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Error:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtX1);
            this.Controls.Add(this.txtX0);
            this.Controls.Add(this.lblRango);
            this.Controls.Add(this.lblFuncion);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.dataIteracion);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.txtFuncion);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataIteracion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFuncion;
        private System.Windows.Forms.DataGridView dataIteracion;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblFuncion;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.TextBox txtX0;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label1;
    }
}

