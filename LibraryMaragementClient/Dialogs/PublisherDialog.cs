﻿using BussinessLogic.DataTransferObjects;
using Service;
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
    public partial class PublisherDialog : Form, IDetailsDialog<DataTranseferObject>
    {
        private PublisherService _publisherService;
        private Publisher _publisher;
        public PublisherDialog()
        {
            InitializeComponent();
            _publisherService = new PublisherService();
        }

        public DataTranseferObject GetCurrentObject()
        {
            return _publisher;
        }
    }
}
