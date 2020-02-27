namespace CypressDocTree
{
    public class CyTableCell : CyDocumentElement
    {
        public int ColumnSpan { get; set; } = 1;
        public Alignment HorizontalAlignment { get; set; }
        public Alignment VerticalAlignment { get; set; } = Alignment.MIDDLE;
        public CellType Type { get; set; } = CellType.DATA;

        /// <summary>
        /// Initialize a new instance of CyTableCell with the specified type
        /// </summary>
        /// <param name="type">Cell Type</param>
        public CyTableCell(CellType type)
        {
            Type = type;
        }//End Csonstructor

        /// <summary>
        /// Initialize a new instance of CyTableCell with the specified text
        /// </summary>
        /// <param name="text">The text to use</param>
        public CyTableCell(string text)
        {
            AddChild(new CyText(text));
        }//End Constructor

        public CyTableCell(string text, int colspan) : this(text)
        {
            ColumnSpan = colspan;
        }

        public CyTableCell(string text, CellType type) : this(text)
        {
            Type = type;
        }

        public CyTableCell(string text, CellType type, int colspan) : this(text, type)
        {
            ColumnSpan = colspan;
        }

        /// <summary>
        /// Initialize a new instance of CyTableCell with a CyText elemen
        /// </summary>
        /// <param name="text">The CyText element to use</param>
        public CyTableCell(CyText text)
        {
            AddChild(text);
        }//End Constructor

        public override void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }//End Accept
    }//End Tag
}//End Interface
