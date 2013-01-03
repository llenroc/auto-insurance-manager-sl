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
using System.Collections.ObjectModel;
using AutoInsurance.Web;
using System.Collections.Generic;

namespace AutoInsurance.DesignModels
{
    public class DesignCompanies : ObservableCollection<Company>
    {
        public DesignCompanies()
        {
            for (int i = 0; i < 20; i++)
            {
                var company =
                    new Company()
                    {
                        CompanyId = i,
                        Name = "Company "+i,
                        InsuranceBasePrice = 100+i*10
                    };
                Add(company);
            }

        }
    }
}
