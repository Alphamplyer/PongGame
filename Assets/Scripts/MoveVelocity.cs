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

        public void InverseVelocity(bool onXAxis, bool onYAxis, Vector3? optionalModifier = null)
        {
            Vector3 modifier = optionalModifier ?? new Vector3(1, 1, 1);
            
            if (onXAxis && onYAxis)
                Velocity = new Vector3(Velocity.x * -1 * modifier.x, Velocity.y * -1 * modifier.y, Velocity.z * modifier.z).normalized;
            else if (onXAxis)
                Velocity = new Vector3(Velocity.x * -1 * modifier.x, Velocity.y * modifier.y, Velocity.z * modifier.z).normalized;
            else if (onYAxis)
                Velocity = new Vector3(Velocity.x * modifier.x, Velocity.y * -1 * modifier.y, Velocity.z * modifier.z).normalized;
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
