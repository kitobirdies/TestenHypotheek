using System.Runtime.ConstrainedExecution;

namespace UnitTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void TestRunMethod()
        {
            // Arrange (Mock user inputs)
            string[] userInput = new string[]
            {
            "2500",  // Inkomen
            "30",    // Rentevaste periode
            "ja",    // Partner
            "2500",  // Partner inkomen
            "nee",    // Studieschuld
            "1234",   // Geldige postcode
            "255000"  // Lening bedrag
            };

            var inputStream = new System.IO.StringReader(string.Join(Environment.NewLine, userInput));
            Console.SetIn(inputStream);

            var outputStream = new StringWriter();
            Console.SetOut(outputStream);

            // Act (Run the application)
            TestHypotheek.Program.Main();

            // Assert (Check the output)
            string expectedOutput = "Totaal maandBedrag: 1770,83\nRente betalen per maand: 1062,5\nAflossing betalen per maand: 708,33\nBetaald na dertig jaar: 637498,8";
            Assert.IsTrue(outputStream.ToString().Contains(expectedOutput));
        }

    }
}
