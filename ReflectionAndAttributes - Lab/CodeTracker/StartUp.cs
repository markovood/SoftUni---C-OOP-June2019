namespace CodeTracker
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        [Author("Pesho")]
        [Author("Sasho")]
        [Author("Valio")]
        [Author("Mimi")]
        public static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
