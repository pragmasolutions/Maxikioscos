using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MaxiKioscos.Winforms.Clases
{
public class Filtros
{
   public class Filtro
    {
        CheckBox _chek ;
        Control _ctrl ;

        RadioButton _rbtn;
       

        public RadioButton rbtn
        {
            get{ return this._rbtn;}
            
            set{this._rbtn = value;}
        }
        

        public  CheckBox chek
        {
            get{return this._chek;}
            set{this._chek = value;}
        }   
        public Control ctrl
        {
            get{return this._ctrl;}
            set{this._ctrl = value;}
        }

        public Filtro(CheckBox chek , Control ctrl)
        {
            this._chek = chek;
            this._ctrl = ctrl;
        }

   }

    public static void Delegar(List<Filtro> listaFiltros )
        {
            foreach (Filtro f  in listaFiltros)
            {
                f.chek.CheckedChanged+= FiltroChecking;
                f.chek.Tag = f.ctrl;
                f.ctrl.Enabled = false;
                //f.rbtn.Enabled = False
            }       
        }

    public static void FiltroChecking(  System.Object sender ,  System.EventArgs e )
        {
            CheckBox chk = (CheckBox) sender;
            Control ctrl = (Control) chk.Tag;
            //Dim rbtn As RadioButton = CType(sender, RadioButton)
            ctrl.Enabled = chk.Checked;

        }

}


    }

