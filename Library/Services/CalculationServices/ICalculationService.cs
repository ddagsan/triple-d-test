using System;

namespace Services.CalculationServices
{
    public interface ICalculationService
    {
        CalculateModel Calculate(DateTime start, DateTime end, int countryId);
    }
}