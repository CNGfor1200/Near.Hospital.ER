// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: Entry100
// Vers: 3.0.0.0
//
// The actual start of all data and control flows
// .............................................................
using System;

using NearHspt.AA_Utilities;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Entry100 : ContentPage
  {
    public Entry100()
    {
      InitializeComponent();

      #region intro stuff
      this.Title = "Near Hospitals with ER's";
      BackgroundColor = Color.Black; // WhiteSmoke;
      Opacity = 0.9;
      //?//App.statusBaseLine.BackgroundColor = A_Util001.ColorInTraining();

      #endregion

      // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      //
      try
      {
        var duration = TimeSpan.FromMilliseconds(1000);
        Vibration.Vibrate(duration);
      }
      catch (FeatureNotSupportedException ex)
      {
        string aa = ex.Message.ToString();
      }
      catch (Exception ex)
      {
        string aa = ex.Message.ToString();
      }


      // Get all data into global (App. global) strings
      _ = FlatData.GetHospitalDB();

      //
      // At the end of the screen build, 'GetDevLocationAsync' finds 
      //
      // 1) Get Latitude, Longitude, Altitude, Accuracy from current location
      // 2) Get address from Latitude, Longitude. Post
      // 3) Generate "100 miles" address list of hospitals in range.
      // 4) With current 100-hospital list, Show Actual Nearest Hospital
      //
      _ = GeoSupport.GetDevLocationAsync_SectionA();

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

    }

    #region Base Functions
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

    // ..................................................................................................
    //
    // ..................................................................................................
    async void btFindHospital_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new FindHospital());
    }


    // ..................................................................................................
    //
    // ..................................................................................................
    async void btHospitalList_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new HospitalList());
    }
  }
}