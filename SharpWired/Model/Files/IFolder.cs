namespace SharpWired.Model.Files {
    public interface IFolder : INode {
        long Count { get; }
        NodeChildren Children { get; }

        INode Get(string path);
    }
}