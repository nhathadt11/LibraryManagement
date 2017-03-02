using BussinessLogic.DataTransferObjects;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class CopyDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        public CopyDialog()
        {
            InitializeComponent();
        }
        public CopyDialog(DataRow row ) : this()
        {

        }

        public DataTranseferObject GetCurrentObject()
        {
            throw new NotImplementedException();
        }
    }
}
