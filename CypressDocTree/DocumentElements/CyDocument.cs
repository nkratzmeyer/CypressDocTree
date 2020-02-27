namespace CypressDocTree
{
    public class CyDocument : CyDocumentElement
    {
        public string Title { get; set; }

        /// <summary>
        /// Initialize a new instance of CyDocument
        /// </summary>
        public CyDocument()
        {
            this.Title = "Defualt Title";
        }

        /// <summary>
        /// Constructor with Title
        /// </summary>
        /// <param name="value">Title for this document</param>
        public CyDocument(string value)
        {
            if (value != null)
                Title = value;
        }//End Csontructor

        /// <summary>
        /// Accept an IDocumentVisitor
        /// </summary>
        /// <param name="visitor">Class that implements IDocumentVisitor</param>
        public override void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }//End Accept
    }//End Tag
}//End Namespace
