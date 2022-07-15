using System;
using System.Collections;
using UnityEngine;

namespace DotsAndBoxes.Gameplay {
    public class GameManager : MonoBehaviour {
        public ScoreManager scoreManager;
        public PlayerTurn turn;
        public Board board;

        private bool isPlaying;

        public event Action<PlayerLabel> OnPlayerTurnSet;

        public GameManager () {
            turn = new PlayerTurn();
        }
        private void Start() {
            isPlaying = false;
            board.RegisterNextTurnEvent(turn.NextTurn);
            board.OnBoxFormed += GainScore;
            board.OnFullBoard += GameOver;
            SetPlayerTurn();
        }

        private void GameOver() {
            Debug.Log("Game Over");
            isPlaying = false;
        }

        private void SetPlayerTurn() {
            turn.RandomizePlayerTurn();
            OnPlayerTurnSet?.Invoke(turn.playerTurn);
        }

        internal void StartGame() {
            isPlaying = true;
        }

        public void GainScore(int point) {
            if (turn.playerTurn == PlayerLabel.Player_1) {
                //add score to player 1
                scoreManager.AddScorePlayer1(point);
            } else {
                //add score to player 2
                scoreManager.AddScorePlayer2(point);
            }
        }
    }
}