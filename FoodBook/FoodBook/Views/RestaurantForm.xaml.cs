﻿using ExamApp.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestaurantForm : ContentPage
    {
        private bool isNew;
        Restaurant Item { get; set; }

        /// <summary>
        /// Use empty constructor when adding new Restaurants
        /// </summary>
        public RestaurantForm()
		{
			InitializeComponent();
            isNew = true;
            BindingContext = Item;
            SaveButton.Clicked += (s, e) => SaveRestaurant();
        }

        /// <summary>
        /// Pass the parameter when editing an existing constructor
        /// </summary>
        /// <param name="item">The restaurant to be edited</param>
        public RestaurantForm(Restaurant item)
        {
            InitializeComponent();
            Item = item;
            isNew = false;
            BindingContext = Item;
            SaveButton.Clicked += (s,e) => SaveRestaurant();
        }

        private async void SaveRestaurant()
        {
            if (isNew)
            {
                Restaurant newRestaurant = new Restaurant
                {
                    Id = new Guid().ToString(),
                    Title = Name.Text,
                    PhoneNumber = PhoneNumber.Text,
                    Description = Description.Text,
                };
                // Create the added restaurant
                await App.Repository.Create(newRestaurant);
                await SaveOpenHours(newRestaurant.Id);
            }
            else
            {
                // TODO remove ?? operators once DataBinding is confirmed as working
                Restaurant restaurant = new Restaurant
                {
                    Id = Item.Id,
                    Title = Name.Text ?? Item.Title,
                    PhoneNumber = PhoneNumber.Text ?? Item.PhoneNumber,
                    Description = Description.Text ?? Item.Description,
                };
                // Update the edited restaurant
                await App.Repository.Update(restaurant);
            }
            await Navigation.PopAsync();
        }

        private async Task SaveOpenHours(string newRestaurantId)
        {
            System.Collections.Generic.List<OpenHours> newOpenHours = new System.Collections.Generic.List<OpenHours>
                {
                    new OpenHours
                    {
                        Weekday = DayOfWeek.Monday,
                        RestaurantId = newRestaurantId,
                        Opens = new DateTime(0,0,0,10,0,0),
                        Closes = new DateTime(0,0,0,21,0,0)
                    },
                    new OpenHours
                    {
                        Weekday = DayOfWeek.Tuesday,
                        RestaurantId = newRestaurantId,
                        Opens = new DateTime(0,0,0,10,0,0),
                        Closes = new DateTime(0,0,0,21,0,0)
                    },
                    new OpenHours
                    {
                        Weekday = DayOfWeek.Wednesday,
                        RestaurantId = newRestaurantId,
                        Opens = new DateTime(0,0,0,10,0,0),
                        Closes = new DateTime(0,0,0,21,0,0)
                    },
                    new OpenHours
                    {
                        Weekday = DayOfWeek.Thursday,
                        RestaurantId = newRestaurantId,
                        Opens = new DateTime(0,0,0,10,0,0),
                        Closes = new DateTime(0,0,0,21,0,0)
                    },
                    new OpenHours
                    {
                        Weekday = DayOfWeek.Saturday,
                        RestaurantId = newRestaurantId,
                        Opens = new DateTime(0,0,0,12,0,0),
                        Closes = new DateTime(0,0,0,20,0,0)
                    },
                    new OpenHours
                    {
                        Weekday = DayOfWeek.Sunday,
                        RestaurantId = newRestaurantId,
                        Opens = new DateTime(0,0,0,12,0,0),
                        Closes = new DateTime(0,0,0,18,0,0)
                    }
                };
            await App.Repository.Create(newOpenHours);
        } 
    }
}