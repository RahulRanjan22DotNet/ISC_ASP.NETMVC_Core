namespace ISC_DependencyInjectionDemo.Services
{
    public interface ICalculationService
    {
        public int Add(int x, int y);
        public int Sub(int x, int y);
        public int Multiply(int x, int y);
        public int Divide(int x, int y);
    }
}
