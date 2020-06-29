using System;
using UnityEngine;

namespace Alphamplyer.Pong.Core
{
    public class PointHandler : MonoBehaviour
    {
        [SerializeField] private PointCounter pointCounter;
        [SerializeField] private bool pointsForPlayerOneSide = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Ball"))
                return;
            
            pointCounter.AddPoint(1, pointsForPlayerOneSide);
            
            other.gameObject.GetComponent<BallController>().ResetBall();
        }
    }
}