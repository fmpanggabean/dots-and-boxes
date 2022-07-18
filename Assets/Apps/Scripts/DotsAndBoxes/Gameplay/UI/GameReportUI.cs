using UnityEngine;
using TMPro;

namespace DotsAndBoxes.Gameplay {
    public class GameReportUI : MonoBehaviour {
        public TMP_Text reportMessageText;
        public TMP_Text scoreText;

        public void ShowMessage(PlayerLabel winner, int score) {            
            reportMessageText.text = winner + " Win!";
            scoreText.text = score.ToString();
        }
    }
}