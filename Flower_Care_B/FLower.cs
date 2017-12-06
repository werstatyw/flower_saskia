using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flower_Care_B
{
    enum sunlight_tol { light_loving, neutral, shade_loving};
    class Flower
    {
        string type;
        sunlight_tol tol;
        int waterNeed;
        int monthLastWatering;
        int dayLastWatering;
        bool stinging;

        public String Type
        {
            get { return type; }
            set { type = value;  }
        }
        public sunlight_tol Tol
        {
            get { return tol; }
            set { tol = value; }
        }
        public int WaterNeed
        {
            get { return waterNeed; }
            set { waterNeed = value; }
        }
        public int MonthLastWatering
        {
            get { return monthLastWatering; }
            set { monthLastWatering = value; }
        }
        public int DayLastWatering
        {
            get { return dayLastWatering; }
            set { dayLastWatering = value; }
        }
        public bool Stinging
        {
            get { return stinging; }
            set { stinging = value; }
        }

        public Flower(string type, int tolerance, int waterNeed, int monthLastWatering, int dayLastWatering , string sting)
        {
            this.type = type;
            tol = (sunlight_tol)tolerance;
            this.waterNeed = waterNeed;
            this.monthLastWatering = monthLastWatering;
            this.dayLastWatering = dayLastWatering;
            if (sting == "1")
                stinging = true;
            else
                stinging = false;
        }

        public string print()
        {
            return "Flower [type=" + type + ", sunlight_tol=" + tol + ", waterNeed=" + waterNeed + ", monthLastWatering=" + monthLastWatering + ", dayLastWatering=" + dayLastWatering + ", stinging=" + stinging + "]";
        }
    }
}
