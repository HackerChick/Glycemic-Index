using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using GlycemicIndex.Model;

namespace GlycemicIndex.DataAccess
{
    public static class FoodRepository
    {
        private const string DATA_FILE = "Data/Foods.xml";
        public enum IndexLevel { Low=0, Med=1, High=2 }
        
        public static Dictionary<int, Category> Categories { get; private set; }
        public static Dictionary<IndexLevel, IndexRange> IndexRanges { get; private set; }
        public static Dictionary<int, Food> Foods { get; private set; }

        static FoodRepository()
        {
            LoadIndexRanges();
            LoadFoods(DATA_FILE);
        }

        private static void LoadIndexRanges()
        {
            // defs from wiki: http://en.wikipedia.org/wiki/Glycemic_index
            IndexRanges = new Dictionary<IndexLevel, IndexRange>();
            IndexRanges.Add(IndexLevel.Low, new IndexRange() {Id = (int) IndexLevel.Low, Name = "Low (< 55)", MinValue = 0, MaxValue = 55});
            IndexRanges.Add(IndexLevel.Med, new IndexRange() { Id = (int)IndexLevel.Med, Name = "Medium (56-69)", MinValue = 56, MaxValue = 69 });
            IndexRanges.Add(IndexLevel.High, new IndexRange() { Id = (int)IndexLevel.High, Name = "High (70+)", MinValue = 70, MaxValue = 100 });
        }

        public static Category GetCategory(int id)
        {
            return Categories[id];
        }
        
        public static IndexRange GetIndexRange(int id)
        {
            return IndexRanges[(IndexLevel)id];
        }

        public static Food GetFood(int id)
        {
            return Foods[id];
        }

        private static void LoadFoods(string dataFile)
        {
            Categories = new Dictionary<int, Category>();
            Foods = new Dictionary<int, Food>();

            var root = XElement.Load(dataFile);

            int catId = 0;
            int foodId = 0; 
            foreach (var cat in root.Elements("category"))
            {
                var category = new Category()
                                   {
                                       Id = catId++,
                                       Name = (string)cat.Attribute("Name"),
                                   };


                foreach (var f in cat.Descendants("foods").Elements("food"))
                {
                    var food = new Food()
                                   {
                                       Id = foodId++,
                                       Category = category,
                                       Name = (string) f.Attribute("Name"),
                                       GlycemicIndex = (int) f.Attribute("GI"),
                                       GlycemicLoad = (int) f.Attribute("GL"),
                                       GIComplete = (string)f.Attribute("GIFull"),
                                       ServingSize = (string)f.Attribute("Serving")
                                   };
                    category.Foods.Add(food);

                    Foods.Add(food.Id, food);
                    AddFoodToAppropriateIndexRange(food);
                }

                Categories.Add(category.Id, category);
            }
        }

        private static void AddFoodToAppropriateIndexRange(Food food)
        {
            if( food.GlycemicIndex < IndexRanges[IndexLevel.Med].MinValue ) IndexRanges[IndexLevel.Low].Foods.Add(food);
            else if( food.GlycemicIndex > IndexRanges[IndexLevel.Med].MaxValue ) IndexRanges[IndexLevel.High].Foods.Add(food);
            else IndexRanges[IndexLevel.Med].Foods.Add(food);
        }
    }
}
