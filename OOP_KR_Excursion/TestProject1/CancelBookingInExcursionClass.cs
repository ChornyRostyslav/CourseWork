using OOP_KR;

[TestClass]
public class ExcursionCancelBookingTests
{
    [TestMethod]
    public void CancelBooking_ShouldRemoveBooking()
    {
        // Arrange
        var excursion = new Excursion(1, "City Tour", "Explore the city");
        excursion.Book(1, 2);

        // Act
        excursion.CancelBooking(1);

        // Assert
        var bookings = excursion.GetBookings();
        Assert.IsFalse(bookings.ContainsKey(1));
    }

    [TestMethod]
    public void CancelBooking_ShouldNotThrowException_WhenNoBookingExists()
    {
        // Arrange
        var excursion = new Excursion(1, "City Tour", "Explore the city");

        // Act
        excursion.CancelBooking(1);

        // Assert
        var bookings = excursion.GetBookings();
        Assert.IsFalse(bookings.ContainsKey(1));
    }
}
