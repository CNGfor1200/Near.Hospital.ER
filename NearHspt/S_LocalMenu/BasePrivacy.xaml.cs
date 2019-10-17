// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: BasePrivacy
// Vers: 3.0.0.0
//
// Pointing to the CHG Internet Software Privacy page
// ..............................................................
using System;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BasePrivacy : ContentPage
  {

    StackLayout contentstack = new StackLayout();

    public BasePrivacy()
    {
      InitializeComponent();

      this.Title = "Privacy";
      BackgroundColor = Color.Black;

      Privacy100();

    }


    // ======================================================================
    // Web Site
    // ======================================================================
    async void Privacy100()
    {
      switch (Device.RuntimePlatform)
      {
        case Device.iOS:
          await Browser.OpenAsync("https://www.cnginternetsoftware.com/privacy-policy", BrowserLaunchMode.SystemPreferred);
          break;
        case Device.Android:
          await Browser.OpenAsync("https://www.cnginternetsoftware.com/privacy-policy", BrowserLaunchMode.SystemPreferred);
          break;
        default:
          await Browser.OpenAsync("https://www.cnginternetsoftware.com/privacy-policy", BrowserLaunchMode.SystemPreferred);
          break;

      }

    }

    // ======================================================================
    // Button Click
    // ======================================================================

    private void SfButton_Privacy_Clicked(object sender, EventArgs e)
    {
      Privacy100();
    }
  }
}