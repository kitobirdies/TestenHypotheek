namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test_GetInkomen()
        {
            // Arrange
            var input = "2000";
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var result = TestHypotheek.HypotheekHelper.GetInkomen();

            // Assert
            Assert.AreEqual(2000, result);
        }

        [TestMethod]
        public void Test_GetRentevastePeriode()
        {
            // Arrange
            var input = "30";
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var result = TestHypotheek.HypotheekHelper.GetRentevastePeriode();

            // Assert
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void Test_GetRentePercentage()
        {
            // Arrange
            int rentePeriode = 30;

            // Act
            var result = TestHypotheek.HypotheekHelper.GetRentePercentage(rentePeriode);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Test_GetPartnerInkomen()
        {
            // Arrange
            var input = "ja\n2000"; // Example input
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var result = TestHypotheek.HypotheekHelper.GetPartnerInkomen();

            // Assert
            Assert.AreEqual(2000, result);
        }


        [TestMethod]
        public void Test_GetStudieschuldStatus()
        {
            // Arrange
            var input = "ja";
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var result = TestHypotheek.HypotheekHelper.GetStudieschuldStatus();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_GetGeldigePostcodeStatus()
        {
            // Arrange
            var input = "1234";
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var result = TestHypotheek.HypotheekHelper.GetGeldigePostcodeStatus();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_GetGeldigePostcodeStatus_IsFalse()
        {
            // Arrange
            var input = "9679";
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var result = TestHypotheek.HypotheekHelper.GetGeldigePostcodeStatus();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_GetMaxHypotheeklast()
        {
            // Arrange
            double inkomen = 2500.0;
            double partnerInkomen = 2500.0;
            bool studieschuldStatus = false;

            // Act
            var result = TestHypotheek.HypotheekHelper.GetMaxHypotheeklast(inkomen, partnerInkomen, studieschuldStatus);

            // Assert
            Assert.AreEqual(255000, result);
        }

        [TestMethod]
        public void Test_GetMaxHypotheeklast_MetSchuld()
        {
            // Arrange
            double inkomen = 2500.0;
            double partnerInkomen = 2500.0;
            bool studieschuldStatus = true;

            // Act
            var result = TestHypotheek.HypotheekHelper.GetMaxHypotheeklast(inkomen, partnerInkomen, studieschuldStatus);

            // Assert
            Assert.AreEqual(191250, result);
        }

        [TestMethod]
        public void Test_GetLeningBedrag()
        {
            // Arrange
            double maxHypotheeklast = 255000.0;
            var input = "255000";
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var result = TestHypotheek.HypotheekHelper.GetLeningBedrag(maxHypotheeklast);

            // Assert
            Assert.AreEqual(255000, result);
        }
    }
}



