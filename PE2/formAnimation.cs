using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2
{
    public class FormAnimation
    {
        public static void ExpandMenuPanel(Panel panel, int originalWidth, int expandedWidth)
        {
            if (panel.Width == expandedWidth)
                return;

            int speed = 15; // Ajuste a velocidade da animação conforme necessário
            int step = Math.Abs(expandedWidth - originalWidth) / speed;

            if (expandedWidth > originalWidth)
            {
                for (int i = originalWidth; i <= expandedWidth; i += step)
                {
                    panel.Width = i;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10); // Ajuste o tempo de espera conforme necessário
                }
            }
            else
            {
                for (int i = originalWidth; i >= expandedWidth; i -= step)
                {
                    panel.Width = i;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10); // Ajuste o tempo de espera conforme necessário
                }
            }
        }
    }
}
