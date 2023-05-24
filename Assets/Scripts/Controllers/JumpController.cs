using System.Collections.Generic;
using Zenject;

namespace Controllers
{
    public class JumpController : ITickable
    {
        private readonly List<IJumpable> _jumpables;


        public JumpController(List<IJumpable> jumpables)
        {
            _jumpables = jumpables;
        }

        public void Tick()
        {
            foreach (var jumpable in _jumpables)
            {
                if(jumpable.CanJump())
                    jumpable.Jump();
            }
        }
    }
}