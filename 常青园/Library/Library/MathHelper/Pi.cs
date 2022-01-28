namespace Library.MathHelper
{
    public class Pi
    {
        public static string GetPi(int count)
        {
            double sum = 0.5, t, t1, t2, t3, p = 0.5 * 0.5;
            int odd = 1, even = 2;
            t = t1 = t2 = 1.0; t3 = 0.5;
            while (t > 1e-10)
            {
                t1 = t1 * odd / even;
                odd += 2; even += 2;
                t2 = 1.0 / odd;
                t3 = t3 * p;
                t = t1 * t2 * t3;
                sum = sum + t;
            }
            return (sum * 6).ToString();
        }
    }
}
