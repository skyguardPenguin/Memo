using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace Controles
{
    public partial class UserControl1 : UserControl
    {
        public delegate void ImagenSeleccionadaDelegate(object sender, ImagenSeleccionadaArgs e);
        public event ImagenSeleccionadaDelegate ImagenSeleccionada;
        private Image imagenTapa;
        
        private string _directorio = "";
        private int _dimension;
        private int _separacion;
        private int _borde = 7;
       





        private List<ImagenConNombre> imagenes = new List<ImagenConNombre>();
        private List<ImagenConNombre> imagenesEncontradas = new List<ImagenConNombre>();
        public int Count;
        public int ActiveCount = 0;
        public string Directorio
        {
            get { return _directorio; }
            set
            {
                _directorio = value;
                getImagenes();
           
                UpdateControl();
            }
        }
       
        public Image ImagenTapa
        {
            get
            {
                return imagenTapa;
            }
            set
            {
                imagenTapa = value;
                getImagenes();
            

            }
        }

        public int Dimension
        {
            get { return _dimension; }
            set
            {
                _dimension = value;
                UpdateControl();
            }
        }
        [
            Category("Design"),
            Description("Distancia etre las imágenes. ")
        ]
        public int Separacion
        {
            get { return _separacion; }
            set
            {
                _separacion = value;
                UpdateControl();
            }
        }

        


        public UserControl1()
        {
            InitializeComponent();
           
            
        }

        private void getImagenes()
        {
            if (_directorio.Length != 0)
            {
                imagenes.Clear();

                DirectoryInfo dir = new DirectoryInfo(Directorio);

                foreach (FileInfo file in dir.GetFiles("*.jpg"))
                {
                    imagenes.Add(new ImagenConNombre(Bitmap.FromFile(file.FullName), ImagenTapa, file.FullName, false));

                }
                foreach (FileInfo file in dir.GetFiles("*.jpg"))
                {

                    imagenes.Add(new ImagenConNombre(Bitmap.FromFile(file.FullName), ImagenTapa, file.FullName + "V2", false));

                }
                Count = imagenes.Count;



            }
        }
        private void UpdateControl()
        {
            
            panel1.SuspendLayout();
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }


            panel1.Controls.Clear();

            int col = _borde, fila = _borde;

            foreach (ImagenConNombre img in imagenes)
            {
                if (!imagenesEncontradas.Contains(img))
                {
                    PictureBox pic = new PictureBox();

                    pic.Image = img.ImagenActiva;




                    pic.Tag = img.FileName;
                    pic.Size = new Size(_dimension, _dimension);
                    pic.Location = new Point(col, fila);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pic);

                    pic.Click += new EventHandler(this.pic_Click);

                    col += _dimension + _separacion;
                    if ((col + _dimension + _separacion + _borde) > this.Width)
                    {
                        col = _borde;
                        fila += _dimension + _separacion;
                    }
                   
                }
               

            }
            panel1.ResumeLayout();
        }

        public override void Refresh()
        {
            imagenesEncontradas = new List<ImagenConNombre>();
            getImagenes();
            UpdateControl();
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateControl();
            base.OnSizeChanged(e);
        }
        public void SetImageState(bool state)
        {

        }


        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox picSeleccionada = (PictureBox)sender;
            ImagenSeleccionadaArgs args= new ImagenSeleccionadaArgs(picSeleccionada.Image, (string)picSeleccionada.Tag);
            ImagenSeleccionada(this, args);
        }

        public void ShowImage(string fileName)
        {
            foreach (ImagenConNombre img in imagenes)
                if (img.FileName == fileName)
                {
                    ActiveCount++;
                    img.ShowDefaultState = true;
                    UpdateControl();
                    
                }
        }
        public void HideImage(string fileName)
        {
            foreach (ImagenConNombre img in imagenes)
                if (img.FileName == fileName)
                {
                    img.ShowDefaultState = true;
                    UpdateControl();
                    ActiveCount--;

                }
        }
        public void HideAll()
        {
            foreach (ImagenConNombre img in imagenes)
            {
                img.ShowDefaultState = false;

                
            }
            UpdateControl();
            ActiveCount = 0;
        }
        public void RemoveImage(string fileName)
        {
            foreach (ImagenConNombre img in imagenes)
            {
                if(img.FileName==fileName|| img.FileName == fileName + "V2"|| img.FileName == fileName.Substring(0,fileName.Length-2))
                    imagenesEncontradas.Add(img);
               

            }
            UpdateControl();
            ActiveCount = 0;
        }

        public bool Pair(string fileName)
        {
            if (fileName.Contains("V2"))
                fileName = fileName.Substring(0, fileName.Length - 2);
            else fileName = fileName + "V2";

            foreach (ImagenConNombre img in imagenes)
            {
                if (img.FileName == fileName&&img.ShowDefaultState)
                    return true;
            }
            return false;
        }
        internal class ImagenConNombre
        {
            private bool _showDefaultState=false;
            private Image _image;
            private Image _imagenActiva;
            public Image Imagen { get { return _image; } set { _image = value; } }
            public Image ImagenActiva { get=>_imagenActiva; set { _imagenActiva = value; } }
            public Image Tapa { get; set; }
            public string FileName { get; set; }
            public bool ShowDefaultState
            {
                get
                {
                    return _showDefaultState;
                }
                
                set
                {
                    _showDefaultState = value;
                    if (value) ImagenActiva = Imagen;
                    else ImagenActiva = Tapa;
                }
            }
          

            public ImagenConNombre(Image img,Image tapa, string fileName,bool showDefalutState)
            {
                Imagen = img;
                FileName = fileName;
                Tapa = tapa;
                ShowDefaultState = showDefalutState;
                ShowDefaultState = false;
                
            }
            public ImagenConNombre()
            {

            }
        }
        public class ImagenSeleccionadaArgs : EventArgs
        {
            public Image Imagen { get; set; }
            public string FileName { get; set; }
            
           
            public ImagenSeleccionadaArgs(Image img, string fileName)
            {
                Imagen = img;
                FileName = fileName;
             
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

