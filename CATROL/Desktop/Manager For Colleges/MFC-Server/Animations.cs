using ape_UI.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace MFC_Server
{
    public class Animations
    {
        BasicHelper basicHelper;

        public DoubleAnimation FadeIn;
        public DoubleAnimation FadeOut;

        public Animations()
        {
            basicHelper = new BasicHelper();
            FadeIn = basicHelper.CreateDoubleAnimation(TimeSpan.FromMilliseconds(500), 0, 1, FillBehavior.HoldEnd,
                BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            FadeOut = basicHelper.CreateDoubleAnimation(TimeSpan.FromMilliseconds(500), 1, 0, FillBehavior.HoldEnd,
                BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
        }

        public void Dispose()
        {
            FadeIn = null;
            FadeOut = null;
            basicHelper = null;
        }
    }
}
