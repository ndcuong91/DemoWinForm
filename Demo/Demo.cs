using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Demo : Form
    {
        int nIndex = 0;
        string[] sFileNames;
        int nFileCount;
        public Demo()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "*.jpg ,*.png ,*.bmp,*.gif | *.jpg;*.png ;*.bmp;*.gif;";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                sFileNames = openFile.FileNames;
                nFileCount = openFile.FileNames.Length;
                fnDisplay(nIndex);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (nIndex > 0) nIndex--;
            else nIndex = nFileCount - 1;
            fnDisplay(nIndex);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (nIndex < nFileCount - 1) nIndex++;
            else nIndex = 0;
            fnDisplay(nIndex);
        }

        public void fnDisplay(int nIndex)
        {
            Bitmap bmp = new Bitmap(sFileNames[nIndex]); 
            pbMain.Image = bmp;
            //pbSobel.Image = m_GrayOuts[nIndex].ToBitmap();
            labelResult.Text = nIndex.ToString();
        }
    }
}
