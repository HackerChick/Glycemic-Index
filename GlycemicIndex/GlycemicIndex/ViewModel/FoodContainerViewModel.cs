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
    abstract public class FoodContainerViewModel
    {
        protected abstract FoodContainerType GetFoodContainerType();
        protected abstract void SortFoods();

        protected readonly FoodContainer subject;
        public RelayCommand LoadFoodsCommand { get; private set; }

        public FoodContainerViewModel(FoodContainer foodContainer)
        {
            subject = foodContainer;
            Foods = new List<Food>(subject.Foods);
            SortFoods();
            LoadFoodsCommand = new RelayCommand(LoadFoods);
        }

        private FoodContainerViewModel(){}

        public int Id { get { return subject.Id; } }
        public string Name { get { return subject.Name; } }
        public List<Food> Foods { get; private set; }
        public string Title { get { return ApplicationController.Default.ContainerTypes[GetFoodContainerType()]; } }

        private void LoadFoods()
        {
            ApplicationController.Default.NavigateTo(ViewType.FoodListing, GetFoodContainerType(), Id);
        }

    }
}
