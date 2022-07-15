using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DotsAndBoxes.Gameplay
{
    public class PlayerInput : MonoBehaviour
    {
        public Node startNode;
        public Node endNode;

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                startNode = MouseOnNode();
                
                if (startNode) {
                    BeginDrawing();
                }
            } else if (Input.GetMouseButtonUp(0)) {
                endNode = MouseOnNode();

                if (startNode && endNode) {
                    if (startNode.IsAvailableToConnectTo(endNode)) {
                        startNode.DrawLineTo(endNode);
                        startNode.AddConnection(endNode);
                    }
                } else if (startNode && !endNode) {
                    startNode.CancelLine();
                }
                EndDraw();
            }

            if (startNode) {
                startNode.DrawLineTo(GetMouseInWorldPosition());
            }
        }

        private void EndDraw() {
            startNode = null;
            endNode = null;
        }

        private void BeginDrawing() {
            startNode.BeginLineRenderer();
        }

        private Node MouseOnNode() {
            RaycastHit2D hit2d;
            Vector3 position = GetMouseInWorldPosition();

            hit2d = Physics2D.Raycast(position, Vector3.forward);

            if (hit2d.collider == null) {
                return null;
            }

            Node n = hit2d.collider.GetComponent<Node>();

            if (n == null) {
                return null;
            }
            return n;
        }

        private Vector3 GetMouseInWorldPosition() {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
