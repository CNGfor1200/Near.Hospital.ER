﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
//using Syncfusion.SfChart.XForms.iOS.Renderers;
//using Syncfusion.SfSunburstChart.XForms.iOS;
//using Syncfusion.SfImageEditor.XForms.iOS;
using Syncfusion.SfDataGrid.XForms.iOS;
//using Syncfusion.SfPicker.XForms.iOS;
//using Syncfusion.SfPdfViewer.XForms.iOS;
//using Syncfusion.SfRangeSlider.XForms.iOS;
//using Syncfusion.SfSchedule.XForms.iOS;
//using Syncfusion.SfGauge.XForms.iOS;
//using Syncfusion.XForms.iOS.ProgressBar;
//using Syncfusion.SfCalendar.XForms.iOS;
//using Syncfusion.SfCarousel.XForms.iOS;
//using Syncfusion.SfRotator.XForms.iOS;
//using Syncfusion.SfAutoComplete.XForms.iOS;
//using Syncfusion.SfBusyIndicator.XForms.iOS;
//using Syncfusion.SfNavigationDrawer.XForms.iOS;
//using Syncfusion.SfNumericTextBox.XForms.iOS;
//using Syncfusion.SfNumericUpDown.XForms.iOS;
//using Syncfusion.SfRadialMenu.XForms.iOS;
//using Syncfusion.SfRating.XForms.iOS;
//using Syncfusion.SfMaps.XForms.iOS;
//using Syncfusion.SfTreeMap.XForms.iOS;
//using Syncfusion.SfPullToRefresh.XForms.iOS;
//using Syncfusion.ListView.XForms.iOS;
//using Syncfusion.SfKanban.XForms.iOS;
//using Syncfusion.RangeNavigator.XForms.iOS;
//using Syncfusion.SfSparkline.XForms.iOS;
//using Syncfusion.SfBarcode.XForms.iOS;
//using Syncfusion.XForms.iOS.DataForm;
//using Syncfusion.XForms.iOS.MaskedEdit;
using Syncfusion.XForms.iOS.PopupLayout;
//using Syncfusion.SfDiagram.XForms.iOS;
//using Syncfusion.XForms.iOS.TabView;
using Syncfusion.XForms.iOS.Buttons;
//using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.TextInputLayout;
//using Syncfusion.XForms.iOS.TreeView;
using Syncfusion.XForms.iOS.Border;
//using Syncfusion.XForms.iOS.ParallaxView;
//using Syncfusion.XForms.iOS.BadgeView;
//using Syncfusion.XForms.iOS.Expander;
//using Syncfusion.XForms.iOS.Cards;
//using Syncfusion.XForms.iOS.Accordion;


namespace NearHspt.iOS
{
  // The UIApplicationDelegate for the application. This class is responsible for launching the 
  // User Interface of the application, as well as listening (and optionally responding) to 
  // application events from iOS.
  [Register("AppDelegate")]
  public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
  {
    //
    // This method is invoked when the application has loaded and is ready to run. In this 
    // method you should instantiate the window, load the UI into it and then make the window
    // visible.
    //
    // You have 17 seconds to return from this method, or iOS will terminate your application.
    //
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      global::Xamarin.Forms.Forms.Init();
      //SfChartRenderer.Init();
      //SfSunburstChartRenderer.Init();
      //SfImageEditorRenderer.Init();
      SfDataGridRenderer.Init();
      //SfPickerRenderer.Init();
      //SfPdfDocumentViewRenderer.Init();
      //SfRangeSliderRenderer.Init();
      //SfScheduleRenderer.Init();
      //SfGaugeRenderer.Init();
      //SfDigitalGaugeRenderer.Init();
      //SfLinearGaugeRenderer.Init();
      //SfLinearProgressBarRenderer.Init();
      //SfCircularProgressBarRenderer.Init();
      //SfCalendarRenderer.Init();
      //SfCarouselRenderer.Init();
      //SfRotatorRenderer.Init();
      //SfAutoCompleteRenderer.Init();
      //SfBusyIndicatorRenderer.Init();
      //SfNavigationDrawerRenderer.Init();
      //SfNumericTextBoxRenderer.Init();
      //SfNumericUpDownRenderer.Init();
      //SfRadialMenuRenderer.Init();
      //SfRatingRenderer.Init();
      //SfMapsRenderer.Init();
      //SfTreeMapRenderer.Init();
      //SfPullToRefreshRenderer.Init();
      //SfListViewRenderer.Init();
      //SfKanbanRenderer.Init();
      //SfRangeNavigatorRenderer.Init();
      //SfSparklineRenderer.Init();
      //SfBarcodeRenderer.Init();
      //SfDataFormRenderer.Init();
      //SfMaskedEditRenderer.Init();
      //                                SfPopupLayoutRenderer.Init();
      Syncfusion.XForms.iOS.PopupLayout.SfPopupLayoutRenderer.Init();
      //SfDiagramRenderer.Init();
      //SfTabViewRenderer.Init();
      SfCheckBoxRenderer.Init();
      SfRadioButtonRenderer.Init();
      SfSegmentedControlRenderer.Init();
      //SfComboBoxRenderer.Init();
      SfTextInputLayoutRenderer.Init();
      //SfTreeViewRenderer.Init();
      SfButtonRenderer.Init();
      SfBorderRenderer.Init();
      //SfParallaxViewRenderer.Init();
      //SfBadgeViewRenderer.Init();
      //SfExpanderRenderer.Init();
      //SfCardViewRenderer.Init();
      //SfCardLayoutRenderer.Init();
      //SfAccordionRenderer.Init();
      SfSwitchRenderer.Init();
      LoadApplication(new App());

      return base.FinishedLaunching(app, options);
    }
  }
}
