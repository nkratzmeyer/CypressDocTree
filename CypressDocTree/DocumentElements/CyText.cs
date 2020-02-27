namespace CypressDocTree
{
    public class CyText : CyDocumentElement
    {
        public string Text { set; get; }
        public bool IsBold { get; set; }
        public bool IsPreformatted { get; set; }

        public override void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }//End Accept

        public CyText(string value)
        {
            if (value != null)
                Text = value;
        }//End Constructor

        public CyText(string value, bool bold): this(value)
        {
            IsBold = bold;
        }//End Constructor

        public CyText(string value, bool bold, bool preformatted) : this(value, bold)
        {
            IsPreformatted = preformatted;
        }
    }//End Tag
}//End Namespace
