// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: FindHospital
// Vers: 3.0.0.0
//
// First Major. List nearest hospital, get list of all in 
// 100 miles, get current location, google map
// .............................................................
using System;

using NearHspt.AA_Utilities;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class FindHospital : ContentPage
  {

    public FindHospital()
    {
      InitializeComponent();

      #region intro stuff
      this.Title = "Nearest Hospital/ER";
      BackgroundColor = Color.Black; // WhiteSmoke;
      Opacity = 0.9;

      #endregion

      // range in miles *100 (stupid conversion to integer)
      App.requestedHospitalRange = 1000;


      //
      // At the end of the screen build, 'GetDevLocationAsync' finds 
      //
      // 1) Get Latitude, Longitude, Altitude, Accuracy from current location
      // 2) Get address from Latitude, Longitude. Post
      // 3) Generate "100 miles" address list of hospitals in range.
      // 4) With current 100-hospital list, Show Actual Nearest Hospital
      //
      _ = GeoSupport.GetDevLocationAsync_SectionB(this.btdisplayAllHospitals, this.btNearestHospital, this.lblLating, this.PrimlblDisplayAddress);

      if (App.MajorError)
      {
        DisplayAlert("Internet Access", "Possible issues:\n\n" +
          "Assure you have FULL Internet Access:\n" +
          " 1) Go to your Phone's [Settings]\n" +
          " 2) Check CONNECTION TO Internet / WiFi\n" +
          "    or\n" +
          " 3) turn \"Data Usage\" on $$ fee !!\n" +
          "    you may also need to set\n" +
          " 4) LOCATION permission under\n" +
          "    --> Settings --> Google --> Location\n", "Got it", " ");
      }

      // end of screen build
    }


    // Support Functions =========================================================================================================================

    #region 'Local Navigation' Functions
    private async void BaseGuide_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new BaseGuide(1));
    }

    private async void BaseShare_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new BaseShare());
    }

    private async void BaseSetup_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new BaseSetup());
    }

    private async void BaseDisclaimer_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new BaseDisclaimer());
    }

    private async void BasePrivacy_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new BasePrivacy());
    }

    private async void StatAbout_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new StatAbout());
    }

    private async void BaseContactUs_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new BaseContactUs());
    }
    #endregion


    // Next Door Hospital
    private async void btNearestHospital_ClickedAsync(object sender, EventArgs e)
    {
      App.selectedHospital = App.hospitalsInRange[0, 0];
      string searchStr = "https://www.google.com/search?q=%22";
      searchStr = searchStr + App.hospitalsDB[App.selectedHospital, 0] + "," + App.hospitalsDB[App.selectedHospital, 3] + "," + App.hospitalsDB[App.selectedHospital, 4];
      searchStr = searchStr + "%22";

      await Browser.OpenAsync(searchStr, BrowserLaunchMode.SystemPreferred);
    }


    private async void btdisplayAllHospitals_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new HospitalList());
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
      Boolean ans = await DisplayAlert("GPS Address generator", "Possible issues:\n" +
        "1) Slow to get GPS data:\n" +
        "     Other apps using GPS?\n" +
        "     Exit completely out of \n" +
        "      'NearHospital', try again.\n\n" +
        "2) No data, even after a minute:\n" +
        "      Go to Phone [Settings]\n" +
        "        Tap on - Connections, \n" +
        "        check \"Locations\" (must be ON)", "Got it", " ");
    }


    private async void TapGestureGoogle_Tapped(object sender, EventArgs e)
    {
      GeoSupport.actualAddressMap();
    }









    ////////////////////public class GetRatings
    ////////////////////{
    ////////////////////  public static async Task<bool> HospitalOpenBrowser(Uri uri)
    ////////////////////  {
    ////////////////////    //return await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    ////////////////////  }
    ////////////////////}





  }
}
