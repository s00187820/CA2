using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public enum ActivityType { Land, Air, Water}

    public class Activity : IComparable
    { 
        
        //prop
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate {get; set;}
        public Decimal Cost { get; set; }
        public ActivityType TypeOfActivity { get; set; }


        //ctr
        public Activity (string name, string description, decimal cost,ActivityType activityType, DateTime activityDate)
        {
            Name = name;
            Description = description;
            ActivityDate = activityDate;
            TypeOfActivity = activityType;
            Cost = cost;

        }

        public Activity()
        {

        }
 

        //mtds
        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }

        public int CompareTo(object obj)
        {
            //get a reference to the other object
            
            Activity otherObject = obj as Activity;

            //compare properties of two things
            //return date to this compare value 
            return this.ActivityDate.CompareTo(otherObject.ActivityDate);
        }


    }
}
