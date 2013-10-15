using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using MonkeysList.Touch.Target;
using MonkeysList.Touch.Views;
using MonoTouch.UIKit;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;

namespace MonkeysList.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        //Set up Target Bindings
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<SingleRowGridView>("SingleRowData", source => new SingleRowDataSourceTargetBinding(source));
            base.FillTargetFactories(registry);
        }
	}
}