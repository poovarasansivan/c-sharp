# Task - Working with Events and Delegates

- Build a console-based event-driven application that is a counter that triggers an event after reaching a minimum threshold and sends a alert.

## Delegates

- A delegate in C# is a type-safe function pointer that holds references to methods with a specific signature and return type.
- Delegates enable methods to be passed as parameters or assigned to variables.

## Syntax of a Delegate

```
public delegate void Notify(string message);
```

- `public` : Access modifier.
- `delegate` : Keyword to define a delegate.
- `void` : Return type.
- `Notify` : Delegate name.
- `string message` : Parameter list.

## Uses of Delegates

- `Flexibility` : Methods can be dynamically assigned and invoked.
- `Callback Mechanism` : Supports callback methods.
- `Event Handling` : Essential for event-driven programming.
- `Multicasting` : Can point to multiple methods at once.

## Events

- An event in C# is a way for a class to notify other classes or objects when something of interest occurs.
- It is built on delegates and provides a mechanism for publish-subscribe behavior.

## Syntax of an Event

```
public event Notify ProcessCompleted;
```

- `public` : Access modifier.
- `event` : Keyword to define an event.
- `Notify` : Delegate type.
- `ProcessCompleted` : Event name.

## How Events and Delegates Work Together

- `Declare a Delegate` : Acts as a blueprint for event handler methods.
- `Declare an Event` : Uses the delegate to define a specific event.
- `Subscribe to the Event` : Attach a method to the event.
- `Raise the Event` : Trigger the event to invoke the subscribed methods.

## Multicast Delegate

- A delegate that holds references to multiple methods.
- When invoked, it calls all the methods in its invocation list.

## Task Code Snippets

- Uses a delegate and event to trigger an action when a counter reaches a threshold.
- Demonstrates how multiple event handler methods respond to the event.
- Shows the decoupling between producer (counter) and consumer (event handlers).

1. Delegate Definition

- Define a delegate
- Represents methods that take an int as a parameter.

```
public delegate void ThresholdReachedEventHandler(int threshold);
```

2. Event Declaration

```

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
```

- Define an event using the delegate
- Raise the event if the threshold is reached
- `OnThresholdReached` Method to raise the event
- Uses the delegate to define the `ThresholdReached` event in the `Counter` class.
- The event is raised when the counter reaches the defined threshold.
- Uses the `OnThresholdReached()` method to trigger the event.

4. Multiple Event Handlers

```
public class AlertHandler
    {
        public void ShowAlert(int threshold)
        {
            Console.WriteLine($"[ALERT] Counter has reached the threshold of {threshold}!");
        }
    }
```

- `AlertHandler` : Displays an alert when the threshold is reached.

```
public class LogHandler
    {
        public void LogThreshold(int threshold)
        {
            Console.WriteLine($"[LOG] Threshold of {threshold} reached. Logging the event.");
        }
    }
```

- `LogHandler` : Logs a message when the threshold is reached.

5. Counter initialization and handler objects

```
Counter counter = new Counter(threshold);
```

- Instantiate the counter

```
AlertHandler alertHandler = new AlertHandler();
LogHandler logHandler = new LogHandler();
```

- Create event handler objects

```
counter.ThresholdReached += alertHandler.ShowAlert;
counter.ThresholdReached += logHandler.LogThreshold;
```

- Subscribe event handlers to the event

```
Thread.Sleep(1000);
```

- To Delay the console output to visualize output



## Task Exection Output

![event-delegates](./assets/delegates.gif)