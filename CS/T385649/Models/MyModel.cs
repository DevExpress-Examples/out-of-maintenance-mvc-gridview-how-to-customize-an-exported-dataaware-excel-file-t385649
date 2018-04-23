using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T385649.Models {
    public class MyModel {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public static List<MyModel> GetDataSource() {
            List<MyModel> result = new List<MyModel>();
            MyModel test1 = new MyModel();
            test1.ID = 0;
            test1.Name = "Dave";
            test1.Position = "Manager";
            MyModel test2 = new MyModel();
            test2.ID = 1;
            test2.Name = "John";
            test2.Position = "Plumber";
            MyModel test3 = new MyModel();
            test3.ID = 2;
            test3.Name = "Jack";
            test3.Position = "Plumber";
            result.Add(test1);
            result.Add(test2);
            result.Add(test3);
            return result;
        }

        public static List<string> GetPositionDataSource() {
            List<string> temp = new List<string>();
            temp.Add("Manager");
            temp.Add("Plumber");
            return temp;
        }
    }
}