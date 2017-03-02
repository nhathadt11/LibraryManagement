using BussinessLogic.DataTransferObjects;
using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    public partial class UserDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        public UserDialog()
        {
            InitializeComponent();
        }
        public UserDialog(DataRow row) : this()
        {

        }

        public DataTranseferObject GetCurrentObject()
        {
            throw new NotImplementedException();
        }
    }
}
