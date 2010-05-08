using SharpWired.Model.Files;

namespace SharpWired.Gui.Files {
    public delegate void NodeSelectedDelegate(INode node);

    internal interface IFilesView {
        event NodeSelectedDelegate NodeSelected;

        void SetCurrentNode(INode node);
    }
}