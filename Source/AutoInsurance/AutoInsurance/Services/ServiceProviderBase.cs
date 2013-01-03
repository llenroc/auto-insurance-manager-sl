using System.ComponentModel;

namespace AutoInsurance.Services
{
    public abstract class ServiceProviderBase
    {
        public virtual IInsurancePolicyDataService InsurancePolicyDataService { get; protected set; }
        public virtual IAutoDataService AutoDataService { get; protected set; }
        public virtual IAutoTypeDataService AutoTypeDataService { get; protected set; }
        public virtual IFuelTypeDataService FuelTypeDataService { get; protected set; }
        public virtual IPurposeDataService PurposeDataService { get; protected set; }
        public virtual ICompanyDataService CompanyDataService { get; protected set; }


        private static ServiceProviderBase _instance;
        public static ServiceProviderBase Instance
        {
            get { return _instance ?? CreateInstance(); }
        }

        static ServiceProviderBase CreateInstance()
        {
            // TODO:  Uncomment
            return _instance = new ServiceProvider();
            //return _instance = DesignerProperties.IsInDesignTool ?
            //    (ServiceProviderBase)new DesignServiceProvider() : new ServiceProvider();
            
            // TODO:  Comment
            // return _instance = new ServiceProvider();
        }
    }
}