namespace Controllers
{
    public interface IPatrolling
    {
        void Patrol();
        void TurnAround();
        bool NeedTurnAround();
    }
}