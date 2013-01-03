using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using AutoInsurance.Web;


namespace AutoInsurance.Services
{
    public interface IPurposeDataService
    {
        event EventHandler<HasChangesEventArgs> NotifyHasChanges;	

        void Save(Action<SubmitOperation> submitCallback, object state);

        void GetPurposeById(int PurposeId, Action<ObservableCollection<Purpose>> getPurposeCallback);

        void GetPurposeList(
            Action<ObservableCollection<Purpose>> getPurposesCallback,
            int pageSize);
    }
}