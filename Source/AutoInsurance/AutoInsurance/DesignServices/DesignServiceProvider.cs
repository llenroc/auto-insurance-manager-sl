using AutoInsurance.Web;
namespace AutoInsurance.Services
{
    public class DesignServiceProvider : ServiceProviderBase
    {
        public DesignServiceProvider()
        {
            // Do this if you want one service for your app.
            //PageConductor = new PageConductor(); 
        }

        public override IInsurancePolicyDataService InsurancePolicyDataService
        {
            get { return new InsurancePolicyDataService(); }
        }

        public override IPurposeDataService PurposeDataService
        {
            get { return new PurposeDataService(); }
        }

        public override IAutoTypeDataService AutoTypeDataService
        {
            get { return new AutoTypeDataService(); }
        }

        public override IFuelTypeDataService FuelTypeDataService
        {
            get { return new FuelTypeDataService(); }
        }

        public override ICompanyDataService CompanyDataService
        {
            get { return new CompanyDataService(); }
        }

        public override IAutoDataService AutoDataService
        {
            get { return new AutoDataService(); }
        }
    }
}