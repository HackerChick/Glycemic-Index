using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GlycemicIndex.DataAccess;
using GlycemicIndex.ViewModel;
using Microsoft.Phone.Controls;

namespace GlycemicIndex.View
{
    public partial class FoodListing : PhoneApplicationPage
    {
        public FoodListing()
        {
            InitializeComponent();
        }

        // Use this to grab selectedItem out of the query string and set datacontext accordingly
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string containerType = "";
            string selectedId = "";
            if (NavigationContext.QueryString.TryGetValue("container", out containerType) && NavigationContext.QueryString.TryGetValue("selectedItem", out selectedId))
            {
                int id = int.Parse(selectedId);

                FoodContainerViewModel vm;
                if (containerType.Equals("levels")) 
                    vm = new IndexRangeViewModel(FoodRepository.GetIndexRange(id));
                else vm = new CategoryViewModel(FoodRepository.GetCategory(id));

                DataContext = vm;
            }
        }
    }
}