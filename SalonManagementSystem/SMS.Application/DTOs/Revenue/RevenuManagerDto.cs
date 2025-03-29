using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Revenue
{
    public class RevenueManagerDto
    {
        public decimal DailyRevenue { get; set; }
        public decimal WeeklyRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }

        public decimal TotalRevenue { get; set; }
        public DateTime LastUpdated { get; set; }

        public int DailyTransactions { get; set; }
        public int WeeklyTransactions { get; set; }
        public int MonthlyTransactions { get; set; }

        public Dictionary<string, decimal> RevenueByService { get; set; }
        public Dictionary<string, decimal> RevenueBySalon { get; set; }
        public Dictionary<string, decimal> RevenueByStylist { get; set; }

        public RevenueManagerDto()
        {
            RevenueByService = new Dictionary<string, decimal>();
            RevenueBySalon = new Dictionary<string, decimal>();
            RevenueByStylist = new Dictionary<string, decimal>();
        }
    }
}
