using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.UnitTest.Common
{
    public class Base<T> where T : class
    {
        private readonly List<Action> BeforeEaches;
        public Base()
        {
            BeforeEaches = new List<Action>();
        }

        public void BeforeEach(Action context)
        {
            BeforeEaches.Add(context);
        }

        [OneTimeSetUp]
        public void RunBeforeEaches()
        {
            BeforeEaches.ForEach(context => context());
        }

    }
}
