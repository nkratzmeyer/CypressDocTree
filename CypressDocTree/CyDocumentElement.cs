using System.Collections.Generic;

namespace CypressDocTree
{
    public abstract class CyDocumentElement : ICyDocumentElement
    {
        public ICollection<ICyDocumentElement> ChildElements { get; set; }
        public string Tag { get; set; }
        public abstract void Accept(IDocumentVisitor visitor);

        /// <summary>
        /// Initialize a new Instance of CyDocumentElement
        /// </summary>
        protected CyDocumentElement()
        {
            ChildElements = new List<ICyDocumentElement>();
        }//End Constructor

        /// <summary>
        /// Add a child element
        /// </summary>
        /// <param name="value">The element to add</param>
        public ICyDocumentElement AddChild(ICyDocumentElement value)
        {
            if (value != null)
                ChildElements.Add(value);

            return this;
        }//End AddChild

        /// <summary>
        /// Remove a child element
        /// </summary>
        /// <param name="value">The element to remove</param>
        /// <returns></returns>
        public bool RemoveChild(ICyDocumentElement value)
        {
            if (value != null)
              return ChildElements.Remove(value);

            return false;
        }//End RemoveChild

        public ICyDocumentElement AddTo(ICyDocumentElement newparent)
        {
            newparent.AddChild(this);
            return newparent;
        }
    }//End Tag
}//End Namespace
