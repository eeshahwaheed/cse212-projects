/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>


public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();  // Queue to hold people

    public int Length => _people.Count;

    /// <summary>
    /// Add a new person to the queue with a name and number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        // Create a person with the given name and turns
        var person = new Person(name, turns);
        _people.Enqueue(person);  // Enqueue them into the queue
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// If they have finite turns, decrement their turns and re-add them to the queue if necessary.
    /// If they have infinite turns (turns <= 0), they will always stay in the queue.
    /// </summary>
    public Person GetNextPerson()
    {
        // If the queue is empty, throw an exception
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Get the person at the front of the queue
        Person person = _people.Dequeue();

        // If the person has finite turns (turns > 0)
        if (person.Turns > 0)
        {
            // Decrement their turns
            person.Turns -= 1;

            // If they still have turns left, add them back to the queue
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        // If the person has infinite turns (turns <= 0), they will stay in the queue indefinitely
        else
        {
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        // Return a string representation of all people in the queue
        return string.Join(", ", _people.Select(p => p.ToString()));
    }
}
