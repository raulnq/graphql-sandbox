namespace api;

public class NotFoundException : Exception
{
    public NotFoundException(Guid id) : base($"The with {id} was not found")
    {
    }
}