// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: LabelClicked
// Vers: 3.0.0.0
//
// Low-level entry event routines
// .............................................................
using System;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace NearHspt.AA_Utilities
{
  public class LabelClickable : Label
  {
    public LabelClickable()
    {
      TapGestureRecognizer singleTap = new TapGestureRecognizer()
      {
        NumberOfTapsRequired = 1
      };
      TapGestureRecognizer doubleTap = new TapGestureRecognizer()
      {
        NumberOfTapsRequired = 2
      };
      this.GestureRecognizers.Add(singleTap);
      this.GestureRecognizers.Add(doubleTap);
      singleTap.Tapped += Label_Clicked;
      doubleTap.Tapped += Label_Clicked;
    }

    public static int clickCount;

    public async void Label_Clicked(object sender, EventArgs e)
    {
      switch (Device.RuntimePlatform)
      {
        case Device.iOS:
          await Browser.OpenAsync("https://www.cnginternetsoftware.com/smart_phone_software", BrowserLaunchMode.SystemPreferred);
          break;
        case Device.Android:
          await Browser.OpenAsync("https://www.cnginternetsoftware.com/smart_phone_software", BrowserLaunchMode.SystemPreferred);
          break;
        default:
          await Browser.OpenAsync("https://www.cnginternetsoftware.com/smart_phone_software", BrowserLaunchMode.SystemPreferred);
          break;
      }
    }

    bool ClickHandle()
    {
      if (clickCount > 1)
      {
        Minus1();
      }
      else
      {
        Plus1();
      }
      clickCount = 0;
      return false;
    }

    public void Minus1()
    {
      int value = Convert.ToInt16(Text) - 1;
      if (value < 0)
        value = 0;
      Text = value.ToString();
    }

    public void Plus1()
    {
      Text = (Convert.ToInt16(Text) + 1).ToString();
    }
  }
}
