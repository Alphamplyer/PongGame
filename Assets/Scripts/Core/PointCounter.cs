using System;
using TMPro;
using UnityEngine;

namespace Alphamplyer.Pong.Core
{
    public class PointCounter : MonoBehaviour
    {
        public static int PlayerOnePoints { get; private set; }
        public static int PlayerTwoPoints { get; private set; }
        
        [SerializeField] private TMP_Text playerOnePointsText;
        [SerializeField] private TMP_Text playerTwoPointsText;

        private void Start()
        {
            UpdateUI();
        }

        /// <summary>
        /// Add the given amount of points to the player and update UI
        /// </summary>
        /// <param name="amount">given points</param>
        /// <param name="forPlayerOne">if true, give points to player 1, else to player 2</param>
        public void AddPoint(int amount, bool forPlayerOne)
        {
            if (forPlayerOne)
                PlayerOnePoints += amount;
            else
                PlayerTwoPoints += amount;
            
            UpdateUI();
        }
        
        // ReSharper disable once InconsistentNaming
        private void UpdateUI()
        {
            playerOnePointsText.text = PlayerOnePoints.ToString();
            playerTwoPointsText.text = PlayerTwoPoints.ToString();
        }
    }
}