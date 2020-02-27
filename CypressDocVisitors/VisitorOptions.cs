using System.Windows.Media;

namespace CypressDocVisitors
{
    public class VisitorOptions
    {
        public  int H1_SIZE = 26;
        public  int H2_SIZE = 24;
        public  int H3_SIZE = 22;
        public  int H4_SIZE = 20;
        public  int H5_SIZE = 18;
        public  int H6_SIZE = 16;
        public  int TABLE_CAPTION_SIZE = 16;

        #region Brushes
        public Brush TABLE_BORDER_BRUSH = Brushes.LightSlateGray;
        public Brush ERROR_BRUSH = Brushes.LightPink;
        public Brush TABLE_CAPTION_BRUSH = Brushes.LightGray;
        public Brush TABLE_HEADER_BACKGROUND_BRUSH = Brushes.Silver;
        #endregion

        public bool ShowTitle { get; set; } = false;
    }//End Class
}//End namespace
