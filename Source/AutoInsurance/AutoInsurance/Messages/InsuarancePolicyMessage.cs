using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using AutoInsurance.Web;

namespace AutoInsurance.Messages
{
    public class LaunchEditInsuarancePolicyMessage : MessageBase
    {
        public InsurancePolicy InsuarancePolicy { get; set; }
    }

    public class SaveInsuarancePolicyMessageDialog : DialogMessage
    {
        public SaveInsuarancePolicyMessageDialog(string content, string title)
            : base(content, null)
        {
            Button = MessageBoxButton.OK;
            Caption = title;
        }
    }

    
}
