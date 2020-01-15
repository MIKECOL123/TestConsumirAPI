using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestConsumirAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region UI event handlers 
        private void btnGo_Click(object sender, EventArgs e)
        {

           // debugOutput("this si some that I can use to test stuff");

            RestClient rClient = new RestClient();

            rClient.endPoint = txtRestURL.Text;
           // debugOutput("RESTClient Object created!");

            string strJSON = string.Empty;

            strJSON = rClient.makeRequest();

            debugOutput(strJSON);
        }
        //QuickTest
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
                //test
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
        #endregion
    }
}
