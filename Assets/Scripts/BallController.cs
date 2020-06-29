using System;
using UnityEngine;

namespace Alphamplyer.Pong
{
    [RequireComponent(typeof(MoveVelocity))]
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float maxBounceAngleInDegrees;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var paddle = other.gameObject;
                var paddleSize = paddle.GetComponent<SpriteRenderer>().bounds.size;
                var paddlePosition = paddle.GetComponent<Transform>().position;

                Debug.Log(Mathf.Abs(_transform.position.x) - (paddleSize.x / 2 + Mathf.Abs(paddlePosition.x)));
                
                // If the ball is behind paddle, inverse only y axis
                if (Mathf.Abs(_transform.position.x) - (paddleSize.x / 2 + Mathf.Abs(paddlePosition.x)) > -0.001f)
                {
                    _moveVelocity.InverseVelocity(false, true);
                    return;
                }
                
                // Else, make ball bounce on paddle
                
                var relativeIntersectionY = paddlePosition.y - _transform.position.y;
                var normalizedRelativeIntersection = relativeIntersectionY / (paddleSize.y / 2);
                var bounceAngle = normalizedRelativeIntersection * (maxBounceAngleInDegrees * Mathf.Deg2Rad);

                var velocity = _moveVelocity.Velocity;
                var xDir = velocity.x > 0 ? -1 : 1;
                _moveVelocity.Velocity = new Vector3(Mathf.Cos(bounceAngle) * xDir, Mathf.Sin(bounceAngle), velocity.z).normalized;
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
            else
            {
                _playerOneServeLastTime = true;
            }

            Vector2 startDirection = RandomUtils.GetRandomRightDirection(-60, 60) * xDir;
            
            _moveVelocity.Velocity = startDirection;
        }
    }
}
