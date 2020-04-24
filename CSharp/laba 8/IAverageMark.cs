using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_8
{
    interface IAverageMark
    {
        int Math { get; set; }
        int Philosophy { get; set; }
        int HistOfBel { get; set; }
        string averMark();
        string checkRetake();
    }
}
