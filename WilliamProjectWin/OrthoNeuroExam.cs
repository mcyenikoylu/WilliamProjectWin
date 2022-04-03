using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace WilliamProjectWin
{
    public partial class OrthoNeuroExam : DevExpress.XtraEditors.XtraUserControl
    {
        public OrthoNeuroExam()
        {
            InitializeComponent();
        }

        private void OrthoNeuroExam_Load(object sender, EventArgs e)
        {
            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_EandMcodes().ToList();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    radioGroup1.Properties.Items.Add(new RadioGroupItem(item.ID, item.Value.ToString()));

                }
            }
        }
    }
}
