using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using AutoInsurance.Web;


namespace AutoInsurance.Services
{
    public interface IFuelTypeDataService
    {
        event EventHandler<HasChangesEventArgs> NotifyHasChanges;	

        void Save(Action<SubmitOperation> submitCallback, object state);

        void GetFuelTypeById(int fuelTypeId, Action<ObservableCollection<FuelType>> getFuelTypeCallback);

        void GetFuelTypeList(
            Action<ObservableCollection<FuelType>> getFuelTypesCallback,
            int pageSize);


    }
}