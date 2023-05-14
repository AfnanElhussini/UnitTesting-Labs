using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppTests
{
    [TestClass]
    public class AssemblyHandler
    {
        public static object Dependency { get; set; }
        [AssemblyInitialize] 
        public static void AssemblyInitialize(TestContext context) 
        {
            context.WriteLine("Assembly init");
            Dependency = new object();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup() 
        {
            
        }
    }
}
