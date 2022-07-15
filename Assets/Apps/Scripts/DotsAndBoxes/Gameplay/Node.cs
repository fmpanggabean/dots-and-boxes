using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DotsAndBoxes.Gameplay
{
    public class Node : MonoBehaviour
    {
        public List<Node> connectionList;
        public List<Node> allowedConnection;

        private LineRenderer[] lineRenderer;
        private int currentLine;

        public event Action<Node, Node> OnConnect_Node_Node;
        public event Action OnConnect;

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

        internal void AddAllowedConnection(Node node) {
            allowedConnection.Add(node);
        }

        internal void SetPosition(Vector3 position) {
            transform.position = position;
        }

        internal void DrawLineTo(Node nodeEnd) {
            lineRenderer[currentLine].SetPosition(1, nodeEnd.GetPosition());
        }

        internal bool IsAvailableToConnectTo(Node endNode) {
            if (HasConnectionWith(endNode)) {
                Debug.Log("Unable to connect. Node already has this connection.");
                return false;
            } 
            if (endNode.HasConnectionWith(this)) {
                Debug.Log("Unable to connect. Node already has this connection.");
                return false;
            }
            if (!allowedConnection.Contains(endNode)) {
                Debug.Log("Unable to connect. Node connection not allowed.");
                return false;
            }
            return true;
        }

        public bool HasConnectionWith(Node node) {
            return connectionList.Contains(node);
        }

        internal void AddConnection(Node endNode) {
            Debug.Log("Node Connected.");
            connectionList.Add(endNode);
            endNode.connectionList.Add(this);

            OnConnect_Node_Node?.Invoke(this, endNode);
            OnConnect?.Invoke();
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
