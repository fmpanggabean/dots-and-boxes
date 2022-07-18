using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DotsAndBoxes.Gameplay.UI
{
    public class UIManager : MonoBehaviour
    {
        public GameManager gameManager;
        private List<BaseUI> uiCollection;

        private void Awake() {
            uiCollection = FindObjectsOfType<BaseUI>().ToList();

            gameManager.OnPlayerTurnSet += GetUI<FirstTurnNoticeUI>().ShowFirstTurn;
            GetUI<FirstTurnNoticeUI>().OnStartGame += gameManager.StartGame;
            gameManager.turn.OnTurnChanged += GetUI<PlayerTurnUI>().Show;
            gameManager.scoreManager.OnPlayer1ScoreAdded += GetUI<ScoreUI>().ShowPlayer1Score;
            gameManager.scoreManager.OnPlayer2ScoreAdded += GetUI<ScoreUI>().ShowPlayer2Score;
            gameManager.OnGameOver += GetUI<GameOverUI>().ShowReport;
            GetUI<GameOverUI>().playAgainButton.onClick.AddListener(gameManager.PlayAgain);
        }

        private T GetUI<T>() where T : BaseUI {
            foreach(BaseUI ui in uiCollection) {
                if (ui.GetType() == typeof(T)) {
                    return (T)ui;
                }
            }
            return null;
        }
    }
}
