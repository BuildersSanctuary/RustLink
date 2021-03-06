using MudBlazor;

namespace Website.Client.Shared;

public static class Theme
{
    public static H1 Heading1 = AntonFontConfig<H1>("35px");
    public static H2 Heading2 = AntonFontConfig<H2>("30px");
    public static H3 Heading3 = AntonFontConfig<H3>("25px");
    public static H4 Heading4 = AntonFontConfig<H4>("20px");
    public static H5 Heading5 = AntonFontConfig<H5>("15px");
    public static H6 Heading6 = AntonFontConfig<H6>("12px"); 

    private static TFuckingFontType AntonFontConfig<TFuckingFontType>(string fontSize = null) where TFuckingFontType : BaseTypography, new()
    {
        return new TFuckingFontType()
        {
            FontFamily = new string[] { "Anton" },
            FontSize = fontSize,
        };
    }

    public static MudTheme RadiumTheme = new MudTheme()
    {
        Palette = new Palette()
        {
            Primary = "#7289da",
            PrimaryLighten = "#9fb2f5",
            PrimaryDarken = "5365a3",

            Black = "#242529",
            Background = "#141517",
            BackgroundGrey = "#313438",

            Surface = "#0c0c0d",
            DrawerBackground = "#0c0c0d",
            DrawerText = "rgba(255,255,255, 0.50)",
            DrawerIcon = "rgba(255,255,255, 0.50)",

            AppbarBackground = "#141517",
            AppbarText = Colors.Shades.Black,

            TextPrimary = "rgba(255,255,255, 1)",
            TextSecondary = "rgba(255,255,255, 0.60)",

            ActionDefault = "#7289da",
            ActionDisabled = "rgba(255,255,255, 0.26)",
            ActionDisabledBackground = "rgba(255,255,255, 0.12)",
            Divider = "rgba(255,255,255, 0.12)",
            DividerLight = "rgba(255,255,255, 0.06)",
            TableLines = "rgba(255,255,255, 0.12)",
            LinesDefault = "rgba(255,255,255, 0.12)",
            LinesInputs = "rgba(255,255,255, 0.3)",
            TextDisabled = "rgba(255,255,255, 0.2)"
        },

        LayoutProperties = new LayoutProperties()
        {
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "300px"
        },

        Typography = new Typography()
        {
            H1 = Heading1,
            H2 = Heading2,
            H3 = Heading3,
            H4 = Heading4,
            H5 = Heading5,
            H6 = Heading6
        }
    };
}