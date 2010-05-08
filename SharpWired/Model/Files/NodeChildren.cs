using System.Collections.Generic;

namespace SharpWired.Model.Files {
    public class NodeChildren : List<INode> {
        private INode Parent { get; set; }

        public NodeChildren(INode parent) {
            Parent = parent;
        }

        public new INode Add(INode node) {
            base.Add(node);
            node.Parent = Parent;
            return node;
        }

        public new INode Remove(INode node) {
            node.Parent = null;
            base.Remove(node);
            return node;
        }
    }
}