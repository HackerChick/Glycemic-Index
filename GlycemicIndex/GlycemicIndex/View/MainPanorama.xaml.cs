using GlycemicIndex.ViewModel;
using Microsoft.Phone.Controls;

namespace GlycemicIndex.View
{
    public partial class MainPanorama : PhoneApplicationPage
    {
        // Constructor
        public MainPanorama()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
   }
}