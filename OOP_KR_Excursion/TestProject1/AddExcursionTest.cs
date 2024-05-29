using Microsoft.VisualStudio.TestPlatform.TestHost;
using OOP_KR;

[TestClass]
public class AdminAddExcursionTests
{
    [TestMethod]
    public void AddExcursion_ShouldOutputConfirmationMessage()
    {
        // Arrange
        var admin = new Admin(1, "admin", "password");
        var excursion = new Excursion(4, "New Tour", "New tour description");

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            admin.AddExcursion(excursion);

            // Assert
            var expectedOutput = $"Excursion {excursion.Name} added.{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, sw.ToString());
        }
    }
}
