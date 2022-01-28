using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitX.info
{
    public class runninginfo
    {
        public runninginfo()
        {
            RanTimes = 0;
        }

        public double MWidth { get; set; } // 主窗口宽度

        public double MHeight { get; set; } // 主窗口高度

        public string WorkDirectory { get; set; } // 工作目录

        public int RanTimes { get; set; } // 运行次数

        public Set.Language Now_Lang { get; set; } // 当前语言选择

    }
}
