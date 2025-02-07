namespace FigmaPareNet.Consts
{
    public class FigmaNodeConsts
    {
        public const string FigmaTextType = "TEXT";
        public const string FigmaComponentType = "COMPONENT";
        public const string FigmaInstanceType = "INSTANCE";

        public const string LayoutModeHorizontal = "HORIZONTAL";
        public const string LayoutModeNone = "NONE";
        public const string LayoutSizingFixed = "FIXED";

        public const string FillTypeSolid = "SOLID";

        public const string AlignMin = "MIN";
        public const string AlignMax = "MAX";
        public const string AlignCenter = "CENTER";
        public const string AlignSpaceBetween = "SPACE_BETWEEN";
        public const string AlignBaseline = "BASELINE";
        public const string AlignStretch = "STRETCH";

        public const string FlexStart = "flex-start";
        public const string FlexEnd = "flex-end";
        public const string Center = "center";
        public const string SpaceBetween = "space-between";
        public const string Baseline = "baseline";
        public const string Stretch = "stretch";
        public const string Flex = "flex";
        public const string Row = "row";
        public const string Column = "column";
        public const string Solid = "solid";
        public const string Auto = "auto";

        public static readonly HashSet<string> VectorLikeTypes = new HashSet<string>
        {
            "VECTOR",
            "BOOLEAN_OPERATION",
            "STAR",
            "LINE",
            "ELLIPSE",
            "POLYGON",
            "RECTANGLE"
        };

        // CSS Property Names
        public const string Width = "width";
        public const string Height = "height";
        public const string Left = "left";
        public const string Top = "top";
        public const string BackgroundColor = "backgroundColor";
        public const string BorderColor = "borderColor";
        public const string BorderWidth = "borderWidth";
        public const string BorderStyle = "borderStyle";
        public const string BorderRadius = "borderRadius";
        public const string Opacity = "opacity";
        public const string FontFamily = "fontFamily";
        public const string FontWeight = "fontWeight";
        public const string FontSize = "fontSize";
        public const string FontToken = "fontToken";
        public const string LineHeight = "lineHeight";
        public const string LetterSpacing = "letterSpacing";
        public const string TextAlign = "textAlign";
        public const string Color = "color";
        public const string Display = "display";
        public const string FlexDirection = "flexDirection";
        public const string JustifyContent = "justifyContent";
        public const string AlignItems = "alignItems";
        public const string AlignSelf = "alignSelf";
        public const string Gap = "gap";
        public const string PaddingLeft = "paddingLeft";
        public const string PaddingRight = "paddingRight";
        public const string PaddingTop = "paddingTop";
        public const string PaddingBottom = "paddingBottom";
    }
}
