﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    interface IAverageMark
    {
        int Math { get; set; }
        int Philosophy { get; set; }
        int HistOfBel { get; set; }
        double averMark();
        string checkRetake();
    }
}
