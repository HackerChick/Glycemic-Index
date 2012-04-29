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

namespace GlycemicIndex.Model
{
    public class IndexRange : FoodContainer
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
