using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using GlycemicIndex.Model;
using MoveIt.Helpers;

namespace GlycemicIndex.ViewModel
{
    public class CategoryViewModel : FoodContainerViewModel
    {
        public CategoryViewModel( Category category ) : base(category)
        {
        }

        override protected FoodContainerType GetFoodContainerType()
        {
            return FoodContainerType.Category;
        }

        protected override void SortFoods()
        {
            Foods.Sort((x, y) => string.Compare(x.Name, y.Name));
        }
    }
}
