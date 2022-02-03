using UnityEngine;

namespace Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string AttackButton = "Fire";

        public abstract Vector2 Axes { get; }

        public bool IsAttackButtonUp() =>
            SimpleInput.GetButtonUp(AttackButton);
        
        protected Vector2 GetSimpleInputAxes() => 
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}
