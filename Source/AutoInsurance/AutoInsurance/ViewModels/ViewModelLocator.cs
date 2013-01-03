/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:AutoInsurance.ViewModels"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

namespace AutoInsurance.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// Use the <strong>mvvmlocatorproperty</strong> snippet to add ViewModels
    /// to this locator.
    /// </para>
    /// <para>
    /// In Silverlight and WPF, place the ViewModelLocator in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:ViewModelLocator xmlns:vm="clr-namespace:AutoInsurance.ViewModels"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// You can also use Blend to do all this with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    /// 
    using GalaSoft.MvvmLight;
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view models
            }
            else
            {
                // Create run time view models
                CreateCalculateInsurancePriceViewModel();
                CreateInsurancePolicyViewModel();
            }
        }

        #region InsurancePolicyViewModel
        private static InsurancePolicyViewModel _InsurancePolicyViewModel;

        /// <summary>
        /// Gets the InsurancePolicyViewModel property.
        /// </summary>
        public static InsurancePolicyViewModel InsurancePolicyViewModelStatic
        {
            get
            {
                if (_InsurancePolicyViewModel == null)
                {
                    CreateInsurancePolicyViewModel();
                }

                return _InsurancePolicyViewModel;
            }
        }

        /// <summary>
        /// Gets the InsurancePolicyViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public InsurancePolicyViewModel InsurancePolicyViewModel
        {
            get
            {
                return InsurancePolicyViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the InsurancePolicyViewModel property.
        /// </summary>
        public static void ClearInsurancePolicyViewModel()
        {
            _InsurancePolicyViewModel.Cleanup();
            _InsurancePolicyViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the InsurancePolicyViewModel property.
        /// </summary>
        public static void CreateInsurancePolicyViewModel()
        {
            if (_InsurancePolicyViewModel == null)
            {
                _InsurancePolicyViewModel = new InsurancePolicyViewModel();
            }
        }

        #endregion

        #region CalculateInsurancePriceViewModel
        private static CalculateInsurancePriceViewModel _calculateInsurancePriceViewModel;

        /// <summary>
        /// Gets the CalculateInsurancePriceViewModel property.
        /// </summary>
        public static CalculateInsurancePriceViewModel CalculateInsurancePriceViewModelStatic
        {
            get
            {
                if (_calculateInsurancePriceViewModel == null)
                {
                    CreateCalculateInsurancePriceViewModel();
                }

                return _calculateInsurancePriceViewModel;
            }
        }

        /// <summary>
        /// Gets the CalculateInsurancePriceViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CalculateInsurancePriceViewModel CalculateInsurancePriceViewModel
        {
            get
            {
                return CalculateInsurancePriceViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the CalculateInsurancePriceViewModel property.
        /// </summary>
        public static void ClearCalculateInsurancePriceViewModel()
        {
            _calculateInsurancePriceViewModel.Cleanup();
            _calculateInsurancePriceViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the CalculateInsurancePriceViewModel property.
        /// </summary>
        public static void CreateCalculateInsurancePriceViewModel()
        {
            if (_calculateInsurancePriceViewModel == null)
            {
                _calculateInsurancePriceViewModel = new CalculateInsurancePriceViewModel();
            }
        }

        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            ClearCalculateInsurancePriceViewModel();
            ClearInsurancePolicyViewModel();
        }
    }
}