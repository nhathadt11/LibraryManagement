using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Host
{
    public partial class frmServer : Form
    {
        ServiceHost authorService;
        public frmServer()
        {
            InitializeComponent();
            authorService = new ServiceHost(typeof(Service.AuthorService));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //authorService.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                //authorService.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
        }
    }
}
