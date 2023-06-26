
// the name of each thread (if it is not a pooled one) can be change only once before start
Thread.CurrentThread.Name = "A";
Console.WriteLine($"{Thread.CurrentThread.Name} is running...");

Thread writeBThread = new Thread(WriteB);
writeBThread.Name = "B";

// this will invoke the WriteB method but concurrent to CurrentThread (A)
writeBThread.Start();

for ( int i = 0; i < 1000; i++) Console.Write(Thread.CurrentThread.Name);

// waits A until B finishes
writeBThread.Join();

Console.WriteLine("\nThe process has finished.");
Console.ReadLine();

void WriteB()
{
    for (int i = 0; i < 1100; i++) Console.Write(Thread.CurrentThread.Name);
}

