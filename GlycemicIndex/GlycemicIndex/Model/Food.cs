using System;
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
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int GlycemicIndex { get; set; }
        public string GIComplete { get; set; }  // includes +/- margin of error (when applicable)
        public string ServingSize { get; set; }
        public int? GlycemicLoad { get; set; }
        }
}
