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
    public class IndexRangeViewModel : FoodContainerViewModel
    {
        public IndexRangeViewModel( IndexRange indexRange ) : base(indexRange)
        {
        }

        public int MinValue { get { return ((IndexRange)subject).MinValue; } }
        public int MaxValue { get { return ((IndexRange)subject).MaxValue; } }

        override protected FoodContainerType GetFoodContainerType()
        {
            return FoodContainerType.Index;
        }

        protected override void SortFoods()
        {
            Foods.Sort((x, y) => Compare(x.GlycemicIndex, y.GlycemicIndex));
        }

        public int Compare( int a, int b)
        {
            if (a < b) return -1;
            if (a > b) return 1;
            else return 0;
        }
    }
}
