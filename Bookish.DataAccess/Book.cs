﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Bookish.DataAccess
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int Copies { get; set; }
        public int Barcode { get; set; }
        public DateTime Loandate { get; set; }
        public DateTime Duedate { get; set; }
    }
}
