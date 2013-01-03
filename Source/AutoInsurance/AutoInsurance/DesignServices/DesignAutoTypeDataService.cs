using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using Microsoft.Windows.Data.DomainServices;
using AutoInsurance.Web;
using AutoInsurance.Web.Services;

namespace AutoInsurance.Services
{
    public class DesignAutoTypeDataService : IAutoTypeDataService
    {
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;
        public AutoInsuranceContext Context { get; set; }
        private Action<ObservableCollection<AutoType>> _getAutoTypesCallback;

        private LoadOperation<AutoType> _autoTypesLoadOperation;
        //private int _pageIndex;

        /// <summary>
        /// Initialize the AutoTypeDataContext
        /// </summary>
        public DesignAutoTypeDataService()
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
        /// Load AutoTypeList
        /// </summary>
        /// <param name="getAutoTypesCallback">CallBack to be called after load complition</param>
        /// <param name="pageSize"></param>
        public void GetAutoTypeList(Action<ObservableCollection<AutoType>> getAutoTypesCallback, int pageSize)
        {
            ClearAutoTypes();
            var query = Context.GetAutoTypesQuery().Take(pageSize);
            RunAutoTypesQuery(query, getAutoTypesCallback);
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
        /// Clear AutoType List
        /// </summary>
        private void ClearAutoTypes()
        {
            //_pageIndex = 0;
            Context.AutoTypes.Clear();
        }

        /// <summary>
        /// Run AutoTypes Query
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="getAutoTypesCallback">CallBack</param>
        private void RunAutoTypesQuery(EntityQuery<AutoType> query, Action<ObservableCollection<AutoType>> getAutoTypesCallback)
        {
            _getAutoTypesCallback = getAutoTypesCallback;
            _autoTypesLoadOperation = Context.Load<AutoType>(query);
            _autoTypesLoadOperation.Completed += OnLoadAutoTypesCompleted;
        }

        /// <summary>
        /// AutoTypes loading Completed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadAutoTypesCompleted(object sender, EventArgs e)
        {
            _autoTypesLoadOperation.Completed -= OnLoadAutoTypesCompleted;
            var autoTypes = new EntityList<AutoType>(Context.AutoTypes, _autoTypesLoadOperation.Entities);
            _getAutoTypesCallback(autoTypes);
        }

        /// <summary>
        /// Get AutoType by Id
        /// </summary>
        /// <param name="autoTypeId"></param>
        /// <param name="getAutoTypesCallback"></param>
        public void GetAutoTypeById(int autoTypeId, Action<ObservableCollection<AutoType>> getAutoTypeCallback)
        {
            ClearAutoTypes();
            var query = Context.GetAutoTypesQuery().Where(mm => mm.AutoTypeId == autoTypeId);
            RunAutoTypesQuery(query, getAutoTypeCallback);
        }
    }
}