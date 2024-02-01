using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    public class Test
    {
        /// <summary>
        /// 亂數產生器
        /// </summary>
        public static Random _rand { set; get; } = new Random((int)DateTime.Now.Ticks);

    }
}
