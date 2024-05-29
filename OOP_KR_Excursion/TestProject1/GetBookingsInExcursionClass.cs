using OOP_KR;

[TestClass]
public class ExcursionGetBookingsTests
{
    [TestMethod]
    public void GetBookings_ShouldReturnAllBookings()
    {
        // Arrange
        var excursion = new Excursion(1, "City Tour", "Explore the city");
        excursion.Book(1, 2);
        excursion.Book(2, 3);

        // Act
        var bookings = excursion.GetBookings();

        // Assert
        Assert.AreEqual(2, bookings.Count);
        Assert.AreEqual(2, bookings[1]);
        Assert.AreEqual(3, bookings[2]);
    }

    [TestMethod]
    public void GetBookings_ShouldReturnEmptyDictionary_WhenNoBookings()
    {
        // Arrange
        var excursion = new Excursion(1, "City Tour", "Explore the city");

        // Act
        var bookings = excursion.GetBookings();

        // Assert
        Assert.AreEqual(0, bookings.Count);
    }
}
