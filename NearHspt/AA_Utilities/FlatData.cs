// ..............................................................
// Copyright @ 2019, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: FlatData
// Vers: 3.0.0.0
//
// Low-Level IO routines
// .............................................................
using System;

using System.IO;
using System.Reflection;

using Xamarin.Essentials;

namespace NearHspt.AA_Utilities
{
  class FlatData
  {

    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Get hospital "DB"
    //
    //
    // 00 - biz_name
    // 01 - biz_info
    // 02 - e_address
    // 03 - e_city
    // 04 - e_state
    // 05 - e_postal
    // 06 - e_country
    // 07 - loc_county
    // 08 - loc_LAT_poly
    // 09 - loc_LONG_poly
    // 10 - biz_phone
    // 11 - web_url
    // 12 - f_emergency
    // 13 - biz_bedcount
    //
    //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    public static bool GetHospitalDB()
    {

      bool iB = false;
      string strtext = "";

      try
      {

        var assembly = typeof(Entry100).GetTypeInfo().Assembly;
        foreach (var res in assembly.GetManifestResourceNames())
        {
          if (res.Contains("NearHspt.kranken.txt"))
          {
            Stream stream = assembly.GetManifestResourceStream(res);

            using (var reader = new StreamReader(stream))
            {
              strtext = reader.ReadToEnd();
            }
          }
        }

        // Split into lines.
        strtext = strtext.Replace('\n', '\r');
        string[] hosplines = strtext.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
        strtext = "";

        App.hospitalsDBRowsCount = hosplines.Length;
        App.hospitalsDBColsCount = hosplines[0].Split(',').Length;
        //
        // split each record into fields ... hospitalsDBArray[inow, jnow] ...
        //
        App.hospitalsDB = new string[App.hospitalsDBRowsCount, App.hospitalsDBColsCount];
        for (int inow = 1; inow < App.hospitalsDBRowsCount; inow++)
        {
          string[] tempLine = hosplines[inow].Split(',');
          for (int jnow = 0; jnow < App.hospitalsDBColsCount; jnow++)
          {
            App.hospitalsDB[inow - 1, jnow] = tempLine[jnow];
          }
        }
        iB = false;
        for (int know = 1; know < App.hospitalsDBRowsCount; know++)
        {
          hosplines[know] = null;
        }

      }
      catch (Exception stre)
      {
        string aa = stre.Message.ToString();
        iB = true;
      }
      return iB;
    }


    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Load a two-dimensional array with 
    // 1) all indexes (into hospitalsDB )
    // 2) distance for that index
    //
    // 1. get distance from target to every hospital
    // 2. if < 10/20/30/40 save in index array <hospital pointer, distance>
    // 3. sort the helper arrays by distance. 
    //      We now have 5 arrays, sorted by distance, holding hospital pointers
    // 4. Fill the actual details arrays using the helper arrays
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    public static void Load_HospitalsInRage(double inLatfrom, double inLongfrom)
    {
      //
      //
      bool iB = true;
      Location coord1 = new Location(inLatfrom, inLongfrom);
      Location coord2 = new Location(inLatfrom, inLongfrom);    // dummy entry, just to get location
      double distanceInRadius = 0.0f;
      Int32 intdistanceInRadius = 0;

      App.hospitalsInRangeCount = 0;
      if (inLatfrom <= 0.0) iB = false;
      if (inLongfrom <= 0.0) iB = false;

      try
      {
        //
        // Get Distance, and fill helper arrays 
        //
        App.hospitalsInRangeCount = 0;
        for (int innn = 0; innn < App.hospitalsDBRowsCount; innn++)
        {
          //
          // 100 count
          //
          if (App.hospitalsInRangeCount == 101) break;
          // There are some records that have no Latitude / Longitude
          // both cases will be handled by the abreviated catch {}
          try
          {
            // Get 'radian' distance, i.e. "Birdview" distance between device-address and array entry
            coord2 = new Location(Convert.ToDouble(App.hospitalsDB[innn, 8]), Convert.ToDouble(App.hospitalsDB[innn, 9]));
            distanceInRadius = Location.CalculateDistance(coord1, coord2, DistanceUnits.Miles);
            intdistanceInRadius = Convert.ToInt32((distanceInRadius) * 100);
            if (intdistanceInRadius < App.requestedHospitalRange)
            {
              App.hospitalsInRange[App.hospitalsInRangeCount, 0] = innn;
              App.hospitalsInRange[App.hospitalsInRangeCount, 1] = intdistanceInRadius;
              App.hospitalsInRangeCount++;
              iB = false;
            }

          }
          catch (Exception stre)
          {
            string aa = stre.Message.ToString();
          }
        }

      }
      catch (Exception stre)
      {
        string aa = stre.Message.ToString();
      }

      if (App.hospitalsInRangeCount != 0) App.hospitalsInRangeCount = App.hospitalsInRangeCount - 1;


      //
      // sort helper arrays by distance
      //
      if (iB == false)
      {
        FlatData.SorthospitalsInRange();
      }
    }


    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Sort the in-range array  App.hospitalsInRange  by distance  
    //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    public static void SorthospitalsInRange()
    {
      // helper class
      Int32 tempPoint = 0;
      Int32 tempDis = 0;


      bool didSwap;
      do
      {
        didSwap = false;
        for (int i = 0; i < App.hospitalsInRangeCount; i++)
        {
          if (App.hospitalsInRange[i, 1] > App.hospitalsInRange[i + 1, 1])
          {
            tempPoint = App.hospitalsInRange[i + 1, 0];                       // save pointer 
            tempDis = App.hospitalsInRange[i + 1, 1];                         // save distance
            App.hospitalsInRange[i + 1, 0] = App.hospitalsInRange[i, 0];  // write next higher to lower
            App.hospitalsInRange[i + 1, 1] = App.hospitalsInRange[i, 1];
            App.hospitalsInRange[i, 0] = tempPoint;                   // write saved to higher
            App.hospitalsInRange[i, 1] = tempDis;
            didSwap = true;
          }
        }
      } while (didSwap);

    }


  }

}
