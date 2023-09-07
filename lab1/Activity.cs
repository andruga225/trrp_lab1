using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Activity
    {

        public enum sport {
            AlpineSki,
            BackcountrySki,
            Canoeing,
            Crossfit,
            EBikeRide,
            Elliptical,
            EMountainBikeRide,
            Golf,
            GravelRide,
            Handcycle,
            Hike,
            IceSkate,
            InlineSkate,
            Kayaking,
            Kitesurf,
            MountainBikeRide,
            NordicSki,
            Ride,
            RockClimbing,
            RollerSki,
            Rowing,
            Run,
            Sail,
            Skateboard,
            Snowboard,
            Snowshoe,
            Soccer,
            StairStepper,
            StandUpPaddling,
            Surfing,
            Swim,
            TrailRun,
            Velomobile,
            VirtualRide,
            VirtualRun,
            Walk,
            WeightTraining,
            Wheelchair,
            Windsurf,
            Workout,
            Yoga

        };

        public long id { get; set; }

        public int elapsed_time { get; set; }

        public sport sport_type { get; set; }

        public string name { get; set; }

        public float average_heartrate { get; set; }

        public DateTime start_date_local { get; set; }

        public float distance { get; set; }

        public Activity(long id, int elapsed_time, sport sport_type, string name, float average_heartrate, DateTime start_date_local, float distance)
        {
            this.id = id;
            this.elapsed_time = elapsed_time;
            this.sport_type = sport_type;
            this.name = name;
            this.average_heartrate = average_heartrate;
            this.start_date_local = start_date_local;
            this.distance = distance;
        }
    }
}
