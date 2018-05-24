using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Platforms.Ios.Views;
using Syncfusion.SfChart.iOS;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;

namespace MvvmcrossDemo
{

    [Register("SecondView")]
    public class SecondView : MvxViewController
    {
        public SecondView()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;

            base.ViewDidLoad();

            SFChart chart = new SFChart();
            chart.Frame = new CGRect(0, 200, 300, 300);

            //Adding Primary Axis for the Chart.
            SFCategoryAxis primaryAxis = new SFCategoryAxis();
            chart.PrimaryAxis = primaryAxis;

            //Adding Secondary Axis for the Chart.
            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            chart.SecondaryAxis = secondaryAxis;

            this.View.AddSubview(chart);

            //Initializing column series
            SFColumnSeries series = new SFColumnSeries()
            {
                XBindingPath = "price_btc",

                YBindingPath = "timestamp"
            };

            chart.Series.Add(series);

            var set = this.CreateBindingSet<SecondView, SecondViewModel>();

            //set.Bind(series).For(s => s.ItemsSource).To(vm => vm.CoinHistory);
            set.Bind(series).For("ItemsSource").To(vm => vm.CoinHistory);

            //set.Bind(loadBtn).To(vm => vm.LoadDataCommand);
            set.Apply();
        }
    }
}