# ColorSectionHeader
Simple colorful section headers for Unity
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

// I tried to comment the code as much as possible for ease of use and implementation choices.
```

Find an example here: https://imgur.com/fePH9PT
