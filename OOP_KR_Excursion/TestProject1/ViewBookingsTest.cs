using OOP_KR;

[TestClass]
public class AdminViewBookingsTests
{
    [TestMethod]
    public void ViewBookings_ShouldDisplayBookings()
    {
        // Arrange
        var admin = new Admin(1, "admin", "password");
        var excursion = new Excursion(1, "City Tour", "Explore the city");
        excursion.Book(1, 2);
        var excursions = new List<IExcursion> { excursion };

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            admin.ViewBookings(excursions);

            // Assert
            var expectedOutput = $"Bookings for City Tour:{Environment.NewLine}User 1 booked 2 participants.{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, sw.ToString());
        }
    }

    [TestMethod]
    public void ViewBookings_ShouldHandleNoBookings()
    {
        // Arrange
        var admin = new Admin(1, "admin", "password");
        var excursion = new Excursion(1, "City Tour", "Explore the city");
        var excursions = new List<IExcursion> { excursion };

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            admin.ViewBookings(excursions);

            // Assert
            var expectedOutput = $"Bookings for City Tour:{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, sw.ToString());
        }
    }
}
