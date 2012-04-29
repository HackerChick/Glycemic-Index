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
using GlycemicIndex.DataAccess;
using GlycemicIndex.Model;

namespace GlycemicIndex.ViewModel
{
    public class MainViewModel 
    {
        public List<CategoryViewModel> Categories { get; private set; }
        public List<IndexRangeViewModel> IndexRanges { get; private set; }
        public List<Food> Foods { get; private set; }
        public string Credits { get; private set; }

        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            Foods = new List<Food>(FoodRepository.Foods.Values);
            Foods.Sort((x, y) => string.Compare(x.Name, y.Name));

            Categories = new List<CategoryViewModel>();
            foreach (var cat in FoodRepository.Categories.Values)
            {
                Categories.Add(new CategoryViewModel(cat));
            }
            Categories.Sort((x, y) => string.Compare(x.Name, y.Name));

            IndexRanges = new List<IndexRangeViewModel>();
            foreach (var idx in FoodRepository.IndexRanges.Values)
            {
                IndexRanges.Add(new IndexRangeViewModel(idx));
            }

            Credits = "Application by Digital Muse, LLC\r\n\r\n" +
                "Data based on \r\nThe American Journal of Clinical Nutrition \r\nhttp://www.ajcn.org/content/76/1/5.full\r\n\r\n" +
                "Sushi photo by NickNguyen\r\nhttp://bit.ly/mboKnr\r\nCreative Commons Copyright(cc) Attribution-ShareAlike 2.0";
        }

    }
}
