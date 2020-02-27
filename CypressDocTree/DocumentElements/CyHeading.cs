namespace CypressDocTree
{
    public class CyHeading : CyDocumentElement
    {
        public HeadingStyle HeadingStyle { get; set; }
        public Alignment Align { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Initialize an instance of CyHeading with the given string
        /// </summary>
        /// <param name="text">CyHeading text</param>
        public CyHeading(string text)
        {
            Text = text;
        }//End Constructor

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
