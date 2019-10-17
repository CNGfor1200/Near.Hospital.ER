// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: BaseGuide
// Vers: 3.0.0.0
//
// Brief Users "manual"
// ..............................................................
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseGuide : ContentPage
  {

    public BaseGuide(int arg001)
    {
      InitializeComponent();

      this.Title = "User Guide";
      BackgroundColor = Color.White;
    }

  }
}
