using System;

namespace DotsAndBoxes.Gameplay {
    public class Box {
        internal bool isCounted;
        private Node node1;
        private Node node2;
        private Node node3;
        private Node node4;

        public Box(Node node1, Node node2, Node node3, Node node4) {
            this.node1 = node1;
            this.node2 = node2;
            this.node3 = node3;
            this.node4 = node4;
            isCounted = false;
        }

        internal bool IsAllConnected() {
            if (
                node1.HasConnectionWith(node2) &&
                node2.HasConnectionWith(node3) &&
                node3.HasConnectionWith(node4) &&
                node4.HasConnectionWith(node1)
                ) {
                return true;
            }
            return false;
        }
    }
}