using UnityEngine;
using Zenject;

namespace _Project.Logic.Character.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
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