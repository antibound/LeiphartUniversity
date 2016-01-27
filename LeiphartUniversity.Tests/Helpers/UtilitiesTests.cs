using LeiphartUniversity.Helpers;
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

            random.SetupSequence(m => m.Next(0, 9)).Returns(1).Returns(2).Returns(3).Returns(4).Returns(5).Returns(6).Returns(7).Returns(8).Returns(9).Returns(4);

            Assert.AreEqual(1234567894, utility.GenerateUniversityId(random.Object));
        }

        [TestCase]
        public void Validate_Generated_Number_Does_Not_Start_With_Zero_Test()
        {
            Utilities utility = new Utilities();
            Mock<Random> random = new Mock<Random>();

            random.SetupSequence(m => m.Next(0, 9)).Returns(0).Returns(5).Returns(2).Returns(3).Returns(4).Returns(5).Returns(6).Returns(7).Returns(8).Returns(9).Returns(4);

            Assert.AreEqual(5234567894, utility.GenerateUniversityId(random.Object));
        }

        [TestCase]
        public void Validate_Generated_Number_Can_Have_A_Zero_After_First_Digit_Test()
        {
            Utilities utility = new Utilities();
            Mock<Random> random = new Mock<Random>();

            random.SetupSequence(m => m.Next(0, 9)).Returns(5).Returns(2).Returns(0).Returns(4).Returns(5).Returns(6).Returns(7).Returns(8).Returns(9).Returns(4);

            Assert.AreEqual(5204567894, utility.GenerateUniversityId(random.Object));
        }
    }
}
