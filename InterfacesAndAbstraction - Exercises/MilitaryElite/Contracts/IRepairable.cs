namespace MilitaryElite.Contracts
{
    public interface IRepairable
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
