// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: StatAbout
// Vers: 3.0.0.0
//
// Brief [About] and [Reference] page
// .............................................................
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class StatAbout : ContentPage
  {


    public StatAbout()
    {
      InitializeComponent();


      Title = "About / References";
      BackgroundColor = Color.Black;


    }

  }
}