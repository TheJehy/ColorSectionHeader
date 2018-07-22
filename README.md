# ColorSectionHeader
Simple colorful section headers for Unity.
Includes XML documentation for ease of use.
```CS
/// Implement quickly with your choice of digital color format:
/// Hex, Web-Format Hex, 8Bit RGB, Arithmetic RGB

// [ColorSectionHeader(string text, float height, color)]
   [ColorSectionHeader("HeaderText", 15.0f, "4DA1A9")]
   [ColorSectionHeader("HeaderText", 15.0f, "#4DA1A9")]
   [ColorSectionHeader("HeaderText", 15.0f, 77, 161, 169)]
   [ColorSectionHeader("HeaderText", 15.0f, 0.302f, 0.631f, 0.663f)]


/// Text darkness is chosen based on grayscale value to complement BG color.
/// Text size is scaled to fit inside section height.
/// Font is emboldened when text size is small (default is <18pt).
/// Font is padded to center (roughly) vertically. - Any tips on improving this would be helpful.

```

# Instructions
1. Create an Editor folder in */Assets/Editor/*.
2. Place ColorSectionHeader.cs in your */Assets/Scripts/* (or wherever you keep your scripts).
3. Create a CustomEditor in */Assets/Editor/* for the script(s) on which you want to use ColorSectionHeaders.
   * *A custom editor is **required** for the HeaderText to align with BG Colors.*
4. Add any of the above attribute tags above where you want to place a ColorSectionHeader

Find an example in this [Imgur](https://i.imgur.com/sE2L4Do.png) screenshot: 

![Alt text](https://i.imgur.com/sE2L4Do.png?raw=true "Title")
