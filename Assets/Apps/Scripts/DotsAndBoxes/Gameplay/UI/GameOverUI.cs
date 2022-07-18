using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace DotsAndBoxes.Gameplay
{
    public class GameOverUI : BaseUI, IGameManager {
        public GameReportUI player1Report;
        public GameReportUI player2Report;
        public Button playAgainButton;

        public GameManager GameManager => FindObjectOfType<GameManager>();

        private void Start() {
            GameManager.OnGameOver += ShowReport;
            playAgainButton.onClick.AddListener(GameManager.PlayAgain);
            Hide();
        }
        public void ShowReport(PlayerLabel winner, int scoreP1, int scoreP2) {
            Show();
            player1Report.ShowMessage(winner, scoreP1);
            player2Report.ShowMessage(winner, scoreP2);
        }
    }
}
