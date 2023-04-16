﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWay.Entities.Exceptions
{
    public class GeneralException:Exception
    {
        public string Details { get; set; }
        public GeneralException() { }
        public GeneralException(string message) : base(message) { }
        public GeneralException(string message, Exception innerException) : base(message, innerException) { }


        public GeneralException(string title, string detail) : base(title) => Details = detail; 
    }
}
