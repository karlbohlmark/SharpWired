using System.Diagnostics;
using System.Windows.Forms;
using SharpWired.Model.Files;

namespace SharpWired.Gui.Files {
    public class WiredTreeNode : TreeNode {
        protected delegate void Func();

        public INode ModelNode { get; set; }

        public WiredTreeNode(INode modelNode) {
            ModelNode = modelNode;
            Text = modelNode.Name;
            Name = modelNode.FullPath; // Used only for searching the tree.
            PopulateFolder();
            modelNode.Updated += OnUpdated;
            modelNode.Offline += OnOffline;
        }

        public void OnUpdated(INode modelNode) {
            PopulateFolder();
        }
        
        public void OnOffline(INode modelNode) {
        	Debug.WriteLine("GUI:Tree -> OnOffline: " + modelNode.FullPath);
        	modelNode.Offline -= OnOffline;
        	modelNode.Updated -= OnUpdated;
        }

        private void PopulateFolder() {
            if (ModelNode is Folder) {
                Func del = delegate
                               {
                                   var folder = ModelNode as Folder;

                                   Debug.WriteLine("GUI:Tree -> Redrawing: " + folder.FullPath);

                                   Nodes.Clear();

                                   foreach (var child in folder.Children) {
                                       if (child is Folder) {
                                           Nodes.Add(new WiredTreeNode(child));
                                       }
                                   }
                               };

                //The TreeView is null when the current node has not been added to a TreeView
                if (TreeView != null) {
                    TreeView.Invoke(del); //Thread safe required when the node is added to a TreeView
                } else {
                    del(); //When the node is not added to a TreeView we don't need to be thread safe
                }
            }
        }
    }
}