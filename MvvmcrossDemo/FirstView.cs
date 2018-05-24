using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using Syncfusion.SfChart.iOS;
using UIKit;

namespace MvvmcrossDemo
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        UITableView TableView = new UITableView();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            View.AddSubview(TableView);
            TableView.Frame = View.Bounds;
            var source = new TableSource(TableView);

            TableView.Source = source;
            TableView.RowHeight = 120f;
            TableView.ReloadData();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();

            set.Bind(source).For(s => s.ItemsSource).To(vm => vm.ItemsGroup);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowDetailsCommand);

            set.Apply();
        }
    }

    public class TableSource : MvxTableViewSource
    {
        private static readonly NSString CellIdentifier = new NSString("MyTableViewCell");

        public TableSource(UITableView tableView)
                : base(tableView)
        {
            tableView.RegisterNibForCellReuse(UINib.FromName("MyTableViewCell", NSBundle.MainBundle),
                                              CellIdentifier);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell(CellIdentifier, indexPath);
        }

    }
}