using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using MonkeysList.Core.Models;
using MonkeysList.Touch.Views;
using MonoTouch.Foundation;

namespace MonkeysList.Touch.Target
{
    //Inherit from MvxTarget binding to perform custom binding 
    public class SingleRowDataSourceTargetBinding : MvxTargetBinding
    {
        //Return View as User Defined View
        protected SingleRowGridView View
        {
            get { return Target as SingleRowGridView; }
        }

        public SingleRowDataSourceTargetBinding(SingleRowGridView view)
            : base(view)
        {
            if (view == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - GridViewSource is null in SingRowDataSourceTargetBinding");
            }
        }

        //Override SetValue to perform binding
        public override void SetValue(object value)
        {
            var view = View;
            if (view == null)
                return;
           
            var monkeys = (List<Monkey>)value;
           
            //Grab items from list that was passed in, and create new NSObject[]
            if (monkeys != null)
            {
                View.Ds.Data = monkeys.Select(t => new SingleRowData(t.ImageUrl)).ToArray();

                //Must Call ReloadData 
                View.GridView.ReloadData();
            }

        }

        //Set the target type
        public override Type TargetType
        {
            get { return typeof(NSObject[]); }
        }

        //Set the Default binding Mode
        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }
    }
}
