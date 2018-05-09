using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Foundation;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using UIKit;

namespace MvvmcrossDemo
{
    public class FirstViewModel
        : MvxViewModel
    {
        private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.Resolve<IMvxNavigationService>);

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


        private MvxCommand loadDataCommand;
        public ICommand LoadDataCommand
        {
            get
            {
                return loadDataCommand ?? (loadDataCommand = new MvxCommand(ExecuteloadDataCommand));
            }
        }
        private void ExecuteloadDataCommand()
        {
            CoinHistory = new List<CoinHistoryModel>()
            {
                new CoinHistoryModel{ price_btc = "First", timestamp = 10 },
                new CoinHistoryModel{ price_btc = "Second", timestamp = 20 },
                new CoinHistoryModel{ price_btc = "Third", timestamp = 30 }
            };
        }
    }

    public class CoinHistoryModel
    {
        public string price_btc { get; set; }

        public double timestamp { get; set; }
    }
}