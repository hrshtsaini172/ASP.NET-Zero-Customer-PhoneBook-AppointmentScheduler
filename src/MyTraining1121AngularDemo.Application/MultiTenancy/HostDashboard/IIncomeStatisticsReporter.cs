using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyTraining1121AngularDemo.MultiTenancy.HostDashboard.Dto;

namespace MyTraining1121AngularDemo.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}