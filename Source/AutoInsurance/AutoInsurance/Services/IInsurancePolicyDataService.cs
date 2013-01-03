using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using AutoInsurance.Web;



namespace AutoInsurance.Services
{
    public interface IInsurancePolicyDataService
    {
        event EventHandler<HasChangesEventArgs> NotifyHasChanges;	

        void Save(Action<SubmitOperation> submitCallback, object state);

        void GetInsurancePolicyById(int insurancePolicyId, Action<ObservableCollection<InsurancePolicy>> getInsurancePolicyCallback);

        void GetInsurancePolicyList(
            Action<ObservableCollection<InsurancePolicy>> getInsurancePoliciesCallback,
            int pageSize);

        void Save(InsurancePolicy insurancePolicy ,Action<SubmitOperation> submitCallback, object state);
    }
}