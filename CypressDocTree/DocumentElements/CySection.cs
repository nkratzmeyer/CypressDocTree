namespace CypressDocTree
{
    public class CySection : CyDocumentElement
    {
        /// <summary>
        /// Gets or sets a value indicating that the visitor should attempt to keep this paragraph on one page
        /// </summary>
        public bool KeepTogether { get; set; }

        /// <summary>
        /// Accept an IDocumentVisitor
        /// </summary>
        /// <param name="visitor">Class that implements IDocumentVisitor</param>
        public override void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }//End Accept
    }
}
