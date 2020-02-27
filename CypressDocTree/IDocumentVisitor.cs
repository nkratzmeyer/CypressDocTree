namespace CypressDocTree
{
    public interface IDocumentVisitor
    {
        void Visit(CyDocument doc);
        void Visit(CyTable table);
        void Visit(CyTableRow row);
        void Visit(CyTableCell cell);
        void Visit(CyText txt);
        void Visit(CyParagraph paragraph);
        void Visit(CyHeading heading);
        void Visit(CySection section);
    }//End Interface
}//End Namespace