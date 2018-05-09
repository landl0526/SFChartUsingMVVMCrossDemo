using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using Syncfusion.SfChart.iOS;
using UIKit;

namespace MvvmcrossDemo
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            SFChart chart = new SFChart();
            chart.Frame = new CGRect(1, 200, 300, 300);

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


            UIButton loadBtn = new UIButton(UIButtonType.System);
            loadBtn.SetTitle("Load", UIControlState.Normal);
            loadBtn.Frame = new CGRect(0, 100, 50, 50);
            View.AddSubview(loadBtn);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();

            //set.Bind(series).For(s => s.ItemsSource).To(vm => vm.CoinHistory);
            set.Bind(series).For("ItemsSource").To(vm => vm.CoinHistory);

            set.Bind(loadBtn).To(vm => vm.LoadDataCommand);
            set.Apply();
        }
    }
}