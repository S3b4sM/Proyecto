using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            int id = 1;
            Usuario usuario = new Usuario();
            usuario.Id = id;
            usuario.FirstName= "Admin";
            usuario.LastName= "Admin";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal(usuario));
        }
    }
}
