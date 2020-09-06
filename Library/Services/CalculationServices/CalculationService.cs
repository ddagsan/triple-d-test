using Core.Domain;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.CalculationServices
{
    public class CalculationService : ICalculationService
    {
        private readonly IRepository<Country> _countryRepo;
        private readonly IRepository<Setting> _settingRepo;
        private const string ReservationLimitKey = "ReservationLimitOfAnyBook";
        private const string PenaltyFeeKey = "PenaltyFee";
        public CalculationService(
            IRepository<Country> countryRepo,
            IRepository<Setting> settingRepo
            )
        {
            _countryRepo = countryRepo;
            _settingRepo = settingRepo;
        }
        public CalculateModel Calculate(DateTime start, DateTime end, int countryId)
        {
            var limitSetting = _settingRepo.Table.FirstOrDefault(m => m.Key == ReservationLimitKey);
            if (limitSetting == null)
            {
                throw new Exception($"{ReservationLimitKey} setting cannot found.");
            }
            int limit = int.Parse(_settingRepo.Table.FirstOrDefault(m => m.Key == ReservationLimitKey).Value);
            var penaltyFeeSetting = _settingRepo.Table.FirstOrDefault(m => m.Key == PenaltyFeeKey);
            if (penaltyFeeSetting == null)
            {
                throw new Exception($"{PenaltyFeeKey} setting cannot found.");
            }
            int penaltyFee = int.Parse(penaltyFeeSetting.Value);
            var country = _countryRepo.Table.Include("SpecialDays").Include("OffDaysOfWeek").FirstOrDefault(m => m.Id == countryId);

            var retVal = new CalculateModel(limit, penaltyFee, country.Currency);

            var offDays = country.OffDaysOfWeek.Select(m => m.DayOfWeek);
            var specialDays = country.SpecialDays.Select(m => m.SpecialDate);

            var dates = Enumerable.Range(0, 1 + end.Subtract(start).Days)
                .Select(offset => start.AddDays(offset)) //all dates between start and end ones
                .Where(day => !offDays.Contains(day.DayOfWeek)) //exclude off days
                .Select(m => m.Date)//get all as only date format without time 
                .Where(m => !specialDays.Contains(m));//subtract special days

            int totalDayCount = dates.Count();

            retVal.TotalDayCount = totalDayCount;
            return retVal;
        }
    }
}
