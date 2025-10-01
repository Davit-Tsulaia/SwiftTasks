using System;
using System.Threading;
using System.Threading.Tasks;

var semaphoreSlim = new SemaphoreSlim(1, 1);
var isPaused = false;

var printTask = Task.Run(async () => await Print0And1());
var messageTask = Task.Run(async () => await ShowMessage());

await Task.WhenAll(printTask, messageTask);

async Task Print0And1()
{
    var random = new Random();
    
    while (true)
    {
        await semaphoreSlim.WaitAsync();
        try
        {
            if (!isPaused)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(random.Next(2));
                Console.ResetColor();
            }
        }
        finally
        {
            semaphoreSlim.Release();
        }

        await Task.Delay(50);
    }
}

async Task ShowMessage()
{
    while (true)
    {
        await Task.Delay(5000);

        await semaphoreSlim.WaitAsync();
        try
        {
            isPaused = true;
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Neo, you are the chosen one");
            Console.ResetColor();
        }
        finally
        {
            semaphoreSlim.Release();
        }

        await Task.Delay(5000);
        
        await semaphoreSlim.WaitAsync();
        try
        {
            isPaused = false;
        }
        finally
        {
            semaphoreSlim.Release();
        }
    }
}