﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;
namespace LibraryMaragementClient
{
    public partial class FormAuthor : Form
    {
        private Service. _authorService;
        public FormAuthor()
        {
            InitializeComponent();
        }

        private void FormAuthor_Load(object sender, EventArgs e)
        {
        }
    }
}
