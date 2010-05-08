using SharpWired.MessageEvents;
using System;

namespace SharpWired.Model.Files {
    public delegate void UpdatedDelegate(INode node);

    public interface INode : IComparable {
        /* Based on this blog post:
         * http://dvanderboom.wordpress.com/2008/03/15/treet-implementing-a-non-binary-tree-in-c/
         */

        INode Parent { get; set; }
        INode Root { get; }
        int Depth { get; }

        string Name { get; }
        string Path { get; }
        string FullPath { get; }
        DateTime Created { get; }
        DateTime Modified { get; }
        DateTime LastRefreshed { get; }

        event UpdatedDelegate Updated;
        event UpdatedDelegate Offline;

        void Reload();
        void Update(MessageEventArgs_410420 message);
        void OnOffline();
    }
}