using System.Drawing;
using Infragistics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonkeysList.Touch.Views
{
    [Register("SingleRowGridView")]
    public class SingleRowGridView : UIView
    {
        //GridView that is displayed
        public IGGridView GridView;

        //Column Definition of GridView's column
        private IGGridViewImageColumnDefinition _col;

        //Datasource Helper to assist with databinding
        public IGGridViewSingleRowSingleFieldDataSourceHelper Ds;

        public SingleRowGridView()
        {
            Initialize();
        }

        public SingleRowGridView(RectangleF bounds)
            : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {

            BackgroundColor = UIColor.Black;

            //Create a Gridview that's a bit farther down than center
            //This Grid has a single row of 200x200 cells
            GridView = new IGGridView(new RectangleF(0f, Frame.Size.Height / 2 - 100, Frame.Size.Width, 200f), IGGridViewStyle.IGGridViewStyleDefault)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleTopMargin,
                SelectionType = IGGridViewSelectionType.IGGridViewSelectionTypeCell,
                HeaderHeight = 0f,
                EmptyRows = false,
                RowSeparatorHeight = 0f,
                AllowHorizontalBounce = true,
                AlwaysBounceVertical = false,
                RowHeight = 200f,
                ColumnWidth = IGColumnWidth.CreateNumericColumnWidth(200f),
                Theme = new IGGridViewLightTheme()
            };

            AddSubview(GridView);

            //Create Image Column definition for Image property that gets the image from a URL
            _col = new IGGridViewImageColumnDefinition(@"Image",
                                                       IGGridViewImageColumnDefinitionPropertyType
                                                       .IGGridViewImageColumnDefinitionPropertyTypeStringUrl);

            //Create a new Datasource helper that is initialized with the column we just created
            Ds = new IGGridViewSingleRowSingleFieldDataSourceHelper(_col);
            
            //set the Grid's datasource to the one that we created
            GridView.DataSource = Ds;
            GridView.ReloadData();

        }
    }

    //The DataSource helper's data property must be of type NSObject
    [Register("SingleRowData")]
    public class SingleRowData : NSObject
    {

        public SingleRowData(string image)
        {
            Image = image;
        }

        [Export("Image")]
        public string Image { get; set; }
    }
}
