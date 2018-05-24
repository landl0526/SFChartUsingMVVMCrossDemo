using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.ViewModels;
using UIKit;

namespace MvvmcrossDemo
{
    public class SecondViewModel : MvxViewModel<Item>
    {
        private List<CoinHistoryModel> _CoinHistory;

        public List<CoinHistoryModel> CoinHistory
        {
            get
            {
                return _CoinHistory;
            }
            set
            {
                _CoinHistory = value;
                RaisePropertyChanged(() => CoinHistory);
            }
        }

        public override void Prepare(Item parameter)
        {
            CoinHistory = parameter.SingleCoinHistory;
        }
    }
}