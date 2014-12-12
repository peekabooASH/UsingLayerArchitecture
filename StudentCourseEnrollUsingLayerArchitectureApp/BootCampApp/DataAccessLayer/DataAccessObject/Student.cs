﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampApp.DataAccessLayer.DataAccessObject
{
    class Student
    {
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Student(string a,string b,string c) :this()
        {
            RegNo = a; Name = b; Email = c;
        }
        public Student() 
        { }

    }
}
