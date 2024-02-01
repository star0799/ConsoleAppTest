using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest.Interface;

namespace ConsoleAppTest.Service
{
    public class User:IUser
    {
        public User() 
        {

        }
        public string GetName(int id)
        {
            return ("Dear "+id ).ToString();
        }
    }
}
