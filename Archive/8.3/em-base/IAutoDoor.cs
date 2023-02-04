namespace Eco.Em.Interfaces
{
    public interface IAutoDoor
    {
        void SetState(bool State);
        void SetOpen();
        void SetClosed();
        void ToggleOpen();
    }
}
