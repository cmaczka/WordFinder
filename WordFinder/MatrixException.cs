﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    public class MatrixException: Exception
    {
        public MatrixException() { }
        public MatrixException(string message):base(message) { }
    }
}
