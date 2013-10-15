using System.Collections.Generic;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using MonkeysList.Core.Models;
using MonkeysList.Core.Services;

namespace MonkeysList.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {

        public FirstViewModel()
        {
            //Resolve IMonkeyGenerator from Ioc
            var svc = Mvx.Resolve<IMonkeyGenerator>();
            var monkeys = new List<Monkey>();

            for (int i = 0; i < 20; i++)
            {
                //Generate Monkeys!
                monkeys.Add(svc.GenerateMonkey());
            }

            Monkeys = monkeys;
        }

        private List<Monkey> _monkeys;
        public List<Monkey> Monkeys
        {
            get { return _monkeys; }
            set
            {
                _monkeys = value;
                RaisePropertyChanged(() => Monkeys);
            }
        }	
    }
    
}
