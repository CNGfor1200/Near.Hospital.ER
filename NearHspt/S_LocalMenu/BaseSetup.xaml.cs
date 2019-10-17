// ..............................................................
// Medical Emergency Application 1B-6
// CNG Internet Software, Manalapan, New Jesey, USA
//
// Copyright @ 2019, 2019 CNG Internet Software, LLC
//
// Name: Setup, Main
// Vers:
//
// 
// .............................................................
using System;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseSetup : ContentPage
  {


    public BaseSetup()
    {
      InitializeComponent();

      this.Title = "SETUP";
      BackgroundColor = Color.Black;

      ownersNameEntry.Text = Preferences.Get("notesOwnerName", "default_value");
      if (ownersNameEntry.Text == "default_value") ownersNameEntry.Text = "no entry";
      ownersTelNumberEntry.Text = Preferences.Get("notesOwnerTelnum", "default_value"); // ownersTelNumberEntry.Text);
      if (ownersTelNumberEntry.Text == "default_value") ownersTelNumberEntry.Text = "no entry";
      ownersEmailEntry.Text = Preferences.Get("notesOwnerEmail", "default_value"); // ownersEmailEntry.Text);
      if (ownersEmailEntry.Text == "default_value") ownersEmailEntry.Text = "no entry";
    }

    #region owners Name


    void ownersNameEntry_TextChanged(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(ownersNameEntry.Text)) return;
      Preferences.Set("notesOwnerName", ownersNameEntry.Text);
    }

    void ownersNameEntry_Completed(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(ownersNameEntry.Text)) return;
      Preferences.Set("notesOwnerName", ownersNameEntry.Text);
    }

    #endregion

    #region owners Tel Numbere

    // -----------------------------------------------------------------------------------
    // Name Entry received focus
    // -----------------------------------------------------------------------------------
    void ownersTelNumberEntry_TextChanged(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersTelNumberEntry.Text)) return;
      Preferences.Set("notesOwnerTelnum", ownersTelNumberEntry.Text);
    }

    void ownersTelNumberEntry_Completed(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersTelNumberEntry.Text)) return;
      Preferences.Set("notesOwnerTelnum", ownersTelNumberEntry.Text);
    }


    #endregion

    #region owners Email

    // -----------------------------------------------------------------------------------
    // Name Entry received focus
    // -----------------------------------------------------------------------------------
    void ownersEmailEntry_TextChanged(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersEmailEntry.Text)) return;
      Preferences.Set("notesOwnerEmail", ownersEmailEntry.Text);
    }

    void ownersEmailEntry_Completed(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersEmailEntry.Text)) return;
      Preferences.Set("notesOwnerEmail", ownersEmailEntry.Text);
    }



    #endregion
  }
}