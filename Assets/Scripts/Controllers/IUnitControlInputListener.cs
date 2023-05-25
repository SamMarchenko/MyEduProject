namespace Controllers
{
    public interface IUnitControlInputListener : IInputListener
    {
        bool IsJumpButtonClicked { get; set; }
        float MoveDirection { get; set; }
    }
}