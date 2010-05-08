namespace SharpWired.Utils {
    /// <summary>A Generic Pair class.</summary>
    /// <typeparam name="T">The first type</typeparam>
    /// <typeparam name="S">The second type.</typeparam>
    internal class Pair<T, S> {
        /// <summary>The first object in the pair.</summary>
        public T Key { get; set; }

        /// <summary>The second object in the pair.</summary>
        public S Value { get; set; }

        /// <summary>Set the two in the pair.</summary>
        /// <param name="pKey"></param>
        /// <param name="sValue"></param>
        public Pair(T pKey, S sValue) {
            Key = pKey;
            Value = sValue;
        }

        /// <summary>Empty. Key and Value gets default(T) and default(S) values.</summary>
        public Pair() {}
    }
}