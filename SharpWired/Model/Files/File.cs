using SharpWired.MessageEvents;
using System;

namespace SharpWired.Model.Files {
    public class File : ANode, IFile {
        public long Size { get; private set; }

        public File(string path, DateTime created, DateTime modified, long size)
            : base(path, created, modified) {
            Size = size;
        }
        
        public override event UpdatedDelegate Updated;
        public override event UpdatedDelegate Offline;
        
        public override void Reload() {
            //FIXME: Run wired command STAT
            throw new NotImplementedException();
        }
        
        public override void Update(MessageEventArgs_410420 message) {
        	base.Update(message);
        	Size = message.Size;
        	
        	if(Updated!=null){
        		Updated(this);
        	}
        }
        
        public override void OnOffline(){
        	base.OnOffline();
        	
        	if(Offline != null){
        		Offline(this);
        	}
        }
    }
}