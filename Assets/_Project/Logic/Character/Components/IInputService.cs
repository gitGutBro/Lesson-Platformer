using System;
using UnityEngine;

namespace _Project.Logic.Character.Components
{
    public interface IInputService : IDisposable
    {
        event Action<Vector2> Moved;
        event Action Jumped;
        event Action Attacked;
    }
}