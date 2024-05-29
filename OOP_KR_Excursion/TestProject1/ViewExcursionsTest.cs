using OOP_KR;

[TestClass]
public class RegisteredUserViewExcursionsTests
{
    [TestMethod]
    public void ViewExcursions_ShouldDisplayAllExcursions()
    {
        // Arrange
        var user = new RegisteredUser(1, "testuser", "password");
        var excursions = new List<IExcursion>
        {
            new Excursion(1, "City Tour", "Explore the city"),
            new Excursion(2, "Museum Tour", "Visit museums")
        };

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            user.ViewExcursions(excursions);

            // Assert
            var expectedOutput = string.Join(Environment.NewLine, excursions.Select(e => e.ToString())) + Environment.NewLine;
            Assert.AreEqual(expectedOutput, sw.ToString());
        }
    }

    [TestMethod]
    public void ViewExcursions_ShouldHandleEmptyList()
    {
        // Arrange
        var user = new RegisteredUser(1, "testuser", "password");
        var excursions = new List<IExcursion>();

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            user.ViewExcursions(excursions);

            // Assert
            Assert.AreEqual(string.Empty, sw.ToString());
        }
    }
}
