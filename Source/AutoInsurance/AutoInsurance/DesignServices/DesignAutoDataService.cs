using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using Microsoft.Windows.Data.DomainServices;
using AutoInsurance.Web;
using AutoInsurance.Web.Services;

namespace AutoInsurance.Services
{
    public class DesignAutoDataService : IAutoDataService
    {
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;
        public AutoInsuranceContext Context { get; set; }
        private Action<ObservableCollection<Auto>> _getAutosCallback;

        private LoadOperation<Auto> _autosLoadOperation;
        //private int _pageIndex;

        /// <summary>
        /// Initialize the AutoDataContext
        /// </summary>
        public DesignAutoDataService()
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
        /// Load AutoList
        /// </summary>
        /// <param name="getAutosCallback">CallBack to be called after load complition</param>
        /// <param name="pageSize"></param>
        public void GetAutoList(Action<ObservableCollection<Auto>> getAutosCallback, int pageSize)
        {
            ClearAutos();
            var query = Context.GetAutosQuery().Take(pageSize);
            RunAutosQuery(query, getAutosCallback);
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
        /// Clear Auto List
        /// </summary>
        private void ClearAutos()
        {
            //_pageIndex = 0;
            Context.Autos.Clear();
        }

        /// <summary>
        /// Run Autos Query
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="getAutosCallback">CallBack</param>
        private void RunAutosQuery(EntityQuery<Auto> query, Action<ObservableCollection<Auto>> getAutosCallback)
        {
            _getAutosCallback = getAutosCallback;
            _autosLoadOperation = Context.Load<Auto>(query);
            _autosLoadOperation.Completed += OnLoadAutosCompleted;
        }

        /// <summary>
        /// Autos loading Completed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadAutosCompleted(object sender, EventArgs e)
        {
            _autosLoadOperation.Completed -= OnLoadAutosCompleted;
            var autos = new EntityList<Auto>(Context.Autos, _autosLoadOperation.Entities);
            _getAutosCallback(autos);
        }

        /// <summary>
        /// Get Auto by Id
        /// </summary>
        /// <param name="autoId"></param>
        /// <param name="getAutosCallback"></param>
        public void GetAutoById(int autoId, Action<ObservableCollection<Auto>> getAutoCallback)
        {
            ClearAutos();
            var query = Context.GetAutosQuery().Where(mm => mm.AutoId == autoId);
            RunAutosQuery(query, getAutoCallback);
        }
    }
}