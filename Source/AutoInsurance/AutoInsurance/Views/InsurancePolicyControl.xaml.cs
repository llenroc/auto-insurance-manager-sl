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
using System.Windows.Data;
using AutoInsurance.ViewModels;

namespace AutoInsurance.Views
{
    public partial class InsurancePolicyControl : UserControl
    {
        public InsurancePolicyControl()
        {
            InitializeComponent();
        }

        private void grid1_Loaded(object sender, RoutedEventArgs e)
        {

            Binding b = new Binding("InsurancePolicy");
            InsurancePolicyViewModel dataContext = ((InsurancePolicyViewModel)LayoutRoot.DataContext);
            b.Source = dataContext;
            b.Mode = BindingMode.TwoWay;
            grid1.ClearValue(Grid.DataContextProperty);
            grid1.SetBinding(Grid.DataContextProperty, b);//rrebind
        }
    }
}
