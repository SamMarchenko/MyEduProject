namespace Services.Input
{
    public interface IUnitControlInputListener : IInputListener
    {
        bool IsJumpButtonClicked { get; set; }
        float MoveDirection { get; set; }
    }
}