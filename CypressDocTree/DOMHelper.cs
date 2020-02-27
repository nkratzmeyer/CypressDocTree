using System.Collections.Generic;

namespace CypressDocTree
{
    public static class DOMHelper
    {
        private const HeadingStyle PARAGRAPH_HEADING_STYLE = HeadingStyle.H4;
        public static void AddCell(string text, CyTableRow row, CellType type = CellType.DATA,
            int columnSpan = 1)
        {
            CyText txt = new CyText(text);
            if (type == CellType.HEADER)
                txt.IsBold = true;

            CyTableCell cell = new CyTableCell(type);
            cell.AddChild(txt);
            cell.ColumnSpan = columnSpan;
            row.AddChild(cell);
        }//End AddCell

        public static CyTableRow NewRow(RowType type, params string[] items)
        {
            CyTableRow row = new CyTableRow();
            CellType cellType;
            foreach (var item in items)
            {
                if (type == RowType.HEADER)
                    cellType = CellType.HEADER;
                else
                    cellType = CellType.DATA;

                AddCell(item, row, cellType);
            }
            return row;
        }//End NewRow

        public static CyTable NewRow(RowType type, int maxColumns, CyTable parentTable,
            params string[] items)
        {
            CyTableRow row = new CyTableRow();
            CellType cellType;

            for (int i = 0; i < items.Length; i++)
            {
                if (type == RowType.HEADER)
                    cellType = CellType.HEADER;
                else
                    cellType = CellType.DATA;

                if (maxColumns % i == 0)
                {
                    parentTable.AddChild(row);
                    row = new CyTableRow();
                }

                AddCell(items[i], row, cellType);
            }

            return parentTable;
        }//End NewRow

        public static void AddParagraph(string heading, string text, CyDocument doc)
        {
            CyHeading header = new CyHeading(heading)
            {
                HeadingStyle = PARAGRAPH_HEADING_STYLE
            };
            doc.AddChild(header);

            CyParagraph paragraph = new CyParagraph(text);
            doc.AddChild(paragraph);
        }//End AddParagraph

        public static string YesOrNo(bool value)
        {
            return value ? "YES" : "NO";
        }//End YesOrNo

        public static CyTable HeaderAndRow(Dictionary<string, string> rowValues, CyTable table)
        {
            CyTableRow row = new CyTableRow();
            foreach (var item in rowValues.Keys)
                AddCell(item, row, CellType.HEADER);

            table.AddChild(row);

            row = new CyTableRow();
            foreach (var item in rowValues.Values)
                AddCell(item, row, CellType.DATA);

            table.AddChild(row);
            return table;
        }//End HeaderAndRow

        public static CyTable HeaderAndRow(Dictionary<string, string> rowValues, int maxColumns,
            CyTable table)
        {
            CyTableRow headerRow = new CyTableRow();
            CyTableRow dataRow = new CyTableRow();

            int columnCount = 0;

            foreach (var item in rowValues.Keys)
            {
                if (columnCount >= maxColumns)
                {
                    columnCount = 0;
                    table.AddChild(headerRow);
                    table.AddChild(dataRow);
                    headerRow = new CyTableRow();
                    dataRow = new CyTableRow();
                }

                AddCell(item, headerRow, CellType.HEADER);
                AddCell(rowValues[item], dataRow, CellType.DATA);
                columnCount++;
            }

            table.AddChild(headerRow);
            table.AddChild(dataRow);
            return table;
        }//End HeaderAndRow
    }//End Class
}
