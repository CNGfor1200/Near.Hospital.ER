// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: MainActivity
// Vers: 3.0.0.0
//
// The actual start of all data and control flows
// .............................................................
using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace NearHspt.Droid
{
  [Activity(Label = "Nearby ER / Hospitals", Icon = "@drawable/fng", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      //TabLayoutResource = Resource.Layout.Tabbar;
      //ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);

      //# Android #################################################################################

      // Store off the device sizes, so we can access them within Xamarin Forms
      //  Screen Width = WidthPixels / Density
      //  Screen Height = HeightPixels / Density

      App.DisplayScreenWidth = Resources.DisplayMetrics.WidthPixels / (double)Resources.DisplayMetrics.Density;
      App.DisplayScreenHeight = (double)Resources.DisplayMetrics.HeightPixels / (double)Resources.DisplayMetrics.Density;
      App.DisplayScaleFactor = (double)Resources.DisplayMetrics.Density;
      App.DisplayScaleMax = App.DisplayScreenHeight;
      if (App.DisplayScreenHeight <= App.DisplayScreenWidth) App.DisplayScaleMax = App.DisplayScreenWidth;

      //###########################################################################################

      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
      //
      Syncfusion.XForms.Android.PopupLayout.SfPopupLayoutRenderer.Init();
      //
      LoadApplication(new App());
    }

    // ................................................................................................
    // OnRequestPermissionsResult
    // 
    // Required by Xamarin Essentials to 'connect' to Permission
    // ................................................................................................
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
  }
}