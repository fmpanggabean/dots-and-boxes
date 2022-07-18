using System.Collections;
using UnityEngine;

namespace DotsAndBoxes.Gameplay.UI {
    public class PlayerTurnUI : BaseUI {
        public GameObject player1Shade;
        public GameObject player2Shade;


        public void Show(PlayerLabel label) {
            if (label == PlayerLabel.Player_1) {
                player1Shade.SetActive(false);
                player2Shade.SetActive(true);
            } else {
                player1Shade.SetActive(true);
                player2Shade.SetActive(false);
            }
        }
    }
}