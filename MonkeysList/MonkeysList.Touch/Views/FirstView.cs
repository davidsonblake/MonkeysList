using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace MonkeysList.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        private SingleRowGridView _gridView;

        public override void ViewDidLoad()
        {
          
            base.ViewDidLoad();

            //Initialize new SingleRowGridView
            _gridView = new SingleRowGridView(View.Bounds);

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;
			
            //Bind GridView 
            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(_gridView).For("SingleRowData").To(vm => vm.Monkeys);
            set.Apply();

            Add(_gridView);
        }
    }
}