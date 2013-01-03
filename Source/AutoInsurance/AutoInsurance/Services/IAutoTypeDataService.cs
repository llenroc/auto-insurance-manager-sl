using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using AutoInsurance.Web;


namespace AutoInsurance.Services
{
    public interface IAutoTypeDataService
    {
        event EventHandler<HasChangesEventArgs> NotifyHasChanges;	

        void Save(Action<SubmitOperation> submitCallback, object state);

        void GetAutoTypeById(int autoTypeId, Action<ObservableCollection<AutoType>> getAutoTypeCallback);

        void GetAutoTypeList(
            Action<ObservableCollection<AutoType>> getAutoTypesCallback,
            int pageSize);


    }
}