namespace OOP_KR
{
    public interface IUser
    {
        int Id { get; }
        void ViewExcursions(List<IExcursion> excursions);
        void BookExcursion(IExcursion excursion, int participants);
        void CancelExcursion(IExcursion excursion);
    }
}
