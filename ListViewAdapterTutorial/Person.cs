using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListViewAdapterTutorial
{
    public class Person: Java.Lang.Object
    {
        public int Id{get;set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public override string ToString(){
            return $"{Name} {Surname} has age {Age}";
        }
    }
}