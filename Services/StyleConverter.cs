using FigmaPareNet.Consts;
using FigmaPareNet.Models;

namespace FigmaPareNet.Services
{
    public static class StyleConverter
    {
        public static Dictionary<string, string> ConvertFigmaStyleToCSS(FigmaNodeDocument node, Dictionary<string, FigmaNodeStyles>? styles)
        {
            var css = new Dictionary<string, string>();

            // Layout properties
            if (node.AbsoluteBoundingBox != null)
            {
                if (node.LayoutSizingHorizontal == FigmaNodeConsts.LayoutSizingFixed)
                {
                    css[FigmaNodeConsts.Width] = $"{node.AbsoluteBoundingBox.Width}px";
                }
                if (node.LayoutSizingVertical == FigmaNodeConsts.LayoutSizingFixed)
                {
                    css[FigmaNodeConsts.Height] = $"{node.AbsoluteBoundingBox.Height}px";
                }
            }

            // Position
            if (node.X.HasValue) css[FigmaNodeConsts.Left] = $"{node.X}px";
            if (node.Y.HasValue) css[FigmaNodeConsts.Top] = $"{node.Y}px";

            // Background
            if (HasValidBackgroundFill(node))
            {
                var fill = node.Fills[0];
                if (fill.Type == FigmaNodeConsts.FillTypeSolid && fill.Color != null)
                {
                    var color = fill.Color;
                    css[FigmaNodeConsts.BackgroundColor] = $"rgba({Math.Round(color.R * 255)}, {Math.Round(color.G * 255)}, {Math.Round(color.B * 255)}, {color.A})";
                }
            }

            // Border
            if (node.Strokes?.Count > 0)
            {
                var stroke = node.Strokes[0];
                if (stroke.Type == FigmaNodeConsts.FillTypeSolid)
                {
                    var color = stroke.Color;
                    css[FigmaNodeConsts.BorderColor] = $"rgba({Math.Round(color.R * 255)}, {Math.Round(color.G * 255)}, {Math.Round(color.B * 255)}, {color.A})";
                }
                css[FigmaNodeConsts.BorderWidth] = $"{node.StrokeThickness}px";
                css[FigmaNodeConsts.BorderStyle] = FigmaNodeConsts.Solid;
            }

            // Border radius
            if (node.CornerRadius.HasValue)
            {
                css[FigmaNodeConsts.BorderRadius] = $"{node.CornerRadius}px";
            }

            // Opacity
            if (node.Opacity.HasValue)
            {
                css[FigmaNodeConsts.Opacity] = node.Opacity.Value.ToString();
            }

            // Text styles
            if (node.Type == FigmaNodeConsts.FigmaTextType)
            {
                if (node.Style != null)
                {
                    if (!string.IsNullOrEmpty(node.Style.FontFamily))
                        css[FigmaNodeConsts.FontFamily] = node.Style.FontFamily;
                    if (node.Style.FontWeight != 0)
                        css[FigmaNodeConsts.FontWeight] = node.Style.FontWeight.ToString();
                    if (node.Style.FontSize != 0)
                        css[FigmaNodeConsts.FontSize] = $"{node.Style.FontSize}px";
                    if (node.Style.LineHeightPx != 0)
                        css[FigmaNodeConsts.LineHeight] = $"{node.Style.LineHeightPx}px";
                    if (node.Style.LetterSpacing != 0)
                        css[FigmaNodeConsts.LetterSpacing] = $"{node.Style.LetterSpacing}px";
                    if (!string.IsNullOrEmpty(node.Style.TextAlignHorizontal))
                        css[FigmaNodeConsts.TextAlign] = node.Style.TextAlignHorizontal.ToLower();
                }

                // Text color
                if (node.Fills?.Count > 0)
                {
                    var textFill = node.Fills[0];
                    if (textFill.Type == FigmaNodeConsts.FillTypeSolid && textFill.Color != null)
                    {
                        var color = textFill.Color;
                        css[FigmaNodeConsts.Color] = $"rgba({Math.Round(color.R * 255)}, {Math.Round(color.G * 255)}, {Math.Round(color.B * 255)}, {color.A})";
                    }
                }
            }

            // Layout
            if (!string.IsNullOrEmpty(node.LayoutMode))
            {
                css[FigmaNodeConsts.Display] = FigmaNodeConsts.Flex;
                css[FigmaNodeConsts.FlexDirection] = node.LayoutMode == FigmaNodeConsts.LayoutModeHorizontal
                    ? FigmaNodeConsts.Row
                    : FigmaNodeConsts.Column;

                if (!string.IsNullOrEmpty(node.PrimaryAxisAlignItems) && node.LayoutMode == null)
                {
                    css[FigmaNodeConsts.JustifyContent] = node.PrimaryAxisAlignItems switch
                    {
                        FigmaNodeConsts.AlignMin => FigmaNodeConsts.FlexStart,
                        FigmaNodeConsts.AlignMax => FigmaNodeConsts.FlexEnd,
                        FigmaNodeConsts.AlignCenter => FigmaNodeConsts.Center,
                        FigmaNodeConsts.AlignSpaceBetween => FigmaNodeConsts.SpaceBetween,
                        _ => FigmaNodeConsts.FlexStart
                    };
                }

                if (!string.IsNullOrEmpty(node.CounterAxisAlignItems) && node.LayoutMode == null)
                {
                    css[FigmaNodeConsts.AlignItems] = node.CounterAxisAlignItems switch
                    {
                        FigmaNodeConsts.AlignMin => FigmaNodeConsts.FlexStart,
                        FigmaNodeConsts.AlignMax => FigmaNodeConsts.FlexEnd,
                        FigmaNodeConsts.AlignCenter => FigmaNodeConsts.Center,
                        FigmaNodeConsts.AlignBaseline => FigmaNodeConsts.Baseline,
                        _ => FigmaNodeConsts.Stretch
                    };
                }

                if (!string.IsNullOrEmpty(node.LayoutAlign) && node.LayoutMode == null)
                {
                    css[FigmaNodeConsts.AlignSelf] = node.CounterAxisAlignItems switch
                    {
                        FigmaNodeConsts.AlignStretch => FigmaNodeConsts.Stretch,
                        FigmaNodeConsts.AlignCenter => FigmaNodeConsts.Center,
                        FigmaNodeConsts.AlignMin => FigmaNodeConsts.FlexStart,
                        FigmaNodeConsts.AlignMax => FigmaNodeConsts.FlexEnd,
                        _ => FigmaNodeConsts.Auto
                    };
                }

                if (node.ItemSpacing.HasValue)
                {
                    css[FigmaNodeConsts.Gap] = $"{node.ItemSpacing}px";
                }

                if (node.PaddingLeft.HasValue) css[FigmaNodeConsts.PaddingLeft] = $"{node.PaddingLeft}px";
                if (node.PaddingRight.HasValue) css[FigmaNodeConsts.PaddingRight] = $"{node.PaddingRight}px";
                if (node.PaddingTop.HasValue) css[FigmaNodeConsts.PaddingTop] = $"{node.PaddingTop}px";
                if (node.PaddingBottom.HasValue) css[FigmaNodeConsts.PaddingBottom] = $"{node.PaddingBottom}px";
            }

            // token styles
            if (node.Styles != null)
            {
                if (node.Styles.Fill != null)
                {
                    var color = styles?[node.Styles.Fill]?.Name;
                    if (color != null)
                    {
                        css[FigmaNodeConsts.Color] = color;
                    }
                }
                if (node.Styles.Text != null)
                {
                    var textToken = styles?[node.Styles.Text]?.Name;
                    if (textToken != null)
                    {
                        css[FigmaNodeConsts.FontToken] = textToken;
                    }
                }
            }

            return css;
        }

        private static bool HasValidBackgroundFill(FigmaNodeDocument node)
        {
            if (node.Fills?.Count <= 0 || node.BackgroundColor == null)
                return false;

            var bgColor = node.BackgroundColor;
            bool isTransparentBlack = bgColor.R == 0 &&
                                    bgColor.G == 0 &&
                                    bgColor.B == 0 &&
                                    bgColor.A == 0;

            return !isTransparentBlack;
        }
    }
}
