using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Flower_Care_B
{
    class FlowerCare
    {
        string fileName;
        int monthOfToday;
        int dayOfToday;
        int numberFlowers;
        Flower[] f;

       /*public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public int MonthOfToday
        {
            get { return monthOfToday; }
            set { monthOfToday = value; }
        }
        public int DayOfToday
        {
            get { return dayOfToday; }
            set { dayOfToday = value; }
        }
        public int NumberFlowers
        {
            get { return numberFlowers; }
            set { numberFlowers = value; }
        }
        public Flower[] F
        {
            get { return f; }
            set { f = value; }
        }
        */
        public FlowerCare(string fileName, int monthOfToday, int dayOfToday)
        {
            f = null;
            numberFlowers = 0;
            this.fileName = fileName;
            this.monthOfToday = monthOfToday;
            this.dayOfToday = dayOfToday;
            if (File.Exists(fileName)){
                readData(fileName);
            }
        }
        void readData(string fileName)
        {
            //get size of array
            int size = countLines(fileName);
            numberFlowers = size;
            //Console.WriteLine("size of array: "+size);
            //create array
            f = new Flower[size];
            //fill array
            fillArray(fileName);
        }
        void fillArray(string fn)
        {
            StreamReader sr = new StreamReader(fn);
            int index = 0;
            while (!sr.EndOfStream && index < f.Length)
            {
                //string type, int tolerance, int waterNeed, int monthLastWatering, int dayLastWatering , string sting
                string s = sr.ReadLine();
                //Console.WriteLine("fillAray, whole line: " + s);
                int i = s.IndexOf(",");
                string type = s.Substring(0, i);
                //Console.WriteLine("type: "+type);
                s = s.Substring(i + 1);
                //Console.WriteLine("substring: "+s);

                i = s.IndexOf(",");
                string tol = s.Substring(0, i);
                //Console.WriteLine("tolerance: "+tol);
                s = s.Substring(i + 1);
                //Console.WriteLine("substring 2: "+s);
                i = s.IndexOf(",");
                string waterNeed = s.Substring(0, i);
                s = s.Substring(i + 1);

                i = s.IndexOf(",");
                string monthLastWatering = s.Substring(0, i);
                s = s.Substring(i + 1);

                i = s.IndexOf(",");
                string dayLastWatering = s.Substring(0, i);

                string stinging = s.Substring(i + 1);

                f[index] = new Flower(type, int.Parse(tol), int.Parse(waterNeed), int.Parse(monthLastWatering), int.Parse(dayLastWatering), stinging);
                index++;
            }
            sr.Close();
        }
        int countLines(string fn)
        {
            StreamReader sr = new StreamReader(fn);
            int x = 0;
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                x++;
            }
            sr.Close();
            return x;
        }
        public void addNewFlower()
        {
            Console.Write("Enter the values for the new flower.\nType= ");
            string type = Console.ReadLine();
            Console.Write("Sunlight tolerance (0 = sun_loving, 1 = neutral, 2 = shade_loving)= ");
            int tol = int.Parse(Console.ReadLine());
            Console.Write("Water need= ");
            int waterNeed = int.Parse(Console.ReadLine());
            Console.Write("Month of last watering= ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Day of last watering= ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Stinging (0 = false, 1 = true)= ");
            string stinging = Console.ReadLine();
            Flower fl = new Flower(type, tol, waterNeed, month, day, stinging);

            int size = f.Length;
            size++;
            Array.Resize(ref f, size); //bigger size: adds one line at the end
            //smaller size, copies everything till it is full
            f[size-1] = fl;
        }
        public void safeToFile()
        {
            //lily,2,5,4,22,0
            StreamWriter sw = new StreamWriter(fileName);
            string s = "";
            string c = ",";
            for (int i = 0; i < f.Length; i++)
            {
                s += f[i].Type+c+(int)f[i].Tol+c+f[i].WaterNeed+c+f[i].MonthLastWatering+c+f[i].DayLastWatering+c+stingingAsNumber(f[i].Stinging);
                if(i < f.Length - 1)
                {
                    sw.WriteLine(s);
                    s = "";
                }
                sw.Write(s);
            }
            sw.Close();
        }
        string stingingAsNumber(bool sting)
        {
            if (sting)
                return "1";
            else
                return "0";
        }
        public void removeFlower()
        {
            //show available flowers
            Console.Write("Which flower do you want to remove? "+ flowerOptions());
            int choice = int.Parse(Console.ReadLine());
            //remove it from array
            f[choice] = null;
            //shift entries
            for (int i = choice; i < f.Length-1; i++)
            {
                f[i] = f[i + 1];
            }
            //resize array
            Array.Resize(ref f, f.Length - 1);
        }
        string flowerOptions()
        {
            string s = "(";
            for (int i = 0; i < f.Length; i++)
            {
                s += i + ":" + f[i].Type;
                if (i < f.Length - 1)
                    s += ", ";
                else if (i == f.Length - 1)
                    s += "): ";
            }
            return s;
        }
        public void editFlower()
        {
            Console.Write("Which flower do you want to edit? "+ flowerOptions());
            int choice = int.Parse(Console.ReadLine());
            Flower change = f[choice]; //new name to access easier
            Console.WriteLine(change.print());
            Console.Write("Are you sure you want to edit this flower? (y/n) ");
            string answer = Console.ReadLine();
            answer = answer.Trim();
            answer = answer.ToLower();
            if(answer == "y")
            {
                Console.WriteLine("Please enter the new data");
                Console.Write("Type= ");
                change.Type = Console.ReadLine();
                Console.Write("Sunlight tolerance (0 = sun_loving, 1 = neutral, 2 = shade_loving)= ");
                change.Tol = (sunlight_tol)int.Parse(Console.ReadLine());
                Console.Write("Water need= ");
                change.WaterNeed = int.Parse(Console.ReadLine());
                Console.Write("Month of last watering= ");
                change.MonthLastWatering = int.Parse(Console.ReadLine());
                Console.Write("Day of last watering= ");
                change.DayLastWatering = int.Parse(Console.ReadLine());
                Console.Write("Stinging (0 = false, 1 = true)= ");
                string stinging = Console.ReadLine();
                if (stinging == "1")
                    change.Stinging = true;
                else
                    change.Stinging = false;
            }
        }
        public string print()
        {
            return "FlowerCare [fileName=" + fileName + ", monthOfToday=" + monthOfToday + ", dayOfToday=" + dayOfToday + ", numberFlowers=" + numberFlowers + ", Flowers:\n" + allFlowers() + "]";
        }
        public string allFlowers()
        {
            if(f == null) {
                return "no flowers so far";
            }
            string s = "";
            for (int i = 0; i < f.Length; i++)
            {
                s += f[i].print();
                if (i < f.Length - 1)
                    s += "\n";
            }
            return s;
        }
    }
}
