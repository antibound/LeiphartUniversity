using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeiphartUniversity.Tests
{
    [TestFixture]
    class UtilitiesTests
    {
     [TestCase]
     public void Generate_Random_Number_Test()
        {
            Utilities utility = new Utilities();
            Mock<Random> random = new Mock<Random>();

            random.Setup(m => m.Next()).Returns(1);
            random.Setup(m => m.Next()).Returns(2);
            random.Setup(m => m.Next()).Returns(3);
            random.Setup(m => m.Next()).Returns(4);
            random.Setup(m => m.Next()).Returns(5);
            random.Setup(m => m.Next()).Returns(6);
            random.Setup(m => m.Next()).Returns(7);
            random.Setup(m => m.Next()).Returns(8);
            random.Setup(m => m.Next()).Returns(9);
            random.Setup(m => m.Next()).Returns(4);

            Assert.AreEqual(1234567894, utility.GenerateUniversityId);
        }   
    }
}
