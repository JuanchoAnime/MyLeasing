using Xamarin.Forms;

namespace MyLeasing.Views
{
    public partial class LeasingMasterDetail : MasterDetailPage
    {
        public LeasingMasterDetail()
        {
            InitializeComponent();
            App.Master = this;
        }
    }
}