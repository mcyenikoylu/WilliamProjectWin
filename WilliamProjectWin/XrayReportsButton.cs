using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace WilliamProjectWin
{
    public partial class XrayReportsButton : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XrayReportsButton()
        {
            InitializeComponent();
        }

        private void XrayReportsButton_Load(object sender, EventArgs e)
        {
            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_XrayReportsButton().ToList();
            if (list.Count > 0)
                gridControl1.DataSource = list;
            else
                gridControl1.DataSource = null;
        }

        private void barBtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            XrayReportsButtonForm frm = new XrayReportsButtonForm(-1);
            frm.ShowDialog();

            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_XrayReportsButton().ToList();
            if (list.Count > 0)
            {
                gridControl1.DataSource = list;
            }
        }

        private void barBtnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //edit
            int visibleRowHandle = gridView1.FocusedRowHandle;
            string id = gridView1.GetRowCellValue(visibleRowHandle, gridView1.Columns[0]).ToString();
            XrayReportsButtonForm frm = new XrayReportsButtonForm(Convert.ToInt32(id));
            frm.ShowDialog();

            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_XrayReportsButton().ToList();
            if (list.Count > 0)
            {
                gridControl1.DataSource = list;
            }
        }

        private void barBtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            //del
            WilliamAppDBEntities db = new WilliamAppDBEntities();
            int visibleRowHandle = gridView1.FocusedRowHandle;
            string id = gridView1.GetRowCellValue(visibleRowHandle, gridView1.Columns[0]).ToString();
            db.IU_XrayReportsButton(Convert.ToInt32(id), "", 1);

            var list = db.S_XrayReportsButton().ToList();
            if (list.Count > 0)
            {
                gridControl1.DataSource = list;
            }

            MessageBox.Show("The selected row has been deleted from the database.");
        }
    }
}