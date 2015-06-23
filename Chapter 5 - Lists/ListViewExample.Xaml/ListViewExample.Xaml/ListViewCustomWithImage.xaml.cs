﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace ListViewExample.Xaml
{
    public partial class ListViewCustomWithImage : ContentPage
    {
        public ListViewCustomWithImage()
        {
            InitializeComponent();

            BindingContext = new ListViewCustomViewWithImageModel(DisplayAlert);
        }
    }


    public class ListViewCustomViewWithImageModel : BindableObject
    {

        readonly Func<string, string, string, Task> displayAlertAction;

        List<ListItem> listItems;
        public List<ListItem> ListItems
        {
            get
            {
                return listItems;
            }
            set
            {
                listItems = value;
                OnPropertyChanged("ListItems");
            }
        }

        ListItem selectedListItem;
        public ListItem SelectedListItem
        {
            get
            {
                return selectedListItem;
            }
            set
            {
                selectedListItem = value;
                OnPropertyChanged("SelectedListItem");
                if(selectedListItem != null)
                    displayAlertAction?.Invoke("Tapped", $"{selectedListItem.Title} was selected.", "OK");
            }
        }

        public ListViewCustomViewWithImageModel(Func<string, string, string, Task> displayAlertAction)
        {
            this.displayAlertAction = displayAlertAction;

            ListItems = new List<ListItem> { 
                new ListItem {Source = "first.png", Title = "First", Description="1st item", Price="$100.00"}, 
                new ListItem {Source = "second.png", Title = "Second", Description="2nd item", Price="$200.00"},
                new ListItem {Source = "third.png", Title = "Third", Description="3rd item", Price="$300.00"}
            };
        }

        public class ListItem : BindableObject
        {
            public string Source { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
        }
    }
}

