
using UnityEngine;

namespace Scripts.Services.Input
{
    public interface IInputService
    {
        Vector2 Axes { get; }
        bool IsAttackButtonUp();
    }
}
