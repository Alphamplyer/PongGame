using System;
using UnityEngine;

namespace Alphamplyer.Pong
{
    [RequireComponent(typeof(MoveVelocity))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float modifierValue = 0.5f; 
        private Transform _transform;
        private MoveVelocity _moveVelocity;
        private bool _playerOneServeLastTime = true;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _moveVelocity = GetComponent<MoveVelocity>();
        }

        private void Start()
        {
            ResetBall();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var playerMoveVelocity = other.gameObject.GetComponent<MoveVelocity>();
                Vector3? modifier = null;

                if (Math.Abs(playerMoveVelocity.Velocity.y) > 0.1f)
                    modifier = new Vector3(1, modifierValue, 1);
                    
                
                _moveVelocity.InverseVelocity(true, false, modifier);
                
            }

            if (other.gameObject.CompareTag("TerrainBorder"))
            {
                _moveVelocity.InverseVelocity(false, true);
            }
        }

        /// <summary>
        /// Reset position and velocity of the ball, and throw the ball to the opposite side of the last throw.
        /// </summary>
        public void ResetBall()
        {
            _moveVelocity.Velocity = Vector3.zero;
            _transform.position = Vector3.zero;

            var xDir = 1;

            if (_playerOneServeLastTime)
            {
                xDir = -1;
                _playerOneServeLastTime = false;
            }

            Vector2 startDirection = RandomUtils.GetRandomRightDirection(-60, 60) * xDir;
            
            _moveVelocity.Velocity = startDirection;
        }
    }
}
