namespace P04.Recharge
{
    public abstract class Worker
    {
        private int workingHours;

        public Worker(string id)
        {
            this.Id = id;
        }

        public int WorkingHours => this.workingHours;

        public string Id { get; private set; }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}