using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Alphamplyer.Pong
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveVelocity : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        public Vector3 Velocity { get; set; }
        [SerializeField] private float moveSpeed;

        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }
        
        public void InverseVelocity(bool onXAxis, bool onYAxis)
        {
            if (onXAxis && onYAxis)
                Velocity = new Vector3(Velocity.x * -1, Velocity.y * -1, Velocity.z).normalized;
            else if (onXAxis)
                Velocity = new Vector3(Velocity.x * -1, Velocity.y, Velocity.z).normalized;
            else if (onYAxis)
                Velocity = new Vector3(Velocity.x, Velocity.y * -1, Velocity.z).normalized;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            Velocity = Vector3.zero;
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = Velocity * moveSpeed;
        }
    }
}
