// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: App
// Vers: 3.0.0.0
//
// The actual start of all data and control flows
// .............................................................
using Xamarin.Forms;

namespace NearHspt
{
  public partial class App : Application
  {
    public static bool inFirstRun = false;
    public static bool inTesting;  // = true; //false;
    public static bool MajorError;
      
    // Geo Location
    public static double deviceLatitude = 0.0;
    public static double deviceLongitude = 0.0;
    public static string strAccuracyMeters = "";
    public static string strAccuracyFeet = "";

    public static StackLayout contentstatusBaseline = new StackLayout();
    public static StackLayout statusBaseLine = new StackLayout();
    public static string tryAlerthd = "Set to Try-Out Mode?";
    public static string tryAlertbd = "In Try-Out Mode means:\n  1) NO E911 Calls\n  2) [Auto] Dialing is 732-536-8414\n  3) NO call to Poison Control Center";
    public static string familyAlerthd = "Calling Problem";
    public static string familyAlertbdNull = "Phone Number was null or white space.";
    public static string familyAlertbdNoSupport = "Phone Dialer is not supported on this device.";
    public static string familyAlertbdGeneral = "Phone Dialer failed to connect to external network.";

    //
    // File Names
    public static string statusFile = "CCMedstatus.txt";
    public static string notyFile = "CCMedNotice.txt";
    public static string telSMSemailNotification = "CCMedNotice.txt";
    public static bool inProduction = true; //false;
    // ..................................................................................
    // Hospital "DB"
    public static string[,] hospitalsDB = new string[7200, 16];
    public static int hospitalsDBRowsCount = 0;
    public static int hospitalsDBColsCount = 0;
    public static double requestedHospitalRange = 0.0;
    public static int[,] hospitalsInRange = new int[101, 2];
    public static int hospitalsInRangeCount = 0;
    public static int hospitalsShownCount = 0;
    public static int selectedHospital = 0;

    public static string userSelectedAddress = "";
    // ..................................................................................

    // Setup
    //
    public static string[] notesName = new string[7];
    public static string[] notesTel = new string[7];
    public static string[] notesEmail = new string[7];
    //public static string myTel = "908-420-0918";              // telephone number to test things

    public static string AppVersion = "3.2.0.8";
    public static string RegNum = "MH-UY-89887-IO";
    public static string RegWhen = "March-18-2019";
    public static string OwnerName = "Frank Smith";
    public static string OwnerTel = "732-536-9988";
    public static string OwnerEmail = "frank@cuma.com";


    public static double defaultHospitalRange = 100.0;          // miles. Initial, default, nearest hospital range

    public static string countdownSeconds;
    public static string countdownMinutes;

    public static double DisplayScreenWidth;                    // = 0f;
    public static double DisplayScreenHeight;                   // = 0f;
    public static double DisplayScaleFactor;                    // = 0f;
    public static double DisplayScaleMax;                       // = 0f;

    //
    // Set on/off all permissions that need to be on/off for this app
    //
    // template
    public static bool havePermitGeoLocation = false;
    public static bool havePermitPhone = false;
    public static bool havePermitSMSn = false;
    public static bool havePermitStorage = false;
    //
    // permissions needed for this app
    // 	 -------------------------------------------
    public static bool ibCalendar = false;    //		Calendar, appointments
    public static bool ibCamera = false;      //		Camera
    public static bool ibContacts = false;    //		Contacts
    public static bool ibMicrophone = false;  //		Device location

    public static bool ibGeoLocation = true;  //		Device location
    public static bool ibPhone = true;        //		Phone

    public static bool ibPhotos = false;      //		Photos
    public static bool ibReminders = false;   //		Reminders, Notes, Notifications
    public static bool ibSensors = false;     //		Body Sensors

    public static bool ibSMS = true;          //		SMS, text msg's
    public static bool ibStorage = true;      //		Sims storage

    public static bool ibSpeech = false;      //		Speech

    //
    //E N T R Y
    //
    public static int adultCompressInterval = 600; // 1000 ms is one second, need 100 compressions/min

    // Run error (not flat)
    public static bool runError = false;
    public static bool timerIsOnOff = false;
    public static int dataBracket = 0;

    public static int notFlat = 50;
    public static int noAction = 101;
    public static int nowRcd = 150;


    public static float zValueLowest = 0.0f;
    public static float zValueHighest = 0.0f;


    public static float Z_Value = 0.0f;


    public static string dateTimeinTimer = "";
    public static bool inAcelError = false;

    //public static int DoingCompressions = 0;
    //public static int DoingCompressions_Total = 0;

    public static int acellCounter = 0;
    public static int timerCounter = 0;
    public static bool gotaCompress = false;

    //public static string[6, 6] CompressRes = new string[6, 6];


    public App()
    {

      //Register Syncfusion license
      Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTU0NTE1QDMxMzcyZTMzMmUzMGoyaUhVcUxIM0t0UGMxUGdTYVI4aFkvQVpoZUlmUWhDVVpMOGJ1ZGpueGM9");
      //                                                             "MTMzNDk3QDMxMzcyZTMyMmUzMGhyNkxWTGFWT1pRZFhTN1hqSGgyL3owQjlFZXdEMnZ2OVVlNXJJYUlsZjQ9");
      //
      //

      InitializeComponent();

      //
      //Debug.WriteLine("---------- MainPage called!");
      // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      // IMPORTANT!
      //
      // The following globals must be set to "1" just before Production
      // 0 = off,   1 = on
      // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      //
      inTesting = false; // true;
                         //
                         // need to find if this is first startup after (new) install
                         //
                         //grb//if ((Preferences.Get("inFirstRun", "default_value")).Contains("BgU"))
                         //grb//{
                         //grb//inFirstRun = false;
                         //grb//}
                         //grb//else
                         //grb//{
                         //grb//inFirstRun = true;
                         //grb//}
                         //
      if (inFirstRun)
      {
        //grb//Preferences.Set("inFirstRun", "BgU");
        //grb//Preferences.Set("leadInSound", "0");
        //
        //
        // Autonotification for all three name groups
        //grb//Preferences.Set("setAutoemail1", "0");
        //grb//Preferences.Set("setAutoemail2", "0");
        //grb//Preferences.Set("setAutoemail3", "0");
        // 
        // sound pitch
        //grb//Preferences.Set("SpeechPitch", "50");
        // sound rate
        //grb//Preferences.Set("SpeechVolume", "100");
        //grb//Preferences.Set("Assessment", "0");
        //grb//Preferences.Set("TrainingMode", "0");

        // Speech to text
        //grb//Preferences.Set("SpeechInput1", "");
        //grb//Preferences.Set("SpeechInput2", "");
      }



      // ...............................................................// lifted from 
      var content = new Entry100();       // TodoListPage(); // new AHeadSplash1();
      NavigationPage navPage = new NavigationPage(content)
      {
        Title = "Near Hospitals, ER's",

        BarBackgroundColor = Color.LightGreen, //Color.FromHex("91CA47"), //(Color)App.Current.Resources["primaryGreen"],
        BarTextColor = Color.Black, //White,
        BackgroundColor = Color.LightGreen,
        IsEnabled = true,
        IsVisible = true
      };
      MainPage = navPage;
      //
      //MainPage = new MainPage();
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }





    public class CCMed : StackLayout
    {
      public CCMed()
      {
        TopStack = new StackLayout // TOP stack
        {
          Orientation = StackOrientation.Horizontal,
          VerticalOptions = LayoutOptions.Start,
          HorizontalOptions = LayoutOptions.StartAndExpand
        };

        CenterStack = new StackLayout // CENTER stack
        {
          Orientation = StackOrientation.Horizontal,
          VerticalOptions = LayoutOptions.StartAndExpand,
          HorizontalOptions = LayoutOptions.StartAndExpand
        };

        BottomStack = new StackLayout // BOTTOM stack
        {
          Orientation = StackOrientation.Horizontal,
          VerticalOptions = LayoutOptions.End,
          HorizontalOptions = LayoutOptions.CenterAndExpand
        };

        Children.Add(TopStack);
        Children.Add(CenterStack);
        Children.Add(BottomStack);
      }

      public StackLayout BottomStack { get; private set; }
      public StackLayout CenterStack { get; private set; }
      public StackLayout TopStack { get; private set; }
    }


  }
}
