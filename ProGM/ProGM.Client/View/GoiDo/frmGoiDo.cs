using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProGM.Client.View.GoiDo
{
    public partial class frmGoiDo : DevExpress.XtraEditors.XtraForm
    {
        public frmGoiDo()
        {
            InitializeComponent();
            panel3.Controls.Add(new uctrFood());
        }
    }
}
