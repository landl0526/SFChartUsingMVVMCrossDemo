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


        public FirstViewModel()
        {
            ItemsGroup = new List<Item>();
            for (int i=0; i<10; i++)
            {
                var CoinList = new List<CoinHistoryModel>()
                {
                    new CoinHistoryModel{ price_btc = "First", timestamp = 10 + i * 5 },
                    new CoinHistoryModel{ price_btc = "Second", timestamp = 20 + i * 5 },
                    new CoinHistoryModel{ price_btc = "Third", timestamp = 30 + i * 5 }
                };
                ItemsGroup.Add(new Item { Name = "name" + i, SingleCoinHistory = CoinList });
            }
        }


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


        //private MvxCommand loadDataCommand;
        //public ICommand LoadDataCommand
        //{
        //    get
        //    {
        //        return loadDataCommand ?? (loadDataCommand = new MvxCommand(ExecuteloadDataCommand));
        //    }
        //}
        //private void ExecuteloadDataCommand()
        //{
        //    CoinHistory = new List<CoinHistoryModel>()
        //    {
        //        new CoinHistoryModel{ price_btc = "First", timestamp = 10 },
        //        new CoinHistoryModel{ price_btc = "Second", timestamp = 20 },
        //        new CoinHistoryModel{ price_btc = "Third", timestamp = 30 }
        //    };
        //}


        private List<Item> _ItemsGroup;
        public List<Item> ItemsGroup
        {
            get
            {
                return _ItemsGroup;
            }
            set
            {
                _ItemsGroup = value;
                RaisePropertyChanged(() => ItemsGroup);
            }
        }

        private MvxCommand<Item> showDetailsCommand;
        public ICommand ShowDetailsCommand
        {
            get
            {
                return showDetailsCommand ?? (showDetailsCommand = new MvxCommand<Item>(showDetails));
            }
        }
        async void showDetails(Item item)
        {
            await _navigationService.Value.Navigate<SecondViewModel, Item>(item);
        }

    }

    
}