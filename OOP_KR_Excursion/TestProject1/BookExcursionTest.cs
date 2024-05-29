using OOP_KR;

[TestClass]
public class RegisteredUserTests
{
    [TestMethod]
    public void BookExcursion_ShouldBookExcursionSuccessfully()
    {
        // Arrange
        var user = new RegisteredUser(1, "testuser", "password");
        var excursion = new Excursion(1, "City Tour", "Explore the city");

        // Act
        user.BookExcursion(excursion, 2);

        // Assert
        var bookings = excursion.GetBookings();
        Assert.IsTrue(bookings.ContainsKey(1));
        Assert.AreEqual(2, bookings[1]);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidInputException))]
    public void BookExcursion_ShouldThrowException_ForInvalidParticipants()
    {
        // Arrange
        var user = new RegisteredUser(1, "testuser", "password");
        var excursion = new Excursion(1, "City Tour", "Explore the city");

        // Act
        user.BookExcursion(excursion, -1);

        // Assert
        // Exception is expected
    }
}
