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
        TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel() { ColumnCount = 4, RowCount = 4, Dock = DockStyle.Fill };
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Controls.Add(tableLayoutPanel1);
            int row, column;
            for (int count = 0; count < 12; count++)
            {
                row = count / 4; column = count % 4;

                MyUserControl myUserControl = new MyUserControl();
                myUserControl.Name = "MyUserControl_" + count.ToString("D2"); // Name it! (Default is "")                
                myUserControl.MouseEnter += MyUserControl_MouseEnter;        // Hook the MouseEnter here
                myUserControl.Codigo = 1000 + count;                         // Example to set Codigo

                tableLayoutPanel1.Controls.Add(myUserControl, column, row);
            }
        }

        private void MyUserControl_MouseEnter(object sender, EventArgs e)
        {
            MyUserControl myUserControl = (MyUserControl)sender;
            Debug.WriteLine(
                "MouseEnter Detected: " + myUserControl.Name + 
                " - Value of Codigo is: " + myUserControl.Codigo);
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
        public int Codigo 
        { 
            set 
            { 
                test = value; 
            } 
            get 
            { 
                return test; 
            } 
        }
        int test = 0;
    }
}
