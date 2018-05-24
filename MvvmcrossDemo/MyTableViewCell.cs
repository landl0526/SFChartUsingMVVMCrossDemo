﻿using System;
using System.Collections.Generic;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace MvvmcrossDemo
{
    public partial class MyTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MyTableViewCell");
        public static readonly UINib Nib;

        static MyTableViewCell()
        {
            Nib = UINib.FromName("MyTableViewCell", NSBundle.MainBundle);
        }

        public string Name
        {
            get { return LBL_NAME.Text; }
            set { LBL_NAME.Text = value; }
        }

        protected MyTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            this.DelayBind(() =>
            {
                this.CreateBinding().For((cell) => cell.Name).To((Item item) => item.Name).Apply();
            });

        }
    }


    public class Item
    {
        public string Name { set; get; }

        public List<CoinHistoryModel> SingleCoinHistory { set; get; }
    }
}
