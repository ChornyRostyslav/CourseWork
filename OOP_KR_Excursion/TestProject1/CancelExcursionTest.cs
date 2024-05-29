using OOP_KR;

[TestClass]
public class RegisteredUserCancelTests
{
    [TestMethod]
    public void CancelExcursion_ShouldCancelBookingSuccessfully()
    {
        // Arrange
        var user = new RegisteredUser(1, "testuser", "password");
        var excursion = new Excursion(1, "City Tour", "Explore the city");
        excursion.Book(1, 2);

        // Act
        user.CancelExcursion(excursion);

        // Assert
        var bookings = excursion.GetBookings();
        Assert.IsFalse(bookings.ContainsKey(1));
    }

    [TestMethod]
    public void CancelExcursion_ShouldNotThrowException_WhenNoBookingExists()
    {
        // Arrange
        var user = new RegisteredUser(1, "testuser", "password");
        var excursion = new Excursion(1, "City Tour", "Explore the city");

        // Act
        user.CancelExcursion(excursion);

        // Assert
        var bookings = excursion.GetBookings();
        Assert.IsFalse(bookings.ContainsKey(1));
    }
}
