using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euclid;
using NUnit.Framework.Constraints;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

namespace Euclid.UnitTests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void TestPass()
        {
            var p = new Point(1, 2);

            Assert.That(p.X, Is.EqualTo(1));
        }
    }
}


