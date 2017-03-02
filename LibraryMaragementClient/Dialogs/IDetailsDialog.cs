using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMaragementClient.Dialogs
{
    interface IDetailsDialog<IcommonDTO>
    {
        DialogResult ShowDialog();
        IcommonDTO GetCurrentObject();
    }
}
