
using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axes { get; }
        bool IsAttackButtonUp();
    }
}
