using System;
using System.Windows.Forms;

namespace ScreenReaderTest.Output
{
    public partial class Form1 : Form
    {
        private JavaAccessBridge _javaAccessBridge;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _javaAccessBridge = new JavaAccessBridge();
            _javaAccessBridge.Initialize();
        }
    }
}
