using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Core_AppSettings
{
    public class Settings
    {
        public int KeyOne { get; set; }
        public bool KeyTwo { get; set; }
        public string KeyThree { get; set; }
        public Logger   Logger { get; set; }
        public string[] IpAddress { get; set; }

    }
    public class Logger
    {
        public string Path { get; set; }
        public string LogName { get; set; }
    }
}
