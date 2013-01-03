using GalaSoft.MvvmLight;
using AutoInsurance.Services;
using AutoInsurance.Web;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using AutoInsurance.Models;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel.DataAnnotations;
using AutoInsurance.Messages;

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
    public class CalculateInsurancePriceViewModel : ViewModelBase
    {

        /// <summary>
        /// Initializes a new instance of the CalculateInsuracePriceViewModel class.
        /// </summary>
        public CalculateInsurancePriceViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                InitDataService();
                LoadNomenclatures();
            }
        }

        private void InitDataService()
        {
            autoTypeDataService = ServiceProvider.Instance.AutoTypeDataService;
            purposeDataService = ServiceProvider.Instance.PurposeDataService;
            companyDataService = ServiceProvider.Instance.CompanyDataService;
        }

        #region DataServices
        private IAutoTypeDataService autoTypeDataService;
        private IPurposeDataService purposeDataService;
        private ICompanyDataService companyDataService;
        #endregion

        #region OnLoaded events
        private void OnAutoTypesLoaded(ObservableCollection<AutoType> autoTypes)
        {
            this.AutoTypes = autoTypes;
        }

        private void OnPurposesLoaded(ObservableCollection<Purpose> purposes)
        {
            this.Purposes = purposes;
        }

        private void OnCompaniesLoaded(ObservableCollection<Company> companies)
        {
            this.Companies = companies;
        }
        #endregion

        #region Nomenclatures Properties
        #region AutoType Nomenclatures
        /// <summary>
        /// The <see cref="AutoTypes" /> property's name.
        /// </summary>
        public const string AutoTypesPropertyName = "AutoTypes";

        private ObservableCollection<AutoType> _autoTypes;

        /// <summary>
        /// Gets the AutoTypes property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public ObservableCollection<AutoType> AutoTypes
        {
            get
            {
                return _autoTypes;
            }

            set
            {
                if (_autoTypes == value)
                {
                    return;
                }

                var oldValue = _autoTypes;
                _autoTypes = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(AutoTypesPropertyName);
            }
        }
        #endregion

        #region Purposes Nomenclature
        /// <summary>
        /// The <see cref="Purposes" /> property's name.
        /// </summary>
        public const string PurposesPropertyName = "Purposes";

        private ObservableCollection<Purpose> _purposes;

        /// <summary>
        /// Gets the Purposes property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public ObservableCollection<Purpose> Purposes
        {
            get
            {
                return _purposes;
            }

            set
            {
                if (_purposes == value)
                {
                    return;
                }

                var oldValue = _purposes;
                _purposes = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(PurposesPropertyName);
            }
        }
        #endregion

        #region Companies
        /// <summary>
        /// The <see cref="Companies" /> property's name.
        /// </summary>
        public const string CompaniesPropertyName = "Companies";

        private ObservableCollection<Company> _companies;

        /// <summary>
        /// Gets the Companies property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public ObservableCollection<Company> Companies
        {
            get
            {
                return _companies;
            }

            set
            {
                if (_companies == value)
                {
                    return;
                }

                var oldValue = _companies;
                _companies = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CompaniesPropertyName);
            }
        }
        #endregion

        #region Years Nomenclatures
        /// <summary>
        /// The <see cref="Years" /> property's name.
        /// </summary>
        public const string YearsPropertyName = "Years";

        private ObservableCollection<int> _years;

        /// <summary>
        /// Gets the Years property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public ObservableCollection<int> Years
        {
            get
            {
                if (_years == null)
                {
                    IList<int> years = GenerateYears();

                    _years = new ObservableCollection<int>(years);
                }
                return _years;
            }

            set
            {
                if (_years == value)
                {
                    return;
                }

                var oldValue = _years;
                _years = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(YearsPropertyName);
            }
        }

        private static IList<int> GenerateYears()
        {
            int currentYear = DateTime.Now.Year;
            const int minYear = 1900;
            IList<int> years = new List<int>();
            for (int i = minYear; i < currentYear; i++)
            {
                years.Add(i);
            }

            years = years.OrderByDescending(y => y).ToList();
            return years;
        }
        #endregion
        #endregion

        private void LoadNomenclatures()
        {
            autoTypeDataService.GetAutoTypeList(OnAutoTypesLoaded, int.MaxValue);
            purposeDataService.GetPurposeList(OnPurposesLoaded, int.MaxValue);
            companyDataService.GetCompanyList(OnCompaniesLoaded, int.MaxValue);
        }

        #region Properties
        #region AutoType Property
        /// <summary>
        /// The <see cref="AutoType" /> property's name.
        /// </summary>
        public const string AutoTypePropertyName = "AutoType";

        private AutoType _autoType;

        /// <summary>
        /// Gets the AutoType property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public AutoType AutoType
        {
            get
            {
                return _autoType;
            }

            set
            {
                if (_autoType == value)
                {
                    return;
                }

                var oldValue = _autoType;
                _autoType = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(AutoTypePropertyName);

            }
        }
        #endregion

        #region FirstRegistrationYear Property
        /// <summary>
        /// The <see cref="FirstRegistrationYear" /> property's name.
        /// </summary>
        public const string FirstRegistrationYearPropertyName = "FirstRegistrationYear";

        private int _firstRegistrationYear = 2000;

        /// <summary>
        /// Gets the FirstRegistrationYear property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        //[Required(ErrorMessage = "Полето 'Година на първа регистрация' трябва да е попълнено!")]
        public int FirstRegistrationYear
        {
            get
            {
                return _firstRegistrationYear;
            }

            set
            {
                if (_firstRegistrationYear == value)
                {
                    return;
                }

                var oldValue = _firstRegistrationYear;
                _firstRegistrationYear = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(FirstRegistrationYearPropertyName);

            }
        }
        #endregion

        #region DriverExperience Property
        /// <summary>
        /// The <see cref="DriverExperience" /> property's name.
        /// </summary>
        public const string DriverExperiencePropertyName = "DriverExperience";

        private int _driverExperience;

        /// <summary>
        /// Gets the DriverExperience property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        //[Required(ErrorMessage = "Полето 'Опит на водача' трябва да е попълнено!")]
        public int DriverExperience
        {
            get
            {
                return _driverExperience;
            }

            set
            {
                if (_driverExperience == value)
                {
                    return;
                }

                var oldValue = _driverExperience;
                _driverExperience = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(DriverExperiencePropertyName);
            }
        }
        #endregion

        #region Purpose Property
        /// <summary>
        /// The <see cref="Purpose" /> property's name.
        /// </summary>
        public const string PurposePropertyName = "Purpose";

        private Purpose _purpose;

        /// <summary>
        /// Gets the Purpose property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        //[Required(ErrorMessage = "Полето 'Предназначение' трябва да е попълнено!")]
        public Purpose Purpose
        {
            get
            {
                return _purpose;
            }

            set
            {
                if (_purpose == value)
                {
                    return;
                }

                var oldValue = _purpose;
                _purpose = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(PurposePropertyName);

            }
        }
        #endregion

        #region SeatsCount
        /// <summary>
        /// The <see cref="SeatsCount" /> property's name.
        /// </summary>
        //
        public const string SeatsCountPropertyName = "SeatsCount";

        private int _seatsCount;

        /// <summary>
        /// Gets the SeatsCount property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        [Required(ErrorMessage = "Полето 'Брой места' трябва да е попълнено!")]
        public int SeatsCount
        {
            get
            {
                return _seatsCount;
            }

            set
            {
                if (_seatsCount == value)
                {
                    return;
                }

                var oldValue = _seatsCount;
                _seatsCount = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(SeatsCountPropertyName);

            }
        }
        #endregion

        #region LoadingCapacity
        /// <summary>
        /// The <see cref="LoadingCapacity" /> property's name.
        /// </summary>
        public const string LoadingCapacityPropertyName = "LoadingCapacity";

        private int _loadingCapacity;

        /// <summary>
        /// Gets the LoadingCapacity property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public int LoadingCapacity
        {
            get
            {
                return _loadingCapacity;
            }

            set
            {
                if (_loadingCapacity == value)
                {
                    return;
                }

                var oldValue = _loadingCapacity;
                _loadingCapacity = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(LoadingCapacityPropertyName);

            }
        }
        #endregion

        #region CalculatedInsuranceList
        /// <summary>
        /// The <see cref="CalculatedInsuaranceList" /> property's name.
        /// </summary>
        public const string CalculatedInsuaranceListPropertyName = "CalculatedInsuaranceList";

        private ObservableCollection<CalculatedInsuaranceSummary> _calculatedInsuranceList;

        /// <summary>
        /// Gets the CalculatedInsuaranceList property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public ObservableCollection<CalculatedInsuaranceSummary> CalculatedInsuaranceList
        {
            get
            {
                return _calculatedInsuranceList;
            }

            set
            {
                if (_calculatedInsuranceList == value)
                {
                    return;
                }

                var oldValue = _calculatedInsuranceList;
                _calculatedInsuranceList = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CalculatedInsuaranceListPropertyName);

            }
        }
        #endregion

        #region SelectedCalculatedInsurance
        /// <summary>
        /// The <see cref="SelectedCalculatedInsurance" /> property's name.
        /// </summary>
        public const string SelectedCalculatedInsurancePropertyName = "SelectedCalculatedInsurance";

        private CalculatedInsuaranceSummary _selectedCalculatedInsurance;

        /// <summary>
        /// Gets the SelectedCalculatedInsurance property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public CalculatedInsuaranceSummary SelectedCalculatedInsurance
        {
            get
            {
                return _selectedCalculatedInsurance;
            }

            set
            {
                if (_selectedCalculatedInsurance == value)
                {
                    return;
                }

                var oldValue = _selectedCalculatedInsurance;
                _selectedCalculatedInsurance = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedCalculatedInsurancePropertyName);
                CanLaunchEditInsurancePolicy = true;
            }
        }
        #endregion
        #endregion

        #region Commands
        #region CalculateCommand

        private RelayCommand _calculateCommand;
        /// <summary>
        /// The <see cref="CalculateCommand" />.
        /// </summary>

        public RelayCommand CalculateCommand
        {
            get
            {
                if (_calculateCommand == null)
                {
                    _calculateCommand = new RelayCommand(
                            () =>
                            {
                                CalculateExecute();
                            },
                            () => CanCalculate
                        );
                }
                return _calculateCommand;
            }
            set
            {
                _calculateCommand = value;
            }
        }

        /// <summary>
        /// Executes when CalculateCommand is called
        /// </summary>
        public void CalculateExecute()
        {
            if (Companies == null)
            {
                return;
            }

            var calculatedInsuaranceList = new List<CalculatedInsuaranceSummary>();

            double autoTypeCoeficient = (double)AutoType.Coeficient;
            double purposeCoeficient = (double)Purpose.Coeficient;
            int driverExperience = DriverExperience;
            int seatsCount = SeatsCount;
            int loadingCapacity = LoadingCapacity;
            int firstYearRegistration = FirstRegistrationYear;

            foreach (var company in Companies)
            {
                double calculatedPrice =
                    company.CalculatePrice(autoTypeCoeficient
                                           , purposeCoeficient
                                           , driverExperience
                                           , 0
                                           , firstYearRegistration
                                           , seatsCount
                                           , loadingCapacity);
                var calculatedIns = new CalculatedInsuaranceSummary(company.CompanyId, company.Name, calculatedPrice);

                calculatedInsuaranceList.Add(calculatedIns);
            }

            calculatedInsuaranceList = calculatedInsuaranceList.OrderBy(cil => cil.Price).ToList();
            CalculatedInsuaranceList = new ObservableCollection<CalculatedInsuaranceSummary>(calculatedInsuaranceList);

        }


        /// <summary>
        /// The <see cref="CanCalculate" /> property's name.
        /// </summary>
        public const string CanCalculatePropertyName = "CanCalculate";

        private bool _canCalculate = true;

        /// <summary>
        /// Gets the CanCalculate property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public bool CanCalculate
        {
            get
            {
                return _canCalculate;
            }

            set
            {
                if (_canCalculate == value)
                {
                    return;
                }

                var oldValue = _canCalculate;
                _canCalculate = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CanCalculatePropertyName);

                //tells the controls that are binded to the Command if it can execute
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region LaunchEditInsurancePolicyCommand

        private RelayCommand _launchEditInsurancePolicyCommand;
        /// <summary>
        /// The <see cref="LaunchEditInsurancePolicyCommand" />.
        /// </summary>

        public RelayCommand LaunchEditInsurancePolicyCommand
        {
            get
            {
                if (_launchEditInsurancePolicyCommand == null)
                {
                    _launchEditInsurancePolicyCommand = new RelayCommand(
                            () =>
                            {
                                LaunchEditInsurancePolicyExecute();
                            },
                            () => CanLaunchEditInsurancePolicy
                        );
                }
                return _launchEditInsurancePolicyCommand;
            }
            set
            {
                _launchEditInsurancePolicyCommand = value;
            }
        }

        /// <summary>
        /// Executes when LaunchEditInsurancePolicyCommand is called
        /// </summary>
        public void LaunchEditInsurancePolicyExecute()
        {
            if (SelectedCalculatedInsurance == null)
            {
                return;
            }

            int companyId = SelectedCalculatedInsurance.CompanyId;
            decimal price = (decimal)SelectedCalculatedInsurance.Price;

            InsurancePolicy newInsurancePolicy =
                new InsurancePolicy()
                {
                    Auto =
                        new Auto()
                        {
                            AutoTypeId = AutoType == null? 0 : this.AutoType.AutoTypeId,
                            SeatsCount = this.SeatsCount,
                            MakeYear = this.FirstRegistrationYear,
                            PurposeId = Purpose == null ? 0: this.Purpose.PurposeId,
                            LoadingCapacity = this.LoadingCapacity,
                            Person = new Person()
                        },
                    CompanyId = companyId,
                    IssueDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1),
                    DriverExperienceYears = this.DriverExperience,
                    AgencyName = "ТУ-СОФИЯ Иншуърънс ООД",
                    Price = price
                    
                };

            var newMessage =
                new LaunchEditInsuarancePolicyMessage()
                {
                    InsuarancePolicy = newInsurancePolicy
                };
            Messenger.Default.Send <LaunchEditInsuarancePolicyMessage>(newMessage);
        }


        /// <summary>
        /// The <see cref="CanLaunchEditInsurancePolicy" /> property's name.
        /// </summary>
        public const string CanLaunchEditInsurancePolicyPropertyName = "CanLaunchEditInsurancePolicy";

        private bool _canLaunchEditInsurancePolicy = false;

        /// <summary>
        /// Gets the CanLaunchEditInsurancePolicy property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public bool CanLaunchEditInsurancePolicy
        {
            get
            {
                return _canLaunchEditInsurancePolicy;
            }

            set
            {
                if (_canLaunchEditInsurancePolicy == value)
                {
                    return;
                }

                var oldValue = _canLaunchEditInsurancePolicy;
                _canLaunchEditInsurancePolicy = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CanLaunchEditInsurancePolicyPropertyName);

                //tells the controls that are binded to the Command if it can execute
                LaunchEditInsurancePolicyCommand.RaiseCanExecuteChanged();
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