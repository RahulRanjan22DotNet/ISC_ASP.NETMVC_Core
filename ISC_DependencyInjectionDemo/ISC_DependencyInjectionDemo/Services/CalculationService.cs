namespace ISC_DependencyInjectionDemo.Services
{
    public class CalculationService : ICalculationService
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Divide(int x, int y)
        {
            return x / y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
}
