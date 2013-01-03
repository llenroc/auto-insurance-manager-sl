using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using Microsoft.Windows.Data.DomainServices;
using AutoInsurance.Web;
using AutoInsurance.Web.Services;

namespace AutoInsurance.Services
{
    public class InsurancePolicyDataService : IInsurancePolicyDataService
    {
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;
        public AutoInsuranceContext Context { get; set; }
        private Action<ObservableCollection<InsurancePolicy>> _getInsurancePoliciesCallback;

        private LoadOperation<InsurancePolicy> _insurancePolicysLoadOperation;
        //private int _pageIndex;

        /// <summary>
        /// Initialize the InsurancePolicyDataContext
        /// </summary>
        public InsurancePolicyDataService()
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
        /// Load InsurancePolicyList
        /// </summary>
        /// <param name="getInsurancePoliciesCallback">CallBack to be called after load complition</param>
        /// <param name="pageSize"></param>
        public void GetInsurancePolicyList(Action<ObservableCollection<InsurancePolicy>> getInsurancePoliciesCallback, int pageSize)
        {
            ClearInsurancePolicies();
            var query = Context.GetInsurancePoliciesQuery().Take(pageSize);
            RunInsurancePoliciesQuery(query, getInsurancePoliciesCallback);
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
        /// Clear InsurancePolicy List
        /// </summary>
        private void ClearInsurancePolicies()
        {
            //_pageIndex = 0;
            Context.InsurancePolicies.Clear();
        }

        /// <summary>
        /// Run InsurancePolicies Query
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="getInsurancePoliciesCallback">CallBack</param>
        private void RunInsurancePoliciesQuery(EntityQuery<InsurancePolicy> query, Action<ObservableCollection<InsurancePolicy>> getInsurancePoliciesCallback)
        {
            _getInsurancePoliciesCallback = getInsurancePoliciesCallback;
            _insurancePolicysLoadOperation = Context.Load<InsurancePolicy>(query);
            _insurancePolicysLoadOperation.Completed += OnLoadInsurancePoliciesCompleted;
        }

        /// <summary>
        /// InsurancePolicies loading Completed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadInsurancePoliciesCompleted(object sender, EventArgs e)
        {
            _insurancePolicysLoadOperation.Completed -= OnLoadInsurancePoliciesCompleted;
            var insurancePolicys = new EntityList<InsurancePolicy>(Context.InsurancePolicies, _insurancePolicysLoadOperation.Entities);
            _getInsurancePoliciesCallback(insurancePolicys);
        }

        /// <summary>
        /// Get InsurancePolicy by Id
        /// </summary>
        /// <param name="insurancePolicyId"></param>
        /// <param name="getInsurancePoliciesCallback"></param>
        public void GetInsurancePolicyById(int insurancePolicyId, Action<ObservableCollection<InsurancePolicy>> getInsurancePolicyCallback)
        {
            ClearInsurancePolicies();
            var query = Context.GetInsurancePoliciesQuery().Where(mm => mm.InsurancePolicyId == insurancePolicyId);
            RunInsurancePoliciesQuery(query, getInsurancePolicyCallback);
        }

        #region IInsurancePolicyDataService Members


        public void Save(InsurancePolicy insurancePolicy, Action<SubmitOperation> submitCallback, object state)
        {
            if (insurancePolicy == null)
            {
                return;
            }

            if (insurancePolicy.InsurancePolicyId == 0)
            {
                Context.InsurancePolicies.Add(insurancePolicy);
            }

            if (Context.HasChanges)
            {
                Context.SubmitChanges(submitCallback, state);
            }
        }

        #endregion
    }
}