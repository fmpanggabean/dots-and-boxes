using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace DotsAndBoxes.Gameplay.UI
{
    public class ScoreUI : BaseUI, IScoreManager {
        public TMP_Text player1Score;
        public TMP_Text player2Score;

        public ScoreManager ScoreManager => FindObjectOfType<ScoreManager>();

        private void Start() {
            ScoreManager.OnPlayer1ScoreAdded += ShowPlayer1Score;
            ScoreManager.OnPlayer2ScoreAdded += ShowPlayer2Score;
        }

        internal void ShowPlayer1Score(int score) {
            player1Score.text = score.ToString();
        }

        internal void ShowPlayer2Score(int score) {
            player2Score.text = score.ToString();
        }
    }
}
