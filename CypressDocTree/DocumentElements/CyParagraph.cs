namespace CypressDocTree
{
    public class CyParagraph : CyDocumentElement
    {
        public string Text { get; set; }

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
        
        /// <summary>
        /// Initialize a new instance of CyParagraph with the given text
        /// </summary>
        /// <param name="text">CyParagraph text</param>
        public CyParagraph(string text)
        {
            Text = text;
        }//End Constructor
    }//End Tag
}//End Namespace
