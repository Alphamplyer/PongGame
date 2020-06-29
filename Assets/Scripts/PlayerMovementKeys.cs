using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Alphamplyer.Pong
{
    [RequireComponent(typeof(MoveVelocity))]
    public class PlayerMovementKeys : MonoBehaviour
    {
        [SerializeField] private KeyCode upKey;
        [SerializeField] private KeyCode downKey;
        private MoveVelocity _moveVelocity;

        private void Awake()
        {
            _moveVelocity = GetComponent<MoveVelocity>();
        }

        // Update is called once per frame
        void Update()
        {
            int y = 0;
            
            if (Input.GetKey(upKey)) 
                y = 1;
            if (Input.GetKey(downKey)) 
                y = -1;
            
            _moveVelocity.Velocity = Vector3.up * y; 
        }
    }
}
