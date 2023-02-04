namespace Eco.EM.Framework.AutoDoors
{
    public interface IAutoDoor
    {
        void SetState(bool State);
        void SetOpen();
        void SetClosed();
        void ToggleOpen();
    }
}
