using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using Microsoft.Windows.Data.DomainServices;
using AutoInsurance.Web;
using AutoInsurance.Web.Services;

namespace AutoInsurance.Services
{
    public class CompanyDataService : ICompanyDataService
    {
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;
        public AutoInsuranceContext Context { get; set; }
        private Action<ObservableCollection<Company>> _getCompaniesCallback;

        private LoadOperation<Company> _companiesLoadOperation;
        //private int _pageIndex;

        /// <summary>
        /// Initialize the CompanyDataContext
        /// </summary>
        public CompanyDataService()
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
        /// Load CompanyList
        /// </summary>
        /// <param name="getCompaniesCallback">CallBack to be called after load complition</param>
        /// <param name="pageSize"></param>
        public void GetCompanyList(Action<ObservableCollection<Company>> getCompaniesCallback, int pageSize)
        {
            ClearCompanies();
            var query = Context.GetCompaniesQuery().Take(pageSize);
            RunCompaniesQuery(query, getCompaniesCallback);
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
        /// Clear Company List
        /// </summary>
        private void ClearCompanies()
        {
            //_pageIndex = 0;
            Context.Companies.Clear();
        }

        /// <summary>
        /// Run Companies Query
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="getCompaniesCallback">CallBack</param>
        private void RunCompaniesQuery(EntityQuery<Company> query, Action<ObservableCollection<Company>> getCompaniesCallback)
        {
            _getCompaniesCallback = getCompaniesCallback;
            _companiesLoadOperation = Context.Load<Company>(query);
            _companiesLoadOperation.Completed += OnLoadCompaniesCompleted;
        }

        /// <summary>
        /// Companies loading Completed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadCompaniesCompleted(object sender, EventArgs e)
        {
            _companiesLoadOperation.Completed -= OnLoadCompaniesCompleted;
            var companies = new EntityList<Company>(Context.Companies, _companiesLoadOperation.Entities);
            _getCompaniesCallback(companies);
        }

        /// <summary>
        /// Get Company by Id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="getCompaniesCallback"></param>
        public void GetCompanyById(int companyId, Action<ObservableCollection<Company>> getCompanyCallback)
        {
            ClearCompanies();
            var query = Context.GetCompaniesQuery().Where(mm => mm.CompanyId == companyId);
            RunCompaniesQuery(query, getCompanyCallback);
        }
    }
}