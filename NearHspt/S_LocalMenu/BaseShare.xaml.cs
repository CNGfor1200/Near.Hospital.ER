// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: BaseShare
// Vers: 3.0.0.0
//
// Share your app experience
// ..............................................................
using System;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseShare : ContentPage
  {

    public BaseShare() //string[] jumpfromto)
    {
      InitializeComponent();

      this.Title = "Share this App";
      BackgroundColor = Color.Black;

      _ = ShareTest.ShareText(shareLabel.Text);

    }

    private async void SfButton_Share_Clicked(object sender, EventArgs e)
    {
      await ShareTest.ShareText(shareLabel.Text);
    }
  }

  public class ShareTest
  {
    public static async Task ShareText(string intext)
    {
      await Share.RequestAsync(new ShareTextRequest
      {
        Text = intext,
        Title = "Share Text"
      });
    }

  }
}
