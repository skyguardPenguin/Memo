using CreacionControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
namespace CreacionControles
{
    public partial class Form1 : Form
    {
        Timer MyTimer;
   
        Contador contador;
        int timerIteration=0;
        public Form1()
        {
            InitializeComponent();
            userControl11.ImagenSeleccionada+=visor_ImagenSeleccionada;
            contador = new Contador(0);
            MyTimer = new Timer();
            MyTimer.Interval = 300;
            MyTimer.Tick += MyTimer_Tick;
        }
        private void visor_ImagenSeleccionada(object sender, Controles.UserControl1.ImagenSeleccionadaArgs e)
        {
            if(userControl11.ActiveCount<2)
                userControl11.ShowImage(e.FileName);
            if(userControl11.ActiveCount==2)
            {
                
                if (userControl11.Pair(e.FileName))
                { 

                    MessageBox.Show("Par");
                   userControl11.RemoveImage(e.FileName);
                   
                    
                }
                else
                {
                    timerIteration = 0;
                    MyTimer.Start();
                }
                contador.Incremento(1);
                labelIntentos.Text = contador.Cuenta.ToString();
            }

        
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (timerIteration > 1)
            {
                userControl11.HideAll();
                MyTimer.Stop();
                timerIteration = 0;

            }
            else timerIteration++;
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            userControl11.Refresh();
            contador.Reset();
            labelIntentos.Text = contador.Cuenta.ToString();
        }
    }
}


