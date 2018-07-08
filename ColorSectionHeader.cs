using UnityEngine;
using UnityEditor;



[CustomPropertyDrawer(typeof(ColorSectionHeader))]
public class ColorSectionHeaderDrawer : DecoratorDrawer
{
    ColorSectionHeader header
    {
        get { return ((ColorSectionHeader)attribute); }
    }

    public override float GetHeight()
    {
        return base.GetHeight() + header.height;
    }

    public override void OnGUI(Rect position)
    {
        GUIStyle myStyle = new GUIStyle();
        
        // Size up and enbolden font (if necessary) to fill header space
        myStyle.fontSize = (header.height <= 10) ? (int)header.height + 3 : (int)header.height + 1;
        if(myStyle.fontSize < 18) // Small texts display better when bold
            myStyle.fontStyle = FontStyle.Bold;

        // Ensure proper alignment for next step
        myStyle.alignment = TextAnchor.UpperLeft;

        // Center vertically and equalize horizontal:vertical padding
        myStyle.padding.top = (header.height <= 10) ? (int)header.height/3 : (int)header.height / 3;
        myStyle.padding.left = -(int)header.height / 5;

        // Label Color Dark or Light
        if(header.bgColor.grayscale > 0.65f)
        { myStyle.normal.textColor = new Color(0, 0, 0, 0.5f); }
        else
        { myStyle.normal.textColor = new Color(1, 1, 1, 0.8f); }
        
        // Extra rectangle width (-11 fills a zero depth inspector inspector)
        float rectStretch = 0;
        // Draw background (position.height-2 equalizes spacing between inspector items above and below)
        EditorGUI.DrawRect(new Rect(position.x- rectStretch, position.y, position.width+ rectStretch, position.height-2), header.bgColor);
        // Use the spacer rect for the text label
        Rect r = GUILayoutUtility.GetLastRect();
        EditorGUI.LabelField(new Rect(r.x-(rectStretch + 4*myStyle.padding.left), r.y, r.width, r.height), header.text, myStyle);
    }
}

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
    /// Color32(bytes) constructor.
    /// </summary>
    /// <param name="text">Header text</param>
    /// <param name="height">Pixel?Unit? height of the section.</param>
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
    /// <param name="height">Pixel?Unit? height of the section.</param>
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
    /// <param name="height">Pixel?Unit? height of the section.</param>
    /// <param name="hex">BGColor hex value [#123456 or 123456].</param>
    public ColorSectionHeader(string text, float height, string hex)
    {
        this.text = text;
        this.height = height;

        if(hex[0] == '#')
        {
            if (!ColorUtility.TryParseHtmlString(hex, out bgColor))
                bgColor = Color.white; // Use white if can't parse hexidecimal
        } else if(hex.Length == 6)
        {
            if (!ColorUtility.TryParseHtmlString('#' + hex, out bgColor))
                bgColor = Color.white; // Use white if can't parse hexidecimal
        }
    }
}