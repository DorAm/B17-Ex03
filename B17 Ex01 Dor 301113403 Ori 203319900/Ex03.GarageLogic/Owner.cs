﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Owner
    {
        private string m_Name;
        private string m_Phone;

        public string Name { get => m_Name; }
        public string Phone { get => m_Phone; }

        public Owner(string i_Name, string i_Phone)
        {
            m_Name = i_Name;
            m_Phone = i_Phone;
        }
    }
}

