using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        public static void Main()
        {
            var musicFile = new Music("Some_Artist", "Some_Album", 3, 512);
            var file = new File("someFileName", 5, 128);

            var musicProgress = new StreamProgressInfo(musicFile);
            Console.WriteLine(musicProgress.CalculateCurrentPercent());

            var fileProgress = new StreamProgressInfo(file);
            Console.WriteLine(fileProgress.CalculateCurrentPercent());
        }
    }
}
