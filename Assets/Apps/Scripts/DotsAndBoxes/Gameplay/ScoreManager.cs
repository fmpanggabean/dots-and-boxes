using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotsAndBoxes.Gameplay
{
    public class ScoreManager : MonoBehaviour
    {
        public int player1;
        public int player2;

        public event Action<int> OnPlayer1ScoreAdded;
        public event Action<int> OnPlayer2ScoreAdded;

        private void Awake() {
            player1 = 0;
            player2 = 0;
        }
        internal void AddScorePlayer1(int point) {
            player1 += point;
            OnPlayer1ScoreAdded?.Invoke(player1);
        }

        internal void AddScorePlayer2(int point) {
            player2 += point;
            OnPlayer2ScoreAdded?.Invoke(player2);
        }
    }
}
