using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Xml.Linq;

namespace WindowsFormsApp2.componentes
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        //Campos

        private Color primaryColor; // color primario del menu
        private Color textColor; // color texto
        private int arrowThickness; // grosor del icono flecha de un elemento desplegable 

        //constructor
        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor)
            :base(new MenuColorTable(isMainMenu, primaryColor))           
        {
            //llamamos al constructor de la clase padre
            //y enviamos el MenuColorTable personalizado para el renderizado
            // isMainMenu: define si el menu sera un menu secundario o principal
            // primaryColor: define el color primario de apariencia
            this.primaryColor = primaryColor;
            this.textColor = textColor;
            if (isMainMenu) arrowThickness = 3;
            else arrowThickness = 2;    
        }

        //sobreescribir

        //Este método se encarga de dibujar el texto de cada ítem(elemento) 
        //en un menú o barra de herramientas. Si deseas personalizar la 
        //apariencia del texto(fuente, color, alineación, sombra, etc.), 
        //puedes sobrescribir(override) este método en tu propia 
        //clase que herede de ToolStripRenderer o ToolStripProfessionalRenderer.

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            //operador ternario que estable el color del texto dependiendo de la seleccion
            e.Item.ForeColor = e.Item.Selected ? Color.White : textColor;
            
        }



        //El método OnRenderArrow en C# es parte de la clase ToolStripRenderer (y sus derivadas como
        //ToolStripProfessionalRenderer), y se encarga de dibujar las flechas (▶) que aparecen al
        //lado derecho de un ítem de menú que tiene un submenú o DropDown.
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            //campos
            Graphics graph = e.Graphics;// campo del objeto de graficos
            Size arrowSize = new Size(5,12);//tamaño del icono flecha
            Color arrowColor = e.Item.Selected? Color.White: primaryColor;//establecemos el color
            //del icono flecha en funcion de si esta seleccionado el campo o no
            Rectangle rect = new Rectangle(e.ArrowRectangle.Location.X,
                (e.ArrowRectangle.Height - arrowSize.Width)/2,
                arrowSize.Width, 
                arrowSize.Height);//rectangulo para la ubicacion y tamaño del icono flecha

            using (GraphicsPath path = new GraphicsPath()) //Ruta de graficos de la flecha
            using (Pen pen = new Pen(arrowColor,arrowThickness)) // Objeto lapiz para dibuja la flecha con el color y tamaño especificado
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;//El valor SmoothingMode.AntiAlias
                //le dice a .NET que dibuje líneas más suaves,
                //sin "escalones" o bordes pixelados.
                path.AddLine(rect.Left,rect.Top,rect.Right,rect.Top + rect.Height/2);
                path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Height + rect.Top);
                graph.DrawPath(pen,path);//dibujamos la flecha
            }                                            

        }
    }
}
