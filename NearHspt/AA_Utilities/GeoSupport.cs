// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: GeoSupport
// Vers: 3.0.0.0
//
// Loe-level geo routines
// .............................................................
using System;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;


namespace NearHspt.AA_Utilities
{
  class GeoSupport
  {

    #region Dev Location

    // ===================================================================================================
    // Get geo location, and work with it
    //
    // 1) Get Latitude, Longitude, Altitude, Accuracy from current location
    // 2) Generate "100 miles" address list of hospitals in range. Post to button.
    // ===================================================================================================
    public static async Task GetDevLocationAsync_SectionA()
    {

      try
      {
        //
        // 1) Get Latitude, Longitude, Altitude, Accuracy from current location
        // -------------------------------------------------------------------------
        var georequest = new GeolocationRequest(GeolocationAccuracy.Best);
        var georesults = await Geolocation.GetLocationAsync(georequest);
        App.deviceLatitude = Convert.ToDouble(georesults.Latitude.ToString());
        App.deviceLongitude = Convert.ToDouble(georesults.Longitude.ToString());
        App.strAccuracyMeters = Convert.ToInt32(georesults.Accuracy).ToString();
        App.strAccuracyFeet = (Convert.ToInt32(georesults.Accuracy) * 3.28).ToString();

        //
        // 2) Generate "100 miles" address list of hospitals in range.
        // -----------------------------------------------------------------------
        int atemp = (Convert.ToInt32(App.defaultHospitalRange));
        atemp = atemp * 100;
        App.requestedHospitalRange = atemp;
        //
        // Now get and load the 100-miles list
        //
        FlatData.Load_HospitalsInRage(App.deviceLatitude, App.deviceLongitude);
        //
      }
      catch (Exception ex)
      {
        string aa = ex.ToString();
        App.MajorError = true;
      }
    }



    // ===================================================================================================
    // Get geo location, and work with it
    //
    // 2) Get address from Latitude, Longitude. Post
    // 3) Generate "100 miles" address list of hospitals in range. Post to button.
    // 4) With current 100-hospital list, Show Actual Nearest Hospital
    // ===================================================================================================
    public static async Task GetDevLocationAsync_SectionB(Button btdisplayAllHospitals, Button nearestHospital, Label lblLating, Label PrimlblDisplayAddress)
    {

      try
      {
        //////////////////////
        ////////////////////// 1) Get Latitude, Longitude, Altitude, Accuracy from current location
        ////////////////////// -------------------------------------------------------------------------
        ////////////////////var georequest = new GeolocationRequest(GeolocationAccuracy.Best);
        
        //grb//var georesults = await Geolocation.GetLocationAsync(georequest);
        
        ////////////////////App.deviceLatitude = Convert.ToDouble(georesults.Latitude.ToString());
        ////////////////////App.deviceLongitude = Convert.ToDouble(georesults.Longitude.ToString());
        ////////////////////App.strAccuracyMeters = Convert.ToInt32(georesults.Accuracy).ToString();
        ////////////////////App.strAccuracyFeet = (Convert.ToInt32(georesults.Accuracy) * 3.28).ToString();

        ////////////////////// SF, testing
        //////////////////////deviceLatitude = 37.783333;         
        //////////////////////deviceLongitude = -122.416667;


        //
        // 2) Get address from Latitude, Longitude. Post address.
        // -------------------------------------------------------------------------
        //grb//if (georesults != null)
        {
          var manyPlacemarks = await Geocoding.GetPlacemarksAsync(App.deviceLatitude, App.deviceLongitude);
          var placemark = manyPlacemarks?.FirstOrDefault();
          if (placemark != null)
          {
            PrimlblDisplayAddress.Text = "  " + placemark.FeatureName + " " + placemark.Thoroughfare + ",  \n" + "  " + placemark.Locality + "  \n" + "  " + placemark.AdminArea + ", " + placemark.CountryCode + "  " + placemark.PostalCode + "  ";
          }
        }

        // 2a) Post latitude, longitude
        // -------------------------------------------------------------------------
        lblLating.Text = string.Format("Lat: {0}    Long: {1} \nLocation Accuracy ~ :  {2} {3}  or  {4} {5}",
          App.deviceLatitude, App.deviceLongitude, App.strAccuracyMeters, "m", App.strAccuracyFeet, "feet");


        //
        // 3) Generate "100 miles" address list of hospitals in range. Post to button.
        // ----------------------------------------------------------------------------
        if (App.hospitalsInRangeCount == -1)
        {
          App.hospitalsInRangeCount = 0;

          btdisplayAllHospitals.Text = "  " + App.hospitalsInRangeCount.ToString() + " Hospitals";
        }
        else
        {
          btdisplayAllHospitals.Text = "  " + App.hospitalsInRangeCount.ToString() + " Other Hospital (more ...)  ";
        }
        //
        int atemp = (Convert.ToInt32(App.defaultHospitalRange));
        atemp = atemp * 100;
        App.requestedHospitalRange = atemp;
        //
        // Now get / show the 100-miles list
        //
        //
        if (App.hospitalsInRangeCount == -1)
        {
          App.hospitalsInRangeCount = 0;

          btdisplayAllHospitals.Text = "  " + App.hospitalsInRangeCount.ToString() + " Hospitals";
        }
        else
        {
          btdisplayAllHospitals.Text = "  " + App.hospitalsInRangeCount.ToString() + " Other Hospital (more ...)  ";
        }

        //
        // 4) With current 100-hospital list, Show Actual Nearest Hospital
        // -------------------------------------------------------------------------
        ShowNearestHospital(nearestHospital);
      }
      catch (Exception ex)
      {
        string aa = ex.ToString();
        PrimlblDisplayAddress.Text = " Current Position not a valid Google address poaint.";
        App.MajorError = true;
      }
    }



    // ===================================================================================================
    // Show hospital distance on first page
    //
    // get the first hospitalsInRange array element (is always the nearest)
    // ===================================================================================================
    public static void ShowNearestHospital(Button nn)
    {
      if (App.hospitalsInRangeCount == 0)
      {
        nn.Text = " No near Hospital found yet.";
        return;
      }
      if (App.hospitalsInRangeCount == -1)
      {
        nn.Text = " Address Coordinates not inside the USA";
      }
      else
      {
        nn.Text = "  " + Convert.ToDouble(App.hospitalsInRange[0, 1] / 100.00).ToString() + " miles  --  " + App.hospitalsDB[App.hospitalsInRange[0, 0], 0] + "     more ...";
      }
    }



    #endregion





    #region Standard functions


    // -----------------------------------------------------------------------------------
    // Display Google Map by address from an image
    // -----------------------------------------------------------------------------------
    public static async void actualAddressMap()
    {
      try
      {

        //
        // get hospital
        //
        int hloc = App.hospitalsInRange[0, 0];
        double hLat = Convert.ToDouble(App.hospitalsDB[hloc, 8]);
        double hLong = Convert.ToDouble(App.hospitalsDB[hloc, 9]);
        var location = new Location(hLat, hLong);
        var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

        await Map.OpenAsync(location, options);

      }
      catch (Exception ex)
      {
        string aa = ex.Message.ToString();
      }

    }




    // ====================================================================
    //
    //
    // ====================================================================
    public class LatLng
    {
      public double Latitude { get; set; }
      public double Longitude { get; set; }
      public LatLng(double latin, double lngin)
      {
        this.Latitude = latin;
        this.Longitude = lngin;
      }
    }

    #endregion


  }
  }