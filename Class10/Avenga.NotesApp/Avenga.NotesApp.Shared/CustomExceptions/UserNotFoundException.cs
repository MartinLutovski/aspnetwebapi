namespace Avenga.NotesApp.Shared.CustomExceptions
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}
