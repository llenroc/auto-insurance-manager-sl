using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using Microsoft.Windows.Data.DomainServices;
using AutoInsurance.Web;
using AutoInsurance.Web.Services;

namespace AutoInsurance.Services
{
    public class DesignFuelTypeDataService : IFuelTypeDataService
    {
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;
        public AutoInsuranceContext Context { get; set; }
        private Action<ObservableCollection<FuelType>> _getFuelTypesCallback;

        private LoadOperation<FuelType> _fuelTypesLoadOperation;
        //private int _pageIndex;

        /// <summary>
        /// Initialize the FuelTypeDataContext
        /// </summary>
        public DesignFuelTypeDataService()
        {
            Context = new AutoInsuranceContext();
            Context.PropertyChanged += ContextPropertyChanged;
        }

        /// <summary>
        /// Saves changes to the Context if available.
        /// </summary>
        /// <param name="submitCallback">CallBack to be called after load complition</param>
        /// <param name="state"></param>
        public void Save(Action<SubmitOperation> submitCallback, object state)
        {
            if (Context.HasChanges)
            {
                Context.SubmitChanges(submitCallback, state);
            }
        }

        /// <summary>
        /// Load FuelTypeList
        /// </summary>
        /// <param name="getFuelTypesCallback">CallBack to be called after load complition</param>
        /// <param name="pageSize"></param>
        public void GetFuelTypeList(Action<ObservableCollection<FuelType>> getFuelTypesCallback, int pageSize)
        {
            ClearFuelTypes();
            var query = Context.GetFuelTypesQuery().Take(pageSize);
            RunFuelTypesQuery(query, getFuelTypesCallback);
        }

        /// <summary>
        /// Notifies for property changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (NotifyHasChanges != null)
            {
                NotifyHasChanges(this, new HasChangesEventArgs() { HasChanges = Context.HasChanges });
            }
        }

        /// <summary>
        /// Clear FuelType List
        /// </summary>
        private void ClearFuelTypes()
        {
            //_pageIndex = 0;
            Context.FuelTypes.Clear();
        }

        /// <summary>
        /// Run FuelTypes Query
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="getFuelTypesCallback">CallBack</param>
        private void RunFuelTypesQuery(EntityQuery<FuelType> query, Action<ObservableCollection<FuelType>> getFuelTypesCallback)
        {
            _getFuelTypesCallback = getFuelTypesCallback;
            _fuelTypesLoadOperation = Context.Load<FuelType>(query);
            _fuelTypesLoadOperation.Completed += OnLoadFuelTypesCompleted;
        }

        /// <summary>
        /// FuelTypes loading Completed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadFuelTypesCompleted(object sender, EventArgs e)
        {
            _fuelTypesLoadOperation.Completed -= OnLoadFuelTypesCompleted;
            var fuelTypes = new EntityList<FuelType>(Context.FuelTypes, _fuelTypesLoadOperation.Entities);
            _getFuelTypesCallback(fuelTypes);
        }

        /// <summary>
        /// Get FuelType by Id
        /// </summary>
        /// <param name="fuelTypeId"></param>
        /// <param name="getFuelTypesCallback"></param>
        public void GetFuelTypeById(int fuelTypeId, Action<ObservableCollection<FuelType>> getFuelTypeCallback)
        {
            ClearFuelTypes();
            var query = Context.GetFuelTypesQuery().Where(mm => mm.FuelTypeId == fuelTypeId);
            RunFuelTypesQuery(query, getFuelTypeCallback);
        }
    }
}