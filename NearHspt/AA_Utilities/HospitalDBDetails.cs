// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: HospitalDBDetails
// Vers: 3.0.0.0
//
// Fields for the 'Hospital' DB
// .............................................................
using System;
using System.Collections.ObjectModel;

namespace NearHspt
{
  public class HospitalDBDetails
  {
    private ObservableCollection<HospitalDBInfo> hospitalInfo;
    public ObservableCollection<HospitalDBInfo> HospitalInfoCollection
    {
      get { return hospitalInfo; }
      set { this.hospitalInfo = value; }
    }

    public HospitalDBDetails()
    {
      hospitalInfo = new ObservableCollection<HospitalDBInfo>();
      this.GenerateOrders();
    }

    private void GenerateOrders()
    {


      // ????????????????????????????????????????????????????????????????????????????????????????????????????????????


      // .........................................................................................
      // 1. we have a list of hospital pointers distances (from FindHospital"
      // 2. we will create a list (setList6) of hospitals, (distance, Name), keyed by distance
      // .........................................................................................
      //ObservableCollection<HospitalListmach> listSource6s = new ObservableCollection<HospitalListmach>();


      ////////////////////string[] setList6 = new string[App.hospitalsInRangeCount];
      //int inow;
      int newIndex;
      string strMilage;
      string strMiles;
      string strBeds;
      string strBedCount;
      string strName;
      App.hospitalsShownCount = 0;
      ////////////////////int icheckdis = Convert.ToInt32((App.requestedHospitalRange) * 100.00);
      ////////////////////for (inow = 0; inow < App.hospitalsInRangeCount; inow++)
      ////////////////////{
      ////////////////////  if ((Convert.ToInt32(App.hospitalsInRange[inow, 1])) < icheckdis)
      ////////////////////  {
      ////////////////////    newIndex = App.hospitalsInRange[inow, 0];
      ////////////////////    strMilage = (((Convert.ToDouble(App.hospitalsInRange[inow, 1])) / 100.0)).ToString();
      ////////////////////    strBeds = App.hospitalsDB[newIndex, 13];
      ////////////////////    if (strBeds == "") strBeds = "N/R";
      ////////////////////    strName = App.hospitalsDB[newIndex, 0];
      ////////////////////    //                      7.32                    399              CentraState
      ////////////////////    setList6[inow] = strMilage.ToString() + "^" + strBeds + "^" + strName;
      ////////////////////    //}
      ////////////////////  }
      ////////////////////  else
      ////////////////////  {
      ////////////////////    //
      ////////////////////    // the list is from shortest to longest distance
      ////////////////////    // the first time the listed milage is above the requested, we can leave the for loop
      ////////////////////    break;
      ////////////////////  }
      ////////////////////}


      //ObservableCollection<HospitalListmach> listSource6 = new ObservableCollection<HospitalListmach>();



      int know = 0;
      for (know = 0; know < App.hospitalsInRangeCount; know++)
      {

        newIndex = App.hospitalsInRange[know, 0];
        strMilage = (((Convert.ToDouble(App.hospitalsInRange[know, 1])) / 100.0)).ToString();
        strBeds = App.hospitalsDB[newIndex, 13];
        if (strBeds == "") strBeds = "N/R";
        strName = App.hospitalsDB[newIndex, 0];
        //                      7.32                    399              CentraState
        //setList6[inow] = strMilage.ToString() + "^" + strBeds + "^" + strName;





        // ?????????????????????????????????????????????????????????????????????????????????????
        // strTemp[0] "7.12"   [1] "399"    [2] "CentraState"
        //string[] strTemp = setList6[know].Split('^');
        strMiles = strMilage.ToString();    // strTemp[0];
        strBedCount = strBeds;              // strTemp[1];
        //strName = strName;                  // strTemp[2];

        //string temp100 = strName + "\n" + strmiles;
        //
        // "Bayshore Community Hospital\n   1.7 miles   181 beds"
        //listSource6.Add(new HospitalListmach { DisplayName = temp100 }); // setList6[know] });
        //
        hospitalInfo.Add(new HospitalDBInfo(strMiles, strBedCount, strName ));
      }
    }


  }
}