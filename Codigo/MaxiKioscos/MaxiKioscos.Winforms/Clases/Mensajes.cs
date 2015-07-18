using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiKioscos.Winforms.Clases
{
   public class Mensajes
    {
       public static void Seleccion(bool Estado)
       {
            if (Estado)
            {
                MessageBox.Show("La selección se realizó correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               
                MessageBox.Show("NO se pudo realizar la selección.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       }
       public static void Guardar(bool Estado)
       {
           if (Estado)
           {
               MessageBox.Show("El registro se guardó correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           else
           {
               MessageBox.Show("NO se pudo guardar el registro.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       public static void Guardar(bool Estado, string mensaje)
       {
           if (string.IsNullOrEmpty(mensaje))
           {
               Guardar(Estado);
               return;
           }

           if (Estado)
           {
               MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           else
           {
               MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       public static void Eliminar(bool Estado)
       {
           if (Estado)
           {
               MessageBox.Show("El registro se eliminó correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           else
           {
              
               MessageBox.Show("NO se pudo eliminar el registro.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       public static void Operacion(bool Estado)
       { 
        if (Estado)
        {
                MessageBox.Show("La operación se realizó correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("No se pudo realizar la operación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }       
       }

   
    }
}
