using BussinessLogic.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class LoanDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        public LoanDialog()
        {
            InitializeComponent();
        }
        public LoanDialog(DataRow row) : this()
        {

        }

        public DataTranseferObject GetCurrentObject()
        {
            throw new NotImplementedException();
        }
    }
}
