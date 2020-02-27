using CypressDocTree;
using System.Windows;
using System.Windows.Documents;

namespace CypressDocVisitors
{
    public class FlowDocumentVisitor : IDocumentVisitor
    {
        protected readonly FlowDocument _doc;
        protected Table _activeTable;
        protected TableRow _activeRow;
        protected TableCell _activeCell;
        protected TableRowGroup _activeRowGroup;
        protected Paragraph _activeParagraph;
        public VisitorOptions Options { get; set; }

        public FlowDocumentVisitor(FlowDocument flowDoc) : this(flowDoc, new VisitorOptions())
        {

        }

        public FlowDocumentVisitor(FlowDocument flowDoc, VisitorOptions options)
        {
            _doc = flowDoc;
            this.Options = options;
        }

        public virtual void Visit(CyDocument doc)
        {
            if (doc.Title != null && Options.ShowTitle)
            {
                Run r = new Run(doc.Title)
                {
                    FontSize = Options.H1_SIZE,
                };
                Paragraph p = new Paragraph(r)
                {
                    TextAlignment = TextAlignment.Center
                };
                _doc.Blocks.Add(p);
            }
            foreach (var item in doc.ChildElements)
                item.Accept(this);
        }//End Visit(CyDocument)

        public virtual void Visit(CyTable table)
        {
            _activeTable = new Table();
            _activeTable.Margin = new Thickness(0);

            //Draw a border if requested
            if(table.Border > 0)
            {
                _activeTable.BorderThickness = new Thickness(table.Border);
                _activeTable.BorderBrush = Options.TABLE_BORDER_BRUSH;
            }

            if(table.CellSpacing > 0)
                _activeTable.CellSpacing = table.CellSpacing;
            
            //Add a caption if requested
            if (table.Caption != null)
            {
                Run captionRun = new Run(table.Caption)
                {
                    FontSize = Options.TABLE_CAPTION_SIZE
                };
                Paragraph captionParagraph = new Paragraph(captionRun);
                captionParagraph.Margin = new Thickness(0, 10, 0, 0);
                _doc.Blocks.Add(captionParagraph);
            }

            _activeRowGroup = new TableRowGroup();
            
            //Now visit all the rows of the table
            foreach (var item in table.ChildElements)
            {
                item.Accept(this);
            }

            _activeTable.RowGroups.Add(_activeRowGroup);
            if (table.KeepTogether)
            {
                Figure wrapper = new Figure(_activeTable);
                Paragraph paragraph = new Paragraph(wrapper);
                paragraph.KeepTogether = true;
                _doc.Blocks.Add(paragraph);
            }
            else
            {
                _doc.Blocks.Add(_activeTable);
            }
        }//End Visit(CyTable)

        public virtual void Visit(CyTableRow row)
        {
            _activeRow = new TableRow();

            foreach (var item in row.ChildElements)
                item.Accept(this);

            _activeRowGroup.Rows.Add(_activeRow);
        }//End Visit(row)

        public virtual void Visit(CyTableCell cell)
        {
            _activeCell = new TableCell()
            {
                ColumnSpan = cell.ColumnSpan
            };

            foreach (var item in cell.ChildElements)
                item.Accept(this);
            _activeRow.Cells.Add(_activeCell);
        }//End Visit(Cell)

        public virtual void Visit(CyText txt)
        {
            Run r = new Run(txt.Text);
          
            Bold b;
            Paragraph p;
            if (txt.IsBold)
            {
                b = new Bold(r);
                p = new Paragraph(b);
                p.TextAlignment = TextAlignment.Left;

            }
            else
            {
                p = new Paragraph(r);
                p.TextAlignment = TextAlignment.Left;
            }
            _activeCell.Blocks.Add(p);
        }//End Visit(Text)

        public virtual void Visit(CyParagraph paragraph)
        {
            Run r = new Run(paragraph.Text);
            Paragraph p = new Paragraph(r);
            if (paragraph.KeepTogether)
                p.KeepTogether = true;
            _doc.Blocks.Add(p);
        }//End Visit(CyParagraph)

        public virtual void Visit(CySection section)
        {
            Section s = new Section();

            foreach(var child in section.ChildElements)
            {
                child.Accept(this);
            }

            _doc.Blocks.Add(s);
        }//End Visit(CyParagraph)

        public virtual void Visit(CyHeading heading)
        {
            Run r = new Run(heading.Text);
       
            switch (heading.HeadingStyle)
            {
                case HeadingStyle.H1:
                    r.FontSize = Options.H1_SIZE;
                    break;
                case HeadingStyle.H2:
                    r.FontSize = Options.H2_SIZE;
                    break;
                case HeadingStyle.H3:
                    r.FontSize = Options.H3_SIZE;
                    break;
                case HeadingStyle.H4:
                    r.FontSize = Options.H4_SIZE;
                    break;
                case HeadingStyle.H5:
                    r.FontSize = Options.H5_SIZE;
                    break;
                case HeadingStyle.H6:
                    r.FontSize = Options.H6_SIZE;
                    break;
                default:
                    r.FontSize = Options.H4_SIZE;
                    break;
            }
            Paragraph p = new Paragraph(r);
           
            switch (heading.Align)
            {
                case Alignment.LEFT:
                    p.TextAlignment = TextAlignment.Left;
                    break;
                case Alignment.CENTER:
                    p.TextAlignment = TextAlignment.Center;
                    break;
                case Alignment.RIGHT:
                    p.TextAlignment = TextAlignment.Right;
                    break;
                default:
                    p.TextAlignment = TextAlignment.Center;
                    break;
            }//End Switch

            _doc.Blocks.Add(p);
        }//End Visit(CyHeading)
    }//End Tag
}//End namespace
