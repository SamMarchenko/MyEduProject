using UnityEngine;

namespace Services.Input
{
    public class KeyBoardInputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        
        public bool IsPauseButtonClicked => UnityEngine.Input.GetKeyDown(KeyCode.Escape);
        public bool IsSitDownButtonPressed => UnityEngine.Input.GetKey(KeyCode.S);
        public bool IsJumpButtonClicked => UnityEngine.Input.GetKeyDown(KeyCode.Space);
        public bool IsAttackButtonClicked => UnityEngine.Input.GetKeyDown(KeyCode.F);
        public float MoveDirectionPressed => UnityEngine.Input.GetAxis(Horizontal);
    }
}