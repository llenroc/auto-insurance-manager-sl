using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using AutoInsurance.ViewModels;

namespace AutoInsurance.Views
{
    public partial class CalculateInsurancePriceControl : UserControl
    {
        public CalculateInsurancePriceControl()
        {
            InitializeComponent();

            //CalculateInsurancePriceViewModel viemModel = new CalculateInsurancePriceViewModel();
            //this.DataContext = viemModel;
        }

    }
}
