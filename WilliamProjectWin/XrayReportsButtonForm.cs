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
    public partial class XrayReportsButtonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int _int;
        public XrayReportsButtonForm(int id)
        {
            InitializeComponent();
            _int = id;
        }

        private void XrayReportsButtonForm_Load(object sender, EventArgs e)
        {
            if (_int > 0)
            {
                WilliamAppDBEntities db = new WilliamAppDBEntities();
                string text = db.S_XrayReportsButton().Where(c => c.ID == _int).FirstOrDefault().Name;
                textEdit1.Text = text;
            }
            else
                textEdit1.Text = "";
        }

        private void barBtnSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            //save
            WilliamAppDBEntities db = new WilliamAppDBEntities();

            if (_int > 0)
            {
                db.IU_XrayReportsButton(_int, textEdit1.Text, 0);
                MessageBox.Show("The button has been updated to the database.");
            }
            else
            {
                db.IU_XrayReportsButton(-1, textEdit1.Text, 0);
                MessageBox.Show("The button has been added to the database.");
            }
             

            this.Close();
        }

        private void barBtnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}