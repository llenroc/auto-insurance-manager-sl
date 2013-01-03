using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using Microsoft.Windows.Data.DomainServices;
using AutoInsurance.Web;
using AutoInsurance.Web.Services;

namespace AutoInsurance.Services
{
    public class PurposeDataService : IPurposeDataService
    {
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;
        public AutoInsuranceContext Context { get; set; }
        private Action<ObservableCollection<Purpose>> _getPurposesCallback;

        private LoadOperation<Purpose> _PurposesLoadOperation;
        //private int _pageIndex;

        /// <summary>
        /// Initialize the PurposeDataContext
        /// </summary>
        public PurposeDataService()
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
        /// Load PurposeList
        /// </summary>
        /// <param name="getPurposesCallback">CallBack to be called after load complition</param>
        /// <param name="pageSize"></param>
        public void GetPurposeList(Action<ObservableCollection<Purpose>> getPurposesCallback, int pageSize)
        {
            ClearPurposes();
            var query = Context.GetPurposesQuery().Take(pageSize);
            RunPurposesQuery(query, getPurposesCallback);
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
        /// Clear Purpose List
        /// </summary>
        private void ClearPurposes()
        {
            //_pageIndex = 0;
            Context.Purposes.Clear();
        }

        /// <summary>
        /// Run Purposes Query
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="getPurposesCallback">CallBack</param>
        private void RunPurposesQuery(EntityQuery<Purpose> query, Action<ObservableCollection<Purpose>> getPurposesCallback)
        {
            _getPurposesCallback = getPurposesCallback;
            _PurposesLoadOperation = Context.Load<Purpose>(query);
            _PurposesLoadOperation.Completed += OnLoadPurposesCompleted;
        }

        /// <summary>
        /// Purposes loading Completed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadPurposesCompleted(object sender, EventArgs e)
        {
            _PurposesLoadOperation.Completed -= OnLoadPurposesCompleted;
            var Purposes = new EntityList<Purpose>(Context.Purposes, _PurposesLoadOperation.Entities);
            _getPurposesCallback(Purposes);
        }

        /// <summary>
        /// Get Purpose by Id
        /// </summary>
        /// <param name="PurposeId"></param>
        /// <param name="getPurposesCallback"></param>
        public void GetPurposeById(int PurposeId, Action<ObservableCollection<Purpose>> getPurposeCallback)
        {
            ClearPurposes();
            var query = Context.GetPurposesQuery().Where(mm => mm.PurposeId == PurposeId);
            RunPurposesQuery(query, getPurposeCallback);
        }
    }
}