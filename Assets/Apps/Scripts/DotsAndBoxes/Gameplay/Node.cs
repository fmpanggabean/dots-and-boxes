using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DotsAndBoxes.Gameplay
{
    public class Node : MonoBehaviour
    {
        public List<Node> connectionList;

        private LineRenderer[] lineRenderer;
        private int currentLine;

        private void Awake() {
            lineRenderer = GetComponentsInChildren<LineRenderer>();
            currentLine = 0;
        }

        internal void BeginLineRenderer() {
            lineRenderer[currentLine].SetPosition(0, GetPosition());
        }

        internal void DrawLineTo(Vector3 position) {
            lineRenderer[currentLine].SetPosition(1, position);
        }
        internal void DrawLineTo(Node nodeEnd) {
            lineRenderer[currentLine].SetPosition(1, nodeEnd.GetPosition());
        }

        internal bool IsAvailableToConnectTo(Node endNode) {
            if (connectionList.Contains(endNode)) {
                Debug.Log("Unable to connect. Start Node already contain End Node");
                return false;
            } 
            if (endNode.connectionList.Contains(this)) {
                Debug.Log("Unable to connect. End Node already contain Start Node");
                return false;
            }
            return true;
        }

        internal void AddConnection(Node endNode) {
            Debug.Log("Node Connected.");
            connectionList.Add(endNode);
            endNode.connectionList.Add(this);

            MoveToNextLineRenderer();
        }

        private void MoveToNextLineRenderer() {
            currentLine++;
        }

        internal void CancelLine() {
            lineRenderer[currentLine].SetPosition(1, GetPosition());
        }

        private Vector3 GetPosition() {
            return transform.position;
        }
    }
}
