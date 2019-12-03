using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Activity> activities = new List<Activity>();
        List<Activity> selected_activities = new List<Activity>();
        List<Activity> filtered_activities = new List<Activity>();

        decimal totalCost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
      
       //This method will run when the window loads
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create Activity items
            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };

            Activity a4 = new Activity("Helicopter Tour", "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters", 200m, ActivityType.Air, DateTime.Now);

            // Add to a list          
            activities.Add(a1);
            activities.Add(a2);
            activities.Add(a3);
            activities.Add(w1);
            activities.Add(w2);
            activities.Add(w3);
            activities.Add(l1);
            activities.Add(l2);
            activities.Add(l3);

            activities.Sort();

            //Display in List Boxs
            lbxActivities.ItemsSource = activities;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        //MOves activity from all list to selected list
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            //determine what has been selected
            Activity selected = lbxActivities.SelectedItem as Activity;
            //check that something has been selected
            if (selected != null)
            {
                //remove from list 1
                activities.Remove(selected);

                //add to list 2
                selected_activities.Add(selected);

                //update total cost
                tblkTotal.Text = Convert.ToString(totalCost);

                //refresh display
                RefreshScreen();
            }

        }

        private void BtnReturnActivites_Click(object sender, RoutedEventArgs e)
        {
            Activity selected = lbxSelectedActivities.SelectedItem as Activity;

            //check that something has been selected
            if (selected != null)
            {
                //remove from list 1
                selected_activities.Remove(selected);

                //add to list 2
                activities.Add(selected);

                //update total cost
                tblkTotal.Text = Convert.ToString(totalCost);
               
                //refresh display
                RefreshScreen();

            }
        }

        //handles all radio butoon clicks
        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            filtered_activities.Clear();

            if (RbAll.IsChecked == true)
            {
                RefreshScreen();
            }
            else if (RbLand.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Land)
                    {
                        filtered_activities.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filtered_activities;

                    }
                }
            }
            else if (RbWater.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filtered_activities.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filtered_activities;

                    }
                }
            }
            else if (RbAir.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filtered_activities.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filtered_activities;

                    }
                }
            }

        }

        private void RefreshScreen()
        {
            lbxActivities.ItemsSource = null;
            lbxActivities.ItemsSource = activities;

            lbxSelectedActivities.ItemsSource = null;
            lbxSelectedActivities.ItemsSource = selected_activities;
        }

        private void LbxActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("you selected something");

            //determine what was selected
            Activity selected = lbxActivities.SelectedItem as Activity;

            //check not null
            if (selected != null)
            {
                //update description
                lblDesc.Content = selected.Description;

            }

        }
    }
}
