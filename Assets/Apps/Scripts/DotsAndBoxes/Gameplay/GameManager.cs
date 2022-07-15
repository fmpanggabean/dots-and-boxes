using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotsAndBoxes.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public int width;
        public int height;
        [SerializeField] private GameObject nodePrefab;
        public Node[,] nodes;
        public Box[,] boxes;

        private void Awake() {
            nodes = new Node[height, width];
            boxes = new Box[height - 1, width - 1];

            GenerateNode();
            GenerateBox();
            RegisterAllowedConnection();
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
    }
}
