using ProGM.Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProGM.Management.Controller
{
    public class ConfigLayout
    {
        /// <summary>
        /// Update layout full screen
        /// </summary>
        /// <param name="userControl"></param>
        /// <param name="panel"></param>
        /// <param name="grid"></param>
        /// <param name="obj"></param>
        public static void UpdateLayout(UserControl userControl, DevExpress.XtraEditors.PanelControl panel, DevExpress.XtraGrid.GridControl grid, MenuObject obj)
        {
            try
            {
                userControl.Width = obj.frmWidth;
                userControl.Height = obj.frmHeight - obj.frmMenuHeight;
                panel.Width = obj.frmWidth - 16;
                grid.Height = obj.frmHeight - obj.frmMenuHeight - 90;
                grid.Width = obj.frmWidth - 17;
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ ex);
            }
        }
    }
}
