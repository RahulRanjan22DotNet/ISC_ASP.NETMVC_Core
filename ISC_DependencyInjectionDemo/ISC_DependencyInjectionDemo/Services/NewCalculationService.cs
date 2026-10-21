namespace ISC_DependencyInjectionDemo.Services
{
    public class NewCalculationService : ICalculationService
    {
        public int Add(int x, int y)
        {
            int res = x + y;
            return res;
        }

        public int Divide(int x, int y)
        {
            int res = x / y;
            return res;
        }

        public int Multiply(int x, int y)
        {
            int res = x * y;
            return res;
        }

        public int Sub(int x, int y)
        {
            int res = x - y;
            return res;
        }
    }
}
