using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hook_user_control_mouse_enter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TableLayoutPanel _layout = new TableLayoutPanel() { ColumnCount = 4, RowCount = 4, Dock = DockStyle.Fill };
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Controls.Add(_layout);
            int row, column;
            for (int count = 0; count < 12; count++)
            {
                row = count / 4; column = count % 4;
                MyUserControl myUserControl = new MyUserControl();
                myUserControl.Name = "MyUserControl" + count.ToString("D2");
                myUserControl.MouseEnter += MyUserControl_MouseEnter;
                _layout.Controls.Add(myUserControl, column, row);
            }
        }

        private void MyUserControl_MouseEnter(object sender, EventArgs e)
        {
            Control myUserControl = sender as Control;
            string name = myUserControl.Name;
            Debug.WriteLine("MouseEnter Detected: " + name);
        }
    }
    class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            BackColor = Color.MidnightBlue;
            Height = 23;
            Width = 75;
        }
    }
}
