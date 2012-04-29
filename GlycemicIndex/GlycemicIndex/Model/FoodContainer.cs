using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlycemicIndex.Model
{
    abstract public class FoodContainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Food> Foods{ get; set; }
        protected FoodContainer()
        {
            Foods = new List<Food>();
        }
    }
}
