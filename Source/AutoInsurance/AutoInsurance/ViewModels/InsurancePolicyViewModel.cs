using GalaSoft.MvvmLight;
using AutoInsurance.Web;
using AutoInsurance.Services;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using AutoInsurance.Messages;
using System.ServiceModel.DomainServices.Client;
using GalaSoft.MvvmLight.Command;

namespace AutoInsurance.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class InsurancePolicyViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the InsurancePolicyViewModel class.
        /// </summary>
        public InsurancePolicyViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                this.RegisterMessage();
                LoadNomenclatures();
            }
        }

        private void RegisterMessage()
        {
            Messenger.Default.Register<LaunchEditInsuarancePolicyMessage>(this, OnLaunchEditInsurancePolicy);
        }

        private void OnLaunchEditInsurancePolicy(LaunchEditInsuarancePolicyMessage msg)
        {
            var insuranceToEdit = msg.InsuarancePolicy;
            this.InsurancePolicy = insuranceToEdit;
        }

        #region InsurancePolicyDataService
        private IInsurancePolicyDataService insurancePolicyDataService;

        public IInsurancePolicyDataService InsurancePolicyDataService
        {
            get 
            {
                if (insurancePolicyDataService == null)
                {
                    insurancePolicyDataService = ServiceProvider.Instance.InsurancePolicyDataService;
                }
                return insurancePolicyDataService; 
            }
            set 
            {
                insurancePolicyDataService = value; 
            }
        }
        
        private void SaveInsurancePolicy()
        {
            InsurancePolicyDataService.Save(InsurancePolicy, OnSaveCallBack, null);
        }

        private void OnSaveCallBack(SubmitOperation op)
        {
            string msg = string.Empty;
            if (op.HasError)
            {
                msg = "Неуспешно съхраняване на полицата!:" + op.Error.Message;
                op.MarkErrorAsHandled();
            }
            else
            {
                msg = "Полицата е изпратена узпешно!";
            }

            Messenger.Default.Send<SaveInsuarancePolicyMessageDialog>(new SaveInsuarancePolicyMessageDialog(msg, "Изпращане на полица"));
        }
        #endregion

        #region View Properties
        #region InsurancePolicy
        /// <summary>
        /// The <see cref="InsurancePolicy" /> property's name.
        /// </summary>
        public const string InsurancePolicyPropertyName = "InsurancePolicy";

        private InsurancePolicy _insurancePolicy;

        /// <summary>
        /// Gets the InsurancePolicy property. This is the Insurance Policy Object
        /// </summary>
        public InsurancePolicy InsurancePolicy
        {
            get
            {
                return _insurancePolicy;
            }

            set
            {
                if (_insurancePolicy == value)
                {
                    return;
                }

                var oldValue = _insurancePolicy;
                _insurancePolicy = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(InsurancePolicyPropertyName);

                if (_insurancePolicy != null)
                {
                    CanSaveInsurancePolicy = true;
                }
                //// Update bindings and broadcast change using GalaSoft.MvvmLight.Messenging
                //RaisePropertyChanged(InsurancePolicyPropertyName, oldValue, value, true);
            }
        }
        #endregion
        #endregion

        #region Nomenclatures
        public void LoadNomenclatures()
        {
            LoadAutoTypes();
            LoadPurposes();
            LoadFuelTypes();
            LoadCompanys();
        }
        #region AutoType
        private IAutoTypeDataService autoTypeDataService;
        protected IAutoTypeDataService AutoTypeDataService
        {
          get 
          { 
              if(autoTypeDataService == null)
              {
                  autoTypeDataService = ServiceProvider.Instance.AutoTypeDataService;
              }
              return autoTypeDataService; 
          }
          set 
          {
              autoTypeDataService = value; 
          }
        }

        /// <summary>
        /// Call Load Method of the DataSevrice
        /// </summary>
        public void LoadAutoTypes()
        {
            AutoTypes = null;
            AutoTypeDataService.GetAutoTypeList(OnAutoTypesLoad, int.MaxValue);
        }

        public ObservableCollection<AutoType> AutoTypes { get; set; }
                   
        public void OnAutoTypesLoad(ObservableCollection<AutoType> autoTypes)
        {
            this.AutoTypes = autoTypes;
        }
        #endregion

        #region Purpose
        private IPurposeDataService _PurposeDataService;
        protected IPurposeDataService PurposeDataService
        {
          get 
          { 
              if(_PurposeDataService == null)
              {
                  _PurposeDataService = ServiceProvider.Instance.PurposeDataService;
              }
              return _PurposeDataService; 
          }
          set 
          {
              _PurposeDataService = value; 
          }
        }

        /// <summary>
        /// Call Load Method of the DataSevrice
        /// </summary>
        public void LoadPurposes()
        {
            Purposes = null;
            PurposeDataService.GetPurposeList(OnPurposesLoad, int.MaxValue);
        }

        public ObservableCollection<Purpose> Purposes { get; set; }
                   
        public void OnPurposesLoad(ObservableCollection<Purpose> Purposes)
        {
            this.Purposes = Purposes;
        }
        #endregion

        #region FuelType
                //<ComboBox Grid.Column="1" Grid.Row="2" Height="23" HorizontalAlignment="Stretch" Margin="3" 
                //         Name="FuelTypeComboBox" 
                //         SelectedValue="{Binding Path=Auto.FuelTypeId, Mode=OneWay, NotifyOnValidationError=true, ValidatesOnExceptions=true, TargetNullValue=''}" VerticalAlignment="Center" Width="Auto" Grid.ColumnSpan="1" Grid.RowSpan="1" 
                //          SelectedValuePath="FuelTypeId"
                //          DisplayMemberPath="Name"
                //          ItemsSource="{Binding ElementName=LayoutRoot, Path=DataContext.FuelTypes}"
                //          />
        private IFuelTypeDataService _FuelTypeDataService;
        protected IFuelTypeDataService FuelTypeDataService
        {
            get
            {
                if (_FuelTypeDataService == null)
                {
                    _FuelTypeDataService = ServiceProvider.Instance.FuelTypeDataService;
                }
                return _FuelTypeDataService;
            }
            set
            {
                _FuelTypeDataService = value;
            }
        }

        /// <summary>
        /// Call Load Method of the DataSevrice
        /// </summary>
        public void LoadFuelTypes()
        {
            FuelTypes = null;
            FuelTypeDataService.GetFuelTypeList(OnFuelTypesLoad, int.MaxValue);
        }

        public ObservableCollection<FuelType> FuelTypes { get; set; }

        public void OnFuelTypesLoad(ObservableCollection<FuelType> FuelTypes)
        {
            this.FuelTypes = FuelTypes;
        }
        #endregion

        #region Company
                //<ComboBox Grid.Column="1" Grid.Row="2" Height="23" HorizontalAlignment="Stretch" Margin="3" 
                //         Name="CompanyComboBox" 
                //         SelectedValue="{Binding Path=Auto.CompanyId, Mode=OneWay, NotifyOnValidationError=true, ValidatesOnExceptions=true, TargetNullValue=''}" VerticalAlignment="Center" Width="Auto" Grid.ColumnSpan="1" Grid.RowSpan="1" 
                //          SelectedValuePath="CompanyId"
                //          DisplayMemberPath="Name"
                //          ItemsSource="{Binding ElementName=LayoutRoot, Path=DataContext.Companys}"
                //          />
        private ICompanyDataService _CompanyDataService;
        protected ICompanyDataService CompanyDataService
        {
            get
            {
                if (_CompanyDataService == null)
                {
                    _CompanyDataService = ServiceProvider.Instance.CompanyDataService;
                }
                return _CompanyDataService;
            }
            set
            {
                _CompanyDataService = value;
            }
        }

        /// <summary>
        /// Call Load Method of the DataSevrice
        /// </summary>
        public void LoadCompanys()
        {
            Companys = null;
            CompanyDataService.GetCompanyList(OnCompanysLoad, int.MaxValue);
        }

        public ObservableCollection<Company> Companys { get; set; }

        public void OnCompanysLoad(ObservableCollection<Company> Companys)
        {
            this.Companys = Companys;
        }
        #endregion
        #endregion

        #region Commands
        #region SaveInsurancePolicyCommand

        private RelayCommand _insurancePolicyCommand;
        /// <summary>
        /// The <see cref="SaveInsurancePolicyCommand" />.
        /// </summary>

        public RelayCommand SaveInsurancePolicyCommand
        {
            get
            {
                if (_insurancePolicyCommand == null)
                {
                    _insurancePolicyCommand = new RelayCommand(
                            () =>
                            {
                                SaveInsurancePolicyExecute();
                            },
                            () => CanSaveInsurancePolicy
                        );
                }
                return _insurancePolicyCommand;
            }
            set
            {
                _insurancePolicyCommand = value;
            }
        }

        /// <summary>
        /// Executes when SaveInsurancePolicyCommand is called
        /// </summary>
        public void SaveInsurancePolicyExecute()
        {
            SaveInsurancePolicy();
        }


        /// <summary>
        /// The <see cref="CanSaveInsurancePolicy" /> property's name.
        /// </summary>
        public const string CanSaveInsurancePolicyPropertyName = "CanSaveInsurancePolicy";

        private bool _canSaveInsurancePolicy = true;

        /// <summary>
        /// Gets the CanSaveInsurancePolicy property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public bool CanSaveInsurancePolicy
        {
            get
            {
                return _canSaveInsurancePolicy;
            }

            set
            {
                if (_canSaveInsurancePolicy == value)
                {
                    return;
                }

                var oldValue = _canSaveInsurancePolicy;
                _canSaveInsurancePolicy = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CanSaveInsurancePolicyPropertyName);

                //tells the controls that are binded to the Command if it can execute
                SaveInsurancePolicyCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
        #endregion
        ////public override void Cleanup()
        ////{
        ////    // Clean own resources if needed

        ////    base.Cleanup();
        ////}
    }
}