// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: HospitalAll
// Vers: 3.0.0.0
//
// Contains list of  all nearby (100 miles) hospitals
// .............................................................
using System;

using Syncfusion.SfDataGrid.XForms;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HospitalList : ContentPage
  {
    public HospitalList()
    {
      InitializeComponent();

      #region intro stuff
      this.Title = "List - Near Hospitals/ER's";
      BackgroundColor = Color.Black; // WhiteSmoke;
      Opacity = 0.9;

      #endregion


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

    #region Data Grid Selection

    // ----------------------------------------------------------------------------------
    // Grd selection, distance, bed count, name
    // ----------------------------------------------------------------------------------
    private async void dataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
    {
      HospitalDBInfo selectedBatchRecorda = (e.AddedItems[0] as HospitalDBInfo);
      string selDistance = selectedBatchRecorda.HospitalDistance.ToString();
      string selBedCount = selectedBatchRecorda.HospitalBedcount.ToString();
      string selName = selectedBatchRecorda.HospitalName.ToString();

      //
      // get a pointer into the full record, residing
      // on the "all hospitals in 100-hit group" file
      //
      for (int ii = 0; ii < App.hospitalsInRangeCount; ii++)
      {
        if (App.hospitalsDB[App.hospitalsInRange[ii, 0], 0] == selName)
        {
          App.selectedHospital = App.hospitalsInRange[ii, 0];
          break;
        }
      }

      string searchStr = "https://www.google.com/search?q=%22";
      searchStr = searchStr + App.hospitalsDB[App.selectedHospital, 0] + "," + App.hospitalsDB[App.selectedHospital, 3] + "," + App.hospitalsDB[App.selectedHospital, 4];
      searchStr = searchStr + "%22";

      await Browser.OpenAsync(searchStr, BrowserLaunchMode.SystemPreferred);

    }

    #endregion

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
  }

  ////////////////////public class HospitalListmach
  ////////////////////{
  ////////////////////  public string DisplayName { get; set; }
  ////////////////////}

}
