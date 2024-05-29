namespace OOP_KR
{
    public interface IAdmin : IUser
    {
        void AddExcursion(IExcursion excursion);
        void RemoveExcursion(int excursionId);
        void ViewBookings(List<IExcursion> excursions);
    }
}