using UnityEngine;
using UnityEditor;



[CustomPropertyDrawer(typeof(ColorSectionHeader))]
public class ColorSectionHeaderDrawer : DecoratorDrawer
{
    ColorSectionHeader header {
        get { return ((ColorSectionHeader)attribute); }
    }

    public override float GetHeight() {
        return base.GetHeight() + header.height;
    }

    public override void OnGUI(Rect position)
    {
        GUIStyle headerTextStyle = new GUIStyle();

        // Increase font size to fill color rect
        headerTextStyle.fontSize = (header.height <= 10) ?
            (int)header.height + 3 : 
            (int)header.height + 1;

        // Small text displays better when bold
        if (headerTextStyle.fontSize < 18) {
            headerTextStyle.fontStyle = FontStyle.Bold;
        }
        headerTextStyle.alignment = TextAnchor.UpperLeft;
        headerTextStyle.padding.top = (int)header.height / 3;
        headerTextStyle.padding.left = -(int)header.height / 5;
        
        if(header.bgColor.grayscale > 0.65f) {
            headerTextStyle.normal.textColor = new Color(0, 0, 0, 0.5f); // dark label
        } else {
            headerTextStyle.normal.textColor = new Color(1, 1, 1, 0.8f); // light label
        }
        
        float rectStretch = 0; // Set to -11 to fill width of inspector
        EditorGUI.DrawRect( new Rect(
            position.x - rectStretch, 
            position.y, 
            position.width + rectStretch, 
            position.height - 2),
            color: header.bgColor);
        
        Rect headerLabel = GUILayoutUtility.GetLastRect();
        headerLabel = new Rect(
            headerLabel.x - (rectStretch + 4 * headerTextStyle.padding.left), 
            headerLabel.y, 
            headerLabel.width, 
            headerLabel.height);

        // Draw text over color background
        EditorGUI.LabelField(headerLabel, header.text, headerTextStyle);
    }
}

/// <summary>
/// Displays a colored rectangle and header text.
/// Used for organizing custom inspectors.
/// </summary>
public class ColorSectionHeader : PropertyAttribute
{
    /// <summary>
    /// Title of the header.
    /// </summary>
    public string text;
    /// <summary>
    /// Pixel height of the section background.
    /// </summary>
    public float height;
    /// <summary>
    /// Background color of the header.
    /// </summary>
    public Color bgColor;

    /// <summary>
    /// Default constructor for testing.
    /// </summary>
    public ColorSectionHeader()
    {
        text = "Test Header";
        height = 15;
        bgColor = Color.white;
    }
    /// <summary>
    /// Color32(bytes) constructor.
    /// </summary>
    /// <param name="text">Header text</param>
    /// <param name="height">Pixel height of the section.</param>
    /// <param name="r">BGColor red value [0, 255].</param>
    /// <param name="g">BGColor green value [0, 255].</param>
    /// <param name="b">BGColor blue value [0, 255].</param>
    public ColorSectionHeader(string text, float height, byte r, byte g, byte b)
    {
        this.text = text;
        this.height = height;
        bgColor = new Color(r/255f, g/255f, b/255f);
    }
    /// <summary>
    /// Color(floats) constructor.
    /// </summary>
    /// <param name="text">Header text</param>
    /// <param name="height">Pixel height of the section.</param>
    /// <param name="r">BGColor red value [0, 1].</param>
    /// <param name="g">BGColor green value [0, 1].</param>
    /// <param name="b">BGColor blue value [0, 1].</param>
    public ColorSectionHeader(string text, float height, float r, float g, float b)
    {
        this.text = text;
        this.height = height;
        bgColor = new Color(r, g, b, 255);
    }
    /// <summary>
    /// Color(hex) constructor.
    /// </summary>
    /// <param name="text">Header text</param>
    /// <param name="height">Pixel height of the section.</param>
    /// <param name="hex">BGColor hex value [#123456 or 123456].</param>
    public ColorSectionHeader(string text, float height, string hex)
    {
        this.text = text;
        this.height = height;

        if(hex.Length >= 6 && hex.Length <= 7)
        {
            if (hex[0] == '#')
            {
                if (!ColorUtility.TryParseHtmlString(hex, out bgColor))
                    bgColor = Color.white; // Use white if can't parse hexidecimal
            }
            else if (hex.Length == 6)
            {
                if (!ColorUtility.TryParseHtmlString('#' + hex, out bgColor))
                    bgColor = Color.white;
            }
            else
            {
                bgColor = Color.white;
            }
        }
        else
        {
            bgColor = Color.white;
        }
    }
}
