// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: ContactUs
// Vers: 3.0.0.0
//
// Contact us. Short version
// .............................................................
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

using Syncfusion.XForms.Core;
using Syncfusion.XForms.PopupLayout;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseContactUs : ContentPage
  {

    StackLayout contentstack = new StackLayout();

    SfPopupLayout popupLayout100;

    DataTemplate headerTemplateView;
    Label headerContent;
    DataTemplate templateView;
    Label popupContent;
    public static bool PopupLayout100Yes = false;
    public static bool PopupLayout100Needed = false;

    public BaseContactUs()
    {
      InitializeComponent();

      Title = "Contact Us";
      BackgroundColor = Color.Black;
      SfPopupLayout popupLayout100 = new SfPopupLayout();



      headerTemplateView = new DataTemplate(() =>
      {
        headerContent = new Label();
        headerContent.Text = "Customized Header";
        headerContent.FontAttributes = FontAttributes.Bold;
        headerContent.BackgroundColor = Color.LightBlue;
        headerContent.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
        headerContent.TextColor = Color.Black;
        headerContent.HorizontalTextAlignment = TextAlignment.Center;
        headerContent.VerticalTextAlignment = TextAlignment.Center;
        return headerContent;
      });
      // ...............................................................................................
      templateView = new DataTemplate(() =>
      {
        popupContent = new Label();
        popupContent.Text = "This is the SfPopupLayout";
        popupContent.BackgroundColor = Color.LightSkyBlue;
        popupContent.HorizontalTextAlignment = TextAlignment.Center;
        return popupContent;
      });
      // ...............................................................................................

      popupLayout100.PopupView.ShowCloseButton = true;
      // Adding HeaderTemplate of the SfPopupLayout
      popupLayout100.PopupView.HeaderTemplate = headerTemplateView;
      popupLayout100.PopupView.ContentTemplate = templateView;
      //
      popupLayout100.PopupView.AppearanceMode = AppearanceMode.TwoButton;
      //
      // Popup events
      //
      popupLayout100.Closing += PopupLayout100_Closing;
      popupLayout100.PopupView.AcceptCommand = new AcceptButton100CustomCommand();
      popupLayout100.PopupView.DeclineCommand = new DeclineButton100CustomCommand();
      PopupLayout100Yes = false;
      PopupLayout100Needed = false;


    }

    // Subs subs subs subs subs subs subs subs subs subs subs subs subs subs subs subs subs subs subs subs 


    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // "Send" pressed
    //
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    private async void SfButton_Send_ClickedAsync(object sender, EventArgs e)
    {
      PopupLayout100Needed = false;
      try
      {
        await Process_EmailAsync();
      }
      catch (Exception ex)
      {
        string aa = ex.Message.ToString();
        PopupLayout100Needed = true;
      }
    }


    // .......................................................................................
    // Process plain email
    //
    // .......................................................................................
    private async Task Process_EmailAsync()
    {
      // waiting 5 seconds if system is on test
      //ccWait(5);
      //
      string thisName = sendName.Text;
      string thisEmail = sendEmail.Text;
      string withThisMsg = sendMesssage.Text;
      string nowTime = DateTime.Now.ToString();
      string subject11;
      string body11;
      List<string> toAddress11 = new List<string>();

      try
      {
        subject11 = ("A Message re: Near ER/Hospitals from a User");
        body11 = (nowTime + "\nPlease read and act on my comment.\n\n") + "Name: " + thisName + "\n" + "Email: " + thisEmail + "\n" + "Message: " + withThisMsg + "\n";
        toAddress11.Add("gbeck@CNGInternet.com");
        var message = new EmailMessage
        {
          Subject = subject11,
          Body = body11,
          To = toAddress11,
          //Cc = ccRecipients,
          //Bcc = bccRecipients
        };
        await Email.ComposeAsync(message);
        PopupLayout100Needed = false;      // Popup message windows, Yes/Declined
      }
      catch (Exception ex)
      {
        string stError = ex.Message.ToString();
        PopupLayout100Needed = true;
      }

    }


    // ...............................................................................
    // Wait loop, testing only
    //
    // ...............................................................................
    void ccWait(int iwaitthislong)
    {
      bool iB = true;
      var startTime = DateTime.Now;
      //do until true or timeout reached.
      while (iB)
      {
        if (DateTime.Now - startTime > TimeSpan.FromSeconds(Convert.ToInt32(iwaitthislong)))
          break;
      }
      var endTime = DateTime.Now;
    }


    // ..............................................................................
    // Popup 100 Closing
    //
    // The popup box is closing. We may need to save some Dynamic data
    // from the box just before closing it.
    // ..............................................................................
    private void PopupLayout100_Closing(object sender, CancelEventArgs e)
    {
      //SfButton_Send.Text = "Close";
      //e.Cancel = false;   to keep the box from closing
      if (PopupLayout100Yes)
      {
        ContactLabel.Text = "YES";
      }
      else
      {
        ContactLabel.Text = "No";
      }

    }

    // ..............................................................................
    // Popup "YES" key pressed
    //
    // The popup box is closing. We may need to save some Dynamic data
    // from the box just before closing it.
    // ..............................................................................
    public class AcceptButton100CustomCommand : ICommand
    {
      public event EventHandler CanExecuteChanged;

      public bool CanExecute(object parameter)
      {
        PopupLayout100Yes = true;
        return true;
      }

      public void Execute(object parameter)
      {
        PopupLayout100Yes = true;
      }
    }

    // ..............................................................................
    // Popup "Declined" key pressed
    //
    // The popup box is closing. We may need to save some Dynamic data
    // from the box just before closing it.
    // ..............................................................................
    public class DeclineButton100CustomCommand : ICommand
    {
      public event EventHandler CanExecuteChanged;

      public bool CanExecute(object parameter)
      {
        PopupLayout100Yes = false;
        return true;
      }

      public void Execute(object parameter)
      {
        PopupLayout100Yes = false;
        // You can write your set of codes that needs to be executed
      }
    }


    // ..............................................................................
    // Our web site display options
    //
    // ..............................................................................
    async void SfButton_WebAsync_ClickedAsync(object sender, EventArgs e)
    {
      switch (Device.RuntimePlatform)
      {
        case Device.iOS:
          await Browser.OpenAsync("https://www.cnginternetsoftware.com/smart_phone_software", BrowserLaunchMode.SystemPreferred);
          break;
        case Device.Android:

          var action = await DisplayActionSheet("CNG Support Web Sites........", "Not Now", null, "CNGSoftware", "Blockchain Explanation", "Purchase of advanced version");
          switch (action)
          {
            case "CNGSoftware":
              await Browser.OpenAsync("https://www.cnginternetsoftware.com/smart_phone_software", BrowserLaunchMode.SystemPreferred);
              break;
            case "Blockchain Explanation":
              await Browser.OpenAsync("https://www.cnginternetsoftware.com/blockchain", BrowserLaunchMode.SystemPreferred);
              break;
            case "Purchase of advanced version":
              await Browser.OpenAsync("https://www.cnginternetsoftware.com/payment-process", BrowserLaunchMode.SystemPreferred);
              break;
          }

          break;
        default:
          await Browser.OpenAsync("https://www.cnginternetsoftware.com/smart_phone_software", BrowserLaunchMode.SystemPreferred);
          break;

      }
    }


  }
}