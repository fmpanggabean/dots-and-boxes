using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotsAndBoxes.Gameplay
{
    public class Board : MonoBehaviour
    {
        public int width;
        public int height;
        [SerializeField] private GameObject nodePrefab;
        public Node[,] nodes;
        public Box[,] boxes;

        public event Action<int> OnBoxFormed;
        public event Action OnFullBoard;

        private void Awake() {
            Init();
            GenerateNode();
            GenerateBox();
            RegisterAllowedConnection();
            RegisterConnectEvent();
        }

        private void Init() {
            nodes = new Node[height, width];
            boxes = new Box[height - 1, width - 1];
        }
        private void GenerateBox() {
            for (int y=0; y<height-1; y++) {
                for (int x=0; x<width-1; x++) {
                    boxes[y, x] = new Box(
                        nodes[y,x],
                        nodes[y,x+1],
                        nodes[y+1,x+1],
                        nodes[y+1,x]
                        );
                }
            }
        }
        private void RegisterAllowedConnection() {
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    if (x > 0) {
                        nodes[y, x].AddAllowedConnection(nodes[y, x-1]);
                    }
                    if (y > 0) {
                        nodes[y, x].AddAllowedConnection(nodes[y-1, x]);
                    }
                    if (x < width-1) {
                        nodes[y, x].AddAllowedConnection(nodes[y, x + 1]);
                    }
                    if (y < height - 1) {
                        nodes[y, x].AddAllowedConnection(nodes[y + 1, x]);
                    }
                }
            }
        }
        private void GenerateNode() {
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    nodes[y, x] = Instantiate(nodePrefab, transform).GetComponent<Node>();
                    nodes[y, x].SetPosition(GetWorldPosition(x, y));
                }
            }
        }
        private Vector3 GetWorldPosition(int x, int y) {
            Vector3 pos = new Vector3();
            pos.x = (float)x * 2f - (float)(width-1);
            pos.y = (float)y * 2f - (float)(height-1);

            return pos;
        }
        private void RegisterConnectEvent() {
            foreach (Node node in nodes) {
                node.OnConnect_Node_Node += BoxCheck;
            }
        }
        public void RegisterNextTurnEvent(Action action) {
            foreach (Node node in nodes) {
                node.OnConnect += action;
            }
        }
        private void BoxCheck(Node startNode, Node endNode) {
            int boxFormed = 0;
            int boxCounted = 0;
            for (int y = 0; y < height - 1; y++) {
                for (int x = 0; x < width - 1; x++) {
                    if (boxes[y, x].isCounted) {
                        boxCounted++;
                        continue;
                    }
                    if (boxes[y, x].IsAllConnected()) {
                        Debug.Log("Box formed");
                        boxCounted++;
                        boxFormed++;
                        boxes[y, x].isCounted = true;
                    }
                }
            }
            if (boxFormed > 0) {
                OnBoxFormed?.Invoke(boxFormed);
            }
            if (boxCounted == ((height-1) * (width-1))) {
                OnFullBoard?.Invoke();
            }
        }
    }
}
