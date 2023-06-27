using PowerliftingCalculator.Models.CalculatorViewModel;
using PowerliftingCalculator.Service.Interfaces;

namespace PowerliftingCalculator.Service
{
    public class CalculatorService : ICalculatorService
    {
        double ICalculatorService.Total(CalculatorViewModel input)
        {
            input.Total = input.Squat1RM + input.Bench1RM + input.Deadlift1RM;

            return input.Total;
        }
    }
}
