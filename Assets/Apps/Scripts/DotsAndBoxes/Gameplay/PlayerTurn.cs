using System;

namespace DotsAndBoxes.Gameplay {
    public enum PlayerLabel {
        Player_1 = 1, Player_2 = 2
    }
    public class PlayerTurn {
        public PlayerLabel playerTurn { get; set; }

        public event Action<PlayerLabel> OnTurnChanged;

        public void RandomizePlayerTurn() {
            int rand = UnityEngine.Random.Range(1, 3);
            if (rand == 1) {
                playerTurn = PlayerLabel.Player_1;
            } else {
                playerTurn = PlayerLabel.Player_2;
            }
            OnTurnChanged?.Invoke(playerTurn);
        }
        public void NextTurn() {
            if (playerTurn == PlayerLabel.Player_1) {
                playerTurn = PlayerLabel.Player_2;
            } else {
                playerTurn = PlayerLabel.Player_1;
            }
            OnTurnChanged?.Invoke(playerTurn);
        }
    }
}