using UnityEngine;
using Zenject;
using _Project.Logic.Shared.Spawner;

namespace _Project.Logic.Character.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour, ISpawnable
    {
        private Rigidbody2D _rigidbody2D;
        
        [Inject]
        private void Construct()
        {
            
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}