﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClockOn.ViewModel
{
    public class ClockOnViewModel
    {
        public ClockOnViewModel()
        {

        }
        public ClockOnViewModel(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
    }
}
