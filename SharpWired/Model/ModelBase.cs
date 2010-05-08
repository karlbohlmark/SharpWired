using SharpWired.Connection;

namespace SharpWired.Model {
    public abstract class ModelBase {
        protected static SharpWiredModel Model { get { return SharpWiredModel.Instance; } }

        protected static ConnectionManager ConnectionManager { get { return SharpWiredModel.Instance.ConnectionManager; } }
    }
}