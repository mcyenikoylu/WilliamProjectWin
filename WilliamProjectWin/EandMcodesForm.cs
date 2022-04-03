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
    public partial class EandMcodesForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int _int;
        public EandMcodesForm(int id)
        {
            InitializeComponent();
            _int = id;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //save
            WilliamAppDBEntities db = new WilliamAppDBEntities();

            if (_int > 0)
            {
                db.IU_EandMcodes(_int, textEdit1.Text, 0);
                MessageBox.Show("The value has been updated to the database.");
            }
            else
            {
                db.IU_EandMcodes(-1, textEdit1.Text, 0);
                MessageBox.Show("The value has been added to the database.");
            }

            this.Close();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Cancel
            this.Close();
        }

        private void EandMcodesForm_Load(object sender, EventArgs e)
        {
            if (_int > 0)
            {
                WilliamAppDBEntities db = new WilliamAppDBEntities();
                string text = db.S_EandMcodes().Where(c => c.ID == _int).FirstOrDefault().Value;
                textEdit1.Text = text;
            }
            else
                textEdit1.Text = "";
        }
    }
}