using EL_BIBLIOTECARIO;
using System;
using System.Windows.Forms;

namespace EL_BIBLOTECARIO
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

    

                Application.Run(new login());
            }
        }
    }
}

