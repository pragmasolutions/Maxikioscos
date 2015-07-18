using System.ComponentModel;
using System.Drawing;
namespace Util.Controles
{
    partial class ucDropDownList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // combo
            // 
            this.combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo.DropDownWidth = 189;
            this.combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(0, 0);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(189, 28);
            this.combo.TabIndex = 0;
            this.combo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.combo_KeyDown);
            this.combo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_KeyPress);
            // 
            // ucDropDownList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combo);
            this.Name = "ucDropDownList";
            this.Size = new System.Drawing.Size(189, 28);
            this.Enter += new System.EventHandler(this.ucDropDownList_Enter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combo;

    }
}
