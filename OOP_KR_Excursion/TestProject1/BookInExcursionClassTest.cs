using OOP_KR;

[TestClass]
public class ExcursionBookTests
{
    [TestMethod]
    public void Book_ShouldAddBooking()
    {
        // Arrange
        var excursion = new Excursion(1, "City Tour", "Explore the city");

        // Act
        excursion.Book(1, 2);

        // Assert
        var bookings = excursion.GetBookings();
        Assert.IsTrue(bookings.ContainsKey(1));
        Assert.AreEqual(2, bookings[1]);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidInputException))]
    public void Book_ShouldThrowException_ForInvalidParticipants()
    {
        // Arrange
        var excursion = new Excursion(1, "City Tour", "Explore the city");

        // Act
        excursion.Book(1, -1);

        // Assert
        // Exception is expected
    }
}
