namespace FigmaPareNet.Models
{
    public class FigmaNodeDocument
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public BoundingBox? AbsoluteBoundingBox { get; set; }
        public float? X { get; set; }
        public float? Y { get; set; }
        public List<Fill>? Fills { get; set; }
        public List<Fill>? Strokes { get; set; }
        public float StrokeThickness { get; set; }
        public float? CornerRadius { get; set; }
        public float? Opacity { get; set; }
        public FigmaStyle? Style { get; set; }
        public string? LayoutMode { get; set; }
        public string? PrimaryAxisAlignItems { get; set; }
        public string? CounterAxisAlignItems { get; set; }
        public string? LayoutAlign { get; set; }
        public float? ItemSpacing { get; set; }
        public float? PaddingLeft { get; set; }
        public float? PaddingRight { get; set; }
        public float? PaddingTop { get; set; }
        public float? PaddingBottom { get; set; }
        public string? Characters { get; set; }
        public List<FigmaNodeDocument>? Children { get; set; }
        public string? ComponentId { get; set; }
        public bool? Visible { get; set; }
        public Dictionary<string, FigmaComponentProperty>? ComponentProperties { get; set; }
        public FigmaRemoteStyle? Styles { get; set; }
        public string? LayoutSizingHorizontal { get; set; }
        public string? LayoutSizingVertical { get; set; }
        public FigmaColor? BackgroundColor { get; set; }
    }

    public class FigmaComponentProperty
    {
        public string? Value { get; set; }
        public string? Type { get; set; }
    }

    public class FigmaColor
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
    }

    public class BoundingBox
    {
        public float? Width { get; set; }
        public float? Height { get; set; }
    }

    public class Fill
    {
        public string? Type { get; set; }
        public FigmaColor? Color { get; set; }
    }

    public class FigmaStyle
    {
        public string? FontFamily { get; set; }
        public int? FontWeight { get; set; }
        public float? FontSize { get; set; }
        public float? LineHeightPx { get; set; }
        public float? LetterSpacing { get; set; }
        public string? TextAlignHorizontal { get; set; }
    }

    public class FigmaRemoteStyle
    {
        public string? Fill { get; set; }
        public string? Text { get; set; }
    }
}
