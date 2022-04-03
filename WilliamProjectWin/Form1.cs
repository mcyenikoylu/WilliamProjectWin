using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace WilliamProjectWin
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_XrayReportsButton().ToList();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    SimpleButton newButton = new SimpleButton();
                    newButton.Dock = DockStyle.Top;
                    newButton.Text = item.Name;
                    newButton.Name = "btn" + item.ID.ToString();
                    newButton.Click += simpleButton1_Click;
                    //buttons.Add(newButton);
                    //this.Controls.Add(newButton);

                    MemoEdit newTextEdit = new MemoEdit();
                    newTextEdit.Dock = DockStyle.Top;
                    newTextEdit.Text = "MemoText " + item.Name;
                    newTextEdit.Name = "txt" + item.ID.ToString();
                    //newTextEdit.Width = 300;
                    newTextEdit.Properties.AutoHeight = false;
                    newTextEdit.Height = 70;
                    newTextEdit.Properties.Appearance.Options.UseTextOptions = true;
                    newTextEdit.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    newTextEdit.Visible = false;

                    panelControl3.Controls.Add(newTextEdit);
                    panelControl3.Controls.Add(newButton);
                }
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    SimpleButton newButton = new SimpleButton();
            //    newButton.Dock = DockStyle.Top;
            //    newButton.Text = "Button " + i.ToString();
            //    newButton.Name = "btn" + i.ToString();
            //    newButton.Click += simpleButton1_Click;
            //    //buttons.Add(newButton);
            //    //this.Controls.Add(newButton);

            //    MemoEdit newTextEdit = new MemoEdit();
            //    newTextEdit.Dock = DockStyle.Top;
            //    newTextEdit.Text = "MemoText " + i.ToString();
            //    newTextEdit.Name = "txt" + i.ToString();
            //    //newTextEdit.Width = 300;
            //    newTextEdit.Properties.AutoHeight = false;
            //    newTextEdit.Height = 70;
            //    newTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            //    newTextEdit.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            //    newTextEdit.Visible = false;

            //    panelControl3.Controls.Add(newTextEdit);
            //    panelControl3.Controls.Add(newButton);

            //}
            
        }

        
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
        }

        private void navBarItem2_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void barBtnXrayReportsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XrayReportsButton frm = new XrayReportsButton();
            frm.ShowDialog();
        }

        private void barBtnEandMcodes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            

            EandMcodes frm = new EandMcodes();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WilliamAppDBEntities db = new WilliamAppDBEntities();
            var list = db.S_EandMcodes().ToList();
            if (list.Count > 0)
            {
                orthoNeuroExam1.radioGroup1.Properties.Items.Clear();
                foreach (var item in list)
                {
                    orthoNeuroExam1.radioGroup1.Properties.Items.Add(new RadioGroupItem(item.ID, item.Value.ToString()));

                }
            }


            panelControl3.Controls.Clear();
             var list2 = db.S_XrayReportsButton().ToList();
            if (list2.Count > 0)
            {
                foreach (var item in list2)
                {
                    SimpleButton newButton = new SimpleButton();
                    newButton.Dock = DockStyle.Top;
                    newButton.Text = item.Name;
                    newButton.Name = "btn" + item.ID.ToString();
                    newButton.Click += simpleButton1_Click;
                    //buttons.Add(newButton);
                    //this.Controls.Add(newButton);

                    MemoEdit newTextEdit = new MemoEdit();
                    newTextEdit.Dock = DockStyle.Top;
                    newTextEdit.Text = "MemoText " + item.Name;
                    newTextEdit.Name = "txt" + item.ID.ToString();
                    //newTextEdit.Width = 300;
                    newTextEdit.Properties.AutoHeight = false;
                    newTextEdit.Height = 70;
                    newTextEdit.Properties.Appearance.Options.UseTextOptions = true;
                    newTextEdit.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    newTextEdit.Visible = false;

                    panelControl3.Controls.Add(newTextEdit);
                    panelControl3.Controls.Add(newButton);
                }
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            object btn = sender;
            SimpleButton simpleButton = new SimpleButton();
            simpleButton.Name = ((System.Windows.Forms.Control)btn).Name;
            string name = simpleButton.Name.Replace("btn", "txt");
            MemoEdit tbx = this.Controls.Find(name, true).FirstOrDefault() as MemoEdit;
            tbx.Visible = true;

            //if (((System.Windows.Forms.Control)btn).Name == "btn 7")
            //{

            //}

        }
    }
}