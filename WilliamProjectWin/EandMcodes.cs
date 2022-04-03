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
    public partial class EandMcodes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public EandMcodes()
        {
            InitializeComponent();
        }

        private void EandMcodes_Load(object sender, EventArgs e)
        {
            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_EandMcodes().ToList();
            if (list.Count > 0)
            {
                gridControl1.DataSource = list;
            }
            else
                gridControl1.DataSource = null;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //add
            EandMcodesForm frm = new EandMcodesForm(-1);
            frm.ShowDialog();

            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_EandMcodes().ToList();
            if (list.Count > 0)
            {
                gridControl1.DataSource = list;
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //edit
            int visibleRowHandle = gridView1.FocusedRowHandle;
            string id = gridView1.GetRowCellValue(visibleRowHandle, gridView1.Columns[0]).ToString();
            EandMcodesForm frm = new EandMcodesForm(Convert.ToInt32(id));
            frm.ShowDialog();

            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_EandMcodes().ToList();
            if (list.Count > 0)
            {
                gridControl1.DataSource = list;
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //del
            WilliamAppDBEntities db = new WilliamAppDBEntities();
            int visibleRowHandle = gridView1.FocusedRowHandle;
            string id = gridView1.GetRowCellValue(visibleRowHandle, gridView1.Columns[0]).ToString();
            db.IU_EandMcodes(Convert.ToInt32(id), "", 1);

            var list = db.S_EandMcodes().ToList();
            if (list.Count > 0)
            {
                gridControl1.DataSource = list;
            }

            MessageBox.Show("The selected row has been deleted from the database.");
        }
    }
}