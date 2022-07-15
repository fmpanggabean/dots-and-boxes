using System;
using System.Collections;
using UnityEngine;

namespace DotsAndBoxes.Gameplay {
    public class BoxChecker : MonoBehaviour {
        public GameManager gameManager;

        private void Start() {
            RegisterConnectEvent();
        }

        private void RegisterConnectEvent() {
            foreach(Node node in gameManager.nodes) {
                node.OnConnect += BoxCheck;
            }
        }

        private void BoxCheck(Node startNode, Node endNode) {
            for (int y = 0; y < gameManager.height - 1; y++) {
                for (int x = 0; x < gameManager.width - 1; x++) {
                    if (gameManager.boxes[y, x].isCounted) {
                        continue;
                    }
                    if (gameManager.boxes[y, x].IsAllConnected()) {
                        Debug.Log("Box formed");
                        gameManager.boxes[y, x].isCounted = true;
                    }
                }
            }
        }
    }
}