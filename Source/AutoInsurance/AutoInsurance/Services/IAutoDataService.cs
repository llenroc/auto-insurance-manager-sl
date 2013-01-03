using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using AutoInsurance.Web;


namespace AutoInsurance.Services
{
    public interface IAutoDataService
    {
        event EventHandler<HasChangesEventArgs> NotifyHasChanges;	

        void Save(Action<SubmitOperation> submitCallback, object state);

        void GetAutoById(int autoId, Action<ObservableCollection<Auto>> getAutoCallback);

        void GetAutoList(
            Action<ObservableCollection<Auto>> getAutosCallback,
            int pageSize);


    }
}