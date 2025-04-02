namespace EventAndDelegates
{
    public delegate void ThresholdReachedEventHandler(int threshold);

    public class Counter
    {
        private int count = 0;
        public int Threshold { get; }

        public event ThresholdReachedEventHandler ThresholdReached;
        public Counter(int threshold)
        {
            Threshold = threshold;
        }
        public void Increment()
        {
            count++;
            Console.WriteLine($"Counter: {count}");
            if (count == Threshold)
            {
                OnThresholdReached(Threshold);
            }
        }

        protected virtual void OnThresholdReached(int threshold)
        {
            ThresholdReached?.Invoke(threshold);
        }
    }

     public class AlertHandler
    {
        public void ShowAlert(int threshold)
        {
            Console.WriteLine($"[ALERT] Counter has reached the threshold of {threshold}!");
        }
    }

    public class LoggerHandler
    {
        public void LogThreshold(int threshold)
        {
            Console.WriteLine($"[LOG] Counter reached the threshold of {threshold} at {DateTime.Now}.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int threshold = 5;
            Counter counter = new Counter(threshold);
            AlertHandler alertHandler = new AlertHandler();
            LoggerHandler loggerHandler = new LoggerHandler();

            counter.ThresholdReached += alertHandler.ShowAlert;
            counter.ThresholdReached += loggerHandler.LogThreshold;

            Console.WriteLine("Incrementing counter...");
            for(int i = 0; i < 10; i++)
            {
                counter.Increment();
                Thread.Sleep(1000);
            }
             Console.WriteLine("Counter operation completed.");
        }
    }
}