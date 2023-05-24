namespace Services.Input
{
    public interface IInputService
    {
        public bool IsJumpButtonClicked { get; }
        public float MoveDirectionPressed { get; }
    }
}