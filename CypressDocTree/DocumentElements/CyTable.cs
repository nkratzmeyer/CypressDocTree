namespace CypressDocTree
{
    public class CyTable : CyDocumentElement
    {
        public string Caption {get; set; }
        public int Width { get; set; }
        public int Border { get; set; }
        public int CellSpacing { get; set;}
        public int CellPadding { get; set; }
        public bool PercentageWidth { get; set; }
        public bool KeepTogether { get; set; }
        public int RowCount => ChildElements.Count;

        /// <summary>
        /// Initialize a new instance of CyTable with the given caption
        /// </summary>
        /// <param name="caption">Table Caption</param>
        public CyTable(string caption)
        {
            Caption = caption;
        }//End Constructor

        public CyTable()
        {
                
        }//End default constructor

        /// <summary>
        /// Accept an IDocumentVisitor
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }//End Accept
    }//End Tag
}//End Namespace
