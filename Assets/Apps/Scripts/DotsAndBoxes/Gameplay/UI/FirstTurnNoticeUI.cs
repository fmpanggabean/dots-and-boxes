using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotsAndBoxes.Gameplay
{
    public class FirstTurnNoticeUI : BaseUI, IGameManager {
        public GameObject player1Side;
        public GameObject player2Side;

        public GameManager GameManager => FindObjectOfType<GameManager>();

        public event Action OnStartGame;

        private void Awake() {
            GameManager.OnPlayerTurnSet += ShowFirstTurn;
            OnStartGame += GameManager.StartGame;
        }
        public void ShowFirstTurn(PlayerLabel label) {
            if(label == PlayerLabel.Player_1) {
                player1Side.SetActive(true);
                player2Side.SetActive(false);
            } else if (label == PlayerLabel.Player_2) {
                player1Side.SetActive(false);
                player2Side.SetActive(true);
            }
            StartCoroutine(Wait());
        }

        private IEnumerator Wait() {
            yield return new WaitForSeconds(1);
            Hide();
            OnStartGame?.Invoke();
        }
    }
}
