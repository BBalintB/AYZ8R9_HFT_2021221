﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Logic.Exceptions
{
    public class JerseyNumberIsNotGood : Exception
    {
        public JerseyNumberIsNotGood(string message) : base(message)
        {
        }
    }
}
