using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public class MenuColorTable: ProfessionalColorTable
    {
        //--campos
        private Color backColor; //color de fondo del menu
        private Color leftColumnColor; //color de la columna izquierda
        private Color borderColor;//color de borde del elemento del menu
        private Color menuItemBorderColor; // color de borde del elemento del menu seleccionado
        private Color menuItemSelectedColor;//color del elemento del menu seleccionado

        //Constructor

        public MenuColorTable(bool isMainMenu, Color primaryColor)
        {
            // isMainMenu: define si el menu sera un menu secundario o principal
            // primaryColor: define el color primario de apariencia

            if(isMainMenu)
            {
                backColor = Color.FromArgb(37, 39, 60);
                leftColumnColor = Color.FromArgb(32, 33, 31);
                borderColor = Color.FromArgb(32, 33, 51);
                menuItemBorderColor = Color.FromArgb(228, 26, 74);
                menuItemSelectedColor = Color.FromArgb(228, 26, 74);
            }else
            {
                backColor = Color.LightGray;
                leftColumnColor = Color.White;
                borderColor = Color.LightGray;
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;

            }
        }

        //anular las siguientes propiedades

        public override Color ToolStripDropDownBackground => backColor;
        public override Color MenuBorder => borderColor;

        public override Color MenuItemBorder => menuItemBorderColor;

        public override Color MenuItemSelected => menuItemSelectedColor;

        public override Color ImageMarginGradientBegin => leftColumnColor;

        public override Color ImageMarginGradientMiddle => leftColumnColor;
        public override Color ImageMarginGradientEnd => leftColumnColor;


    }
}
