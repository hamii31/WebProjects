using PowerliftingCalculator.Models.CalculatorViewModel;

namespace PowerliftingCalculator.Service.Interfaces
{
    public interface ICalculatorService
    {
        double Total(CalculatorViewModel input);
    }
}
