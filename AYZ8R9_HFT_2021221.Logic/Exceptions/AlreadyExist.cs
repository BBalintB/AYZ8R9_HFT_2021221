﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Logic.Exceptions
{
    public class AlreadyExist : Exception
    {
        public AlreadyExist(string message) : base(message)
        {
        }
    }
}
