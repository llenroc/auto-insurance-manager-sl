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

namespace AutoInsurance.Web
{
    public partial class Company 
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    RaiseDataMemberChanged("IsChecked");
                }
            }
        }

        public double CalculatePrice(            
                        double autoTypeCoeficient,
                        double purposeCoefficient,
                        int driverExperience,
                        int vechicleDisplacement,
                        int firstYearOfRegitration,
                        int seatsCount,
                        int loadingCapacity
            )
        {
            //double autoTypeCoeficient = 0.0;//out
            //double purposeCoefficient = 0.0;//out
            //int driverExperience = 5;//out
            //int vechicleDisplacement = 1400;//out
            int autoAge = DateTime.Now.Year - firstYearOfRegitration;

            double basePrice = (double)this.InsuranceBasePrice;
            double youngDriverCoeficient = (double)this.YoungDriverCoeficient;
            double oldDriverCoeficient = (double)this.OldDriverCoeficient;
            double autoTypePrice = (double)this.AutoTypePrice;
            double purposePrice = (double)this.PurposePrice;
            double vechicleDisplacementPrice = (double)this.VechicleDisplacementPrice;
            double pricePerAgeYear = (5.00/100.0)*basePrice;
            double seatPrice = 3;
            double loadingCapacityPricePer1000kg = (double)this.LoadingCapacityPricePer1000kg;

            double price = (basePrice * (driverExperience < 5 ? youngDriverCoeficient : oldDriverCoeficient))
                        + (autoTypePrice * autoTypeCoeficient)
                        //+ (HasAccidents ? RiskCoeficient : NoRiskCoeficient)
                        + (purposePrice * purposeCoefficient)
                        + (vechicleDisplacementPrice * vechicleDisplacement * (1 / 1000))
                        + (autoAge * pricePerAgeYear)
                        + (seatsCount * seatPrice)
                        + ((loadingCapacity/1000.00)*loadingCapacityPricePer1000kg)
                        ;

            return price;
        }
    }
}
