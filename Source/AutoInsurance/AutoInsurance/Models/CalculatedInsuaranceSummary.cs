using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AutoInsurance.Models
{
    public class CalculatedInsuaranceSummary
    {
        public CalculatedInsuaranceSummary(int companyId,
                              string companyName,
                              double price)
        {
            this.CompanyId = companyId;
            this.CompanyName = companyName;
            this.Price = price;
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public double Price { get; set; }
    }
}
