using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JARVIS6
{
    public partial class JARVISMainWindow : Form
    {
        public JARVISMainWindow()
        {
            InitializeComponent();
        }

        private void TestButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}
