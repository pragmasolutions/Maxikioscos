using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Util.Controles
{
    public partial class ucDatePicker : UserControl
    {
        public ucDatePicker()
        {
            InitializeComponent();
        }

        public DateTime Fecha
        {
            get
            {
                return datePicker.Value;
            }
            set
            {
                datePicker.Value = value;
            }
        }

        public DateTime FechaMinima
        {
            get
            {
                return datePicker.MinDate;
            }
            set
            {
                datePicker.MinDate = value;
            }
        }

        public DateTime FechaMaxima
        {
            get
            {
                return datePicker.MaxDate;
            }
            set
            {
                datePicker.MaxDate = value;
            }
        }


        new public void Focus()
        {
            datePicker.Focus();
        }

        
       
        public bool Valido()
        {
            return true;
        }

        private void ucDatePicker_Load(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Today;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DatePickerFormat"]))
            {
                DateTimePickerFormat format;
                DateTimePickerFormat.TryParse(ConfigurationManager.AppSettings["DatePickerFormat"], out format);
                datePicker.Format = format;
            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DatePickerCustomFormat"]))
            {
                datePicker.CustomFormat = ConfigurationManager.AppSettings["DatePickerCustomFormat"];
            }
        }

    }
}
