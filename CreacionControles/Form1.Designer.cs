
namespace CreacionControles
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.userControl11 = new Controles.UserControl1();
            this.label1 = new System.Windows.Forms.Label();
            this.labelIntentos = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Dimension = 100;
            this.userControl11.Directorio = "C:\\Users\\sinoa\\source\\repos\\Topicos2\\CreacionControles\\CreacionControles\\images";
            this.userControl11.ImagenTapa = ((System.Drawing.Image)(resources.GetObject("userControl11.ImagenTapa")));
            this.userControl11.Location = new System.Drawing.Point(9, 9);
            this.userControl11.Margin = new System.Windows.Forms.Padding(0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Separacion = 10;
            this.userControl11.Size = new System.Drawing.Size(612, 486);
            this.userControl11.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Intentos";
            // 
            // labelIntentos
            // 
            this.labelIntentos.AutoSize = true;
            this.labelIntentos.Location = new System.Drawing.Point(432, 457);
            this.labelIntentos.Name = "labelIntentos";
            this.labelIntentos.Size = new System.Drawing.Size(13, 13);
            this.labelIntentos.TabIndex = 2;
            this.labelIntentos.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Reiniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 504);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelIntentos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userControl11);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.UserControl1 userControl11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelIntentos;
        private System.Windows.Forms.Button button1;
    }
}

