using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using AutoInsurance.Web;


namespace AutoInsurance.Services
{
    public interface ICompanyDataService
    {
        event EventHandler<HasChangesEventArgs> NotifyHasChanges;	

        void Save(Action<SubmitOperation> submitCallback, object state);

        void GetCompanyById(int companyId, Action<ObservableCollection<Company>> getCompanyCallback);

        void GetCompanyList(
            Action<ObservableCollection<Company>> getCompaniesCallback,
            int pageSize);


    }
}