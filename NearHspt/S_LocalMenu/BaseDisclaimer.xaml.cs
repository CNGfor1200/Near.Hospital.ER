// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: Disclaimer
// Vers: 3.0.0.0
//
// Legal Disclaimer, short version
// ..............................................................
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseDisclaimer : ContentPage
  {

    public BaseDisclaimer()
    {
      InitializeComponent();
      Title = "Legal Disclaimer";
      BackgroundColor = Color.Black;
    }

  }
}
