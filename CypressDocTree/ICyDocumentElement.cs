using System.Collections.Generic;

namespace CypressDocTree
{
    public interface ICyDocumentElement
    {
        ICollection<ICyDocumentElement> ChildElements { get; set; }
        string Tag { get; set; }

        void Accept(IDocumentVisitor visitor);
        ICyDocumentElement AddChild(ICyDocumentElement value);
        bool RemoveChild(ICyDocumentElement value);

        ICyDocumentElement AddTo(ICyDocumentElement newparent);
    }//End Interface
}//End Namespace