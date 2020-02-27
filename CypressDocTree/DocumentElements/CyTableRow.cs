namespace CypressDocTree
{
    public class CyTableRow : CyDocumentElement
    {
        public RowType Type { get; set; } = RowType.DATA;

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
