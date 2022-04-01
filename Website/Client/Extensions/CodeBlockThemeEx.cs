namespace MudBlazor;

internal static class CodeBlockThemeEx
{
	public static string GetStylesheetPath(this CodeBlockTheme @this) =>
		@this switch
		{
			CodeBlockTheme.A11yDark => "a11y-dark.min.css",
			CodeBlockTheme.A11yLight => "a11y-light.min.css",
			CodeBlockTheme.Agate => "agate.min.css",
			CodeBlockTheme.AnOldHope => "an-old-hope.min.css",
			CodeBlockTheme.Androidstudio => "androidstudio.min.css",
			CodeBlockTheme.ArduinoLight => "arduino-light.min.css",
			CodeBlockTheme.Arta => "arta.min.css",
			CodeBlockTheme.Ascetic => "ascetic.min.css",
			CodeBlockTheme.AtomOneDarkReasonable => "atom-one-dark-reasonable.min.css",
			CodeBlockTheme.AtomOneDark => "atom-one-dark.min.css",
			CodeBlockTheme.AtomOneLight => "atom-one-light.min.css",
			CodeBlockTheme.BrownPaper => "brown-paper.min.css",
			CodeBlockTheme.CodepenEmbed => "codepen-embed.min.css",
			CodeBlockTheme.ColorBrewer => "color-brewer.min.css",
			CodeBlockTheme.Dark => "dark.min.css",
			CodeBlockTheme.Default => "default.min.css",
			CodeBlockTheme.Devibeans => "devibeans.min.css",
			CodeBlockTheme.Docco => "docco.min.css",
			CodeBlockTheme.Far => "far.min.css",
			CodeBlockTheme.Foundation => "foundation.min.css",
			CodeBlockTheme.GithubDarkDimmed => "github-dark-dimmed.min.css",
			CodeBlockTheme.GithubDark => "github-dark.min.css",
			CodeBlockTheme.Github => "github.min.css",
			CodeBlockTheme.Gml => "gml.min.css",
			CodeBlockTheme.Googlecode => "googlecode.min.css",
			CodeBlockTheme.GradientDark => "gradient-dark.min.css",
			CodeBlockTheme.GradientLight => "gradient-light.min.css",
			CodeBlockTheme.Grayscale => "grayscale.min.css",
			CodeBlockTheme.Hybrid => "hybrid.min.css",
			CodeBlockTheme.Idea => "idea.min.css",
			CodeBlockTheme.IrBlack => "ir-black.min.css",
			CodeBlockTheme.IsblEditorDark => "isbl-editor-dark.min.css",
			CodeBlockTheme.IsblEditorLight => "isbl-editor-light.min.css",
			CodeBlockTheme.KimbieDark => "kimbie-dark.min.css",
			CodeBlockTheme.KimbieLight => "kimbie-light.min.css",
			CodeBlockTheme.Lightfair => "lightfair.min.css",
			CodeBlockTheme.Lioshi => "lioshi.min.css",
			CodeBlockTheme.Magula => "magula.min.css",
			CodeBlockTheme.MonoBlue => "mono-blue.min.css",
			CodeBlockTheme.MonokaiSublime => "monokai-sublime.min.css",
			CodeBlockTheme.Monokai => "monokai.min.css",
			CodeBlockTheme.NightOwl => "night-owl.min.css",
			CodeBlockTheme.NnfxDark => "nnfx-dark.min.css",
			CodeBlockTheme.NnfxLight => "nnfx-light.min.css",
			CodeBlockTheme.Nord => "nord.min.css",
			CodeBlockTheme.Obsidian => "obsidian.min.css",
			CodeBlockTheme.ParaisoDark => "paraiso-dark.min.css",
			CodeBlockTheme.ParaisoLight => "paraiso-light.min.css",
			CodeBlockTheme.Pojoaque => "pojoaque.min.css",
			CodeBlockTheme.Purebasic => "purebasic.min.css",
			CodeBlockTheme.QtcreatorDark => "qtcreator-dark.min.css",
			CodeBlockTheme.QtcreatorLight => "qtcreator-light.min.css",
			CodeBlockTheme.Rainbow => "rainbow.min.css",
			CodeBlockTheme.Routeros => "routeros.min.css",
			CodeBlockTheme.SchoolBook => "school-book.min.css",
			CodeBlockTheme.ShadesOfPurple => "shades-of-purple.min.css",
			CodeBlockTheme.Srcery => "srcery.min.css",
			CodeBlockTheme.StackoverflowDark => "stackoverflow-dark.min.css",
			CodeBlockTheme.StackoverflowLight => "stackoverflow-light.min.css",
			CodeBlockTheme.Sunburst => "sunburst.min.css",
			CodeBlockTheme.TomorrowNightBlue => "tomorrow-night-blue.min.css",
			CodeBlockTheme.TomorrowNightBright => "tomorrow-night-bright.min.css",
			CodeBlockTheme.Vs => "vs.min.css",
			CodeBlockTheme.Vs2015 => "vs2015.min.css",
			CodeBlockTheme.Xcode => "xcode.min.css",
			CodeBlockTheme.Xt256 => "xt256.min.css",
			CodeBlockTheme.ApathyBase16 => "base16/apathy.min.css",
			CodeBlockTheme.ApprenticeBase16 => "base16/apprentice.min.css",
			CodeBlockTheme.AshesBase16 => "base16/ashes.min.css",
			CodeBlockTheme.AtelierCaveLightBase16 => "base16/atelier-cave-light.min.css",
			CodeBlockTheme.AtelierCaveBase16 => "base16/atelier-cave.min.css",
			CodeBlockTheme.AtelierDuneLightBase16 => "base16/atelier-dune-light.min.css",
			CodeBlockTheme.AtelierDuneBase16 => "base16/atelier-dune.min.css",
			CodeBlockTheme.AtelierEstuaryLightBase16 => "base16/atelier-estuary-light.min.css",
			CodeBlockTheme.AtelierEstuaryBase16 => "base16/atelier-estuary.min.css",
			CodeBlockTheme.AtelierForestLightBase16 => "base16/atelier-forest-light.min.css",
			CodeBlockTheme.AtelierForestBase16 => "base16/atelier-forest.min.css",
			CodeBlockTheme.AtelierHeathLightBase16 => "base16/atelier-heath-light.min.css",
			CodeBlockTheme.AtelierHeathBase16 => "base16/atelier-heath.min.css",
			CodeBlockTheme.AtelierLakesideLightBase16 => "base16/atelier-lakeside-light.min.css",
			CodeBlockTheme.AtelierLakesideBase16 => "base16/atelier-lakeside.min.css",
			CodeBlockTheme.AtelierPlateauLightBase16 => "base16/atelier-plateau-light.min.css",
			CodeBlockTheme.AtelierPlateauBase16 => "base16/atelier-plateau.min.css",
			CodeBlockTheme.AtelierSavannaLightBase16 => "base16/atelier-savanna-light.min.css",
			CodeBlockTheme.AtelierSavannaBase16 => "base16/atelier-savanna.min.css",
			CodeBlockTheme.AtelierSeasideLightBase16 => "base16/atelier-seaside-light.min.css",
			CodeBlockTheme.AtelierSeasideBase16 => "base16/atelier-seaside.min.css",
			CodeBlockTheme.AtelierSulphurpoolLightBase16 => "base16/atelier-sulphurpool-light.min.css",
			CodeBlockTheme.AtelierSulphurpoolBase16 => "base16/atelier-sulphurpool.min.css",
			CodeBlockTheme.AtlasBase16 => "base16/atlas.min.css",
			CodeBlockTheme.BespinBase16 => "base16/bespin.min.css",
			CodeBlockTheme.BlackMetalBathoryBase16 => "base16/black-metal-bathory.min.css",
			CodeBlockTheme.BlackMetalBurzumBase16 => "base16/black-metal-burzum.min.css",
			CodeBlockTheme.BlackMetalDarkFuneralBase16 => "base16/black-metal-dark-funeral.min.css",
			CodeBlockTheme.BlackMetalGorgorothBase16 => "base16/black-metal-gorgoroth.min.css",
			CodeBlockTheme.BlackMetalImmortalBase16 => "base16/black-metal-immortal.min.css",
			CodeBlockTheme.BlackMetalKholdBase16 => "base16/black-metal-khold.min.css",
			CodeBlockTheme.BlackMetalMardukBase16 => "base16/black-metal-marduk.min.css",
			CodeBlockTheme.BlackMetalMayhemBase16 => "base16/black-metal-mayhem.min.css",
			CodeBlockTheme.BlackMetalNileBase16 => "base16/black-metal-nile.min.css",
			CodeBlockTheme.BlackMetalVenomBase16 => "base16/black-metal-venom.min.css",
			CodeBlockTheme.BlackMetalBase16 => "base16/black-metal.min.css",
			CodeBlockTheme.BrewerBase16 => "base16/brewer.min.css",
			CodeBlockTheme.BrightBase16 => "base16/bright.min.css",
			CodeBlockTheme.BrogrammerBase16 => "base16/brogrammer.min.css",
			CodeBlockTheme.BrushTreesDarkBase16 => "base16/brush-trees-dark.min.css",
			CodeBlockTheme.BrushTreesBase16 => "base16/brush-trees.min.css",
			CodeBlockTheme.ChalkBase16 => "base16/chalk.min.css",
			CodeBlockTheme.CircusBase16 => "base16/circus.min.css",
			CodeBlockTheme.ClassicDarkBase16 => "base16/classic-dark.min.css",
			CodeBlockTheme.ClassicLightBase16 => "base16/classic-light.min.css",
			CodeBlockTheme.CodeschoolBase16 => "base16/codeschool.min.css",
			CodeBlockTheme.ColorsBase16 => "base16/colors.min.css",
			CodeBlockTheme.CupcakeBase16 => "base16/cupcake.min.css",
			CodeBlockTheme.CupertinoBase16 => "base16/cupertino.min.css",
			CodeBlockTheme.DanqingBase16 => "base16/danqing.min.css",
			CodeBlockTheme.DarculaBase16 => "base16/darcula.min.css",
			CodeBlockTheme.DarkVioletBase16 => "base16/dark-violet.min.css",
			CodeBlockTheme.DarkmossBase16 => "base16/darkmoss.min.css",
			CodeBlockTheme.DarktoothBase16 => "base16/darktooth.min.css",
			CodeBlockTheme.DecafBase16 => "base16/decaf.min.css",
			CodeBlockTheme.DefaultDarkBase16 => "base16/default-dark.min.css",
			CodeBlockTheme.DefaultLightBase16 => "base16/default-light.min.css",
			CodeBlockTheme.DirtyseaBase16 => "base16/dirtysea.min.css",
			CodeBlockTheme.DraculaBase16 => "base16/dracula.min.css",
			CodeBlockTheme.EdgeDarkBase16 => "base16/edge-dark.min.css",
			CodeBlockTheme.EdgeLightBase16 => "base16/edge-light.min.css",
			CodeBlockTheme.EightiesBase16 => "base16/eighties.min.css",
			CodeBlockTheme.EmbersBase16 => "base16/embers.min.css",
			CodeBlockTheme.EquilibriumDarkBase16 => "base16/equilibrium-dark.min.css",
			CodeBlockTheme.EquilibriumGrayDarkBase16 => "base16/equilibrium-gray-dark.min.css",
			CodeBlockTheme.EquilibriumGrayLightBase16 => "base16/equilibrium-gray-light.min.css",
			CodeBlockTheme.EquilibriumLightBase16 => "base16/equilibrium-light.min.css",
			CodeBlockTheme.EspressoBase16 => "base16/espresso.min.css",
			CodeBlockTheme.EvaDimBase16 => "base16/eva-dim.min.css",
			CodeBlockTheme.EvaBase16 => "base16/eva.min.css",
			CodeBlockTheme.FlatBase16 => "base16/flat.min.css",
			CodeBlockTheme.FramerBase16 => "base16/framer.min.css",
			CodeBlockTheme.FruitSodaBase16 => "base16/fruit-soda.min.css",
			CodeBlockTheme.GigavoltBase16 => "base16/gigavolt.min.css",
			CodeBlockTheme.GithubBase16 => "base16/github.min.css",
			CodeBlockTheme.GoogleDarkBase16 => "base16/google-dark.min.css",
			CodeBlockTheme.GoogleLightBase16 => "base16/google-light.min.css",
			CodeBlockTheme.GrayscaleDarkBase16 => "base16/grayscale-dark.min.css",
			CodeBlockTheme.GrayscaleLightBase16 => "base16/grayscale-light.min.css",
			CodeBlockTheme.GreenScreenBase16 => "base16/green-screen.min.css",
			CodeBlockTheme.GruvboxDarkHardBase16 => "base16/gruvbox-dark-hard.min.css",
			CodeBlockTheme.GruvboxDarkMediumBase16 => "base16/gruvbox-dark-medium.min.css",
			CodeBlockTheme.GruvboxDarkPaleBase16 => "base16/gruvbox-dark-pale.min.css",
			CodeBlockTheme.GruvboxDarkSoftBase16 => "base16/gruvbox-dark-soft.min.css",
			CodeBlockTheme.GruvboxLightHardBase16 => "base16/gruvbox-light-hard.min.css",
			CodeBlockTheme.GruvboxLightMediumBase16 => "base16/gruvbox-light-medium.min.css",
			CodeBlockTheme.GruvboxLightSoftBase16 => "base16/gruvbox-light-soft.min.css",
			CodeBlockTheme.HardcoreBase16 => "base16/hardcore.min.css",
			CodeBlockTheme.Harmonic16DarkBase16 => "base16/harmonic16-dark.min.css",
			CodeBlockTheme.Harmonic16LightBase16 => "base16/harmonic16-light.min.css",
			CodeBlockTheme.HeetchDarkBase16 => "base16/heetch-dark.min.css",
			CodeBlockTheme.HeetchLightBase16 => "base16/heetch-light.min.css",
			CodeBlockTheme.HeliosBase16 => "base16/helios.min.css",
			CodeBlockTheme.HopscotchBase16 => "base16/hopscotch.min.css",
			CodeBlockTheme.HorizonDarkBase16 => "base16/horizon-dark.min.css",
			CodeBlockTheme.HorizonLightBase16 => "base16/horizon-light.min.css",
			CodeBlockTheme.HumanoidDarkBase16 => "base16/humanoid-dark.min.css",
			CodeBlockTheme.HumanoidLightBase16 => "base16/humanoid-light.min.css",
			CodeBlockTheme.IaDarkBase16 => "base16/ia-dark.min.css",
			CodeBlockTheme.IaLightBase16 => "base16/ia-light.min.css",
			CodeBlockTheme.IcyDarkBase16 => "base16/icy-dark.min.css",
			CodeBlockTheme.IrBlackBase16 => "base16/ir-black.min.css",
			CodeBlockTheme.IsotopeBase16 => "base16/isotope.min.css",
			CodeBlockTheme.KimberBase16 => "base16/kimber.min.css",
			CodeBlockTheme.LondonTubeBase16 => "base16/london-tube.min.css",
			CodeBlockTheme.MacintoshBase16 => "base16/macintosh.min.css",
			CodeBlockTheme.MarrakeshBase16 => "base16/marrakesh.min.css",
			CodeBlockTheme.MateriaBase16 => "base16/materia.min.css",
			CodeBlockTheme.MaterialDarkerBase16 => "base16/material-darker.min.css",
			CodeBlockTheme.MaterialLighterBase16 => "base16/material-lighter.min.css",
			CodeBlockTheme.MaterialPalenightBase16 => "base16/material-palenight.min.css",
			CodeBlockTheme.MaterialVividBase16 => "base16/material-vivid.min.css",
			CodeBlockTheme.MaterialBase16 => "base16/material.min.css",
			CodeBlockTheme.MellowPurpleBase16 => "base16/mellow-purple.min.css",
			CodeBlockTheme.MexicoLightBase16 => "base16/mexico-light.min.css",
			CodeBlockTheme.MochaBase16 => "base16/mocha.min.css",
			CodeBlockTheme.MonokaiBase16 => "base16/monokai.min.css",
			CodeBlockTheme.NebulaBase16 => "base16/nebula.min.css",
			CodeBlockTheme.NordBase16 => "base16/nord.min.css",
			CodeBlockTheme.NovaBase16 => "base16/nova.min.css",
			CodeBlockTheme.OceanBase16 => "base16/ocean.min.css",
			CodeBlockTheme.OceanicnextBase16 => "base16/oceanicnext.min.css",
			CodeBlockTheme.OneLightBase16 => "base16/one-light.min.css",
			CodeBlockTheme.OnedarkBase16 => "base16/onedark.min.css",
			CodeBlockTheme.OutrunDarkBase16 => "base16/outrun-dark.min.css",
			CodeBlockTheme.PapercolorDarkBase16 => "base16/papercolor-dark.min.css",
			CodeBlockTheme.PapercolorLightBase16 => "base16/papercolor-light.min.css",
			CodeBlockTheme.ParaisoBase16 => "base16/paraiso.min.css",
			CodeBlockTheme.PasqueBase16 => "base16/pasque.min.css",
			CodeBlockTheme.PhdBase16 => "base16/phd.min.css",
			CodeBlockTheme.PicoBase16 => "base16/pico.min.css",
			CodeBlockTheme.PopBase16 => "base16/pop.min.css",
			CodeBlockTheme.PorpleBase16 => "base16/porple.min.css",
			CodeBlockTheme.QualiaBase16 => "base16/qualia.min.css",
			CodeBlockTheme.RailscastsBase16 => "base16/railscasts.min.css",
			CodeBlockTheme.RebeccaBase16 => "base16/rebecca.min.css",
			CodeBlockTheme.RosPineDawnBase16 => "base16/ros-pine-dawn.min.css",
			CodeBlockTheme.RosPineMoonBase16 => "base16/ros-pine-moon.min.css",
			CodeBlockTheme.RosPineBase16 => "base16/ros-pine.min.css",
			CodeBlockTheme.SagelightBase16 => "base16/sagelight.min.css",
			CodeBlockTheme.SandcastleBase16 => "base16/sandcastle.min.css",
			CodeBlockTheme.SetiUiBase16 => "base16/seti-ui.min.css",
			CodeBlockTheme.ShapeshifterBase16 => "base16/shapeshifter.min.css",
			CodeBlockTheme.SilkDarkBase16 => "base16/silk-dark.min.css",
			CodeBlockTheme.SilkLightBase16 => "base16/silk-light.min.css",
			CodeBlockTheme.SnazzyBase16 => "base16/snazzy.min.css",
			CodeBlockTheme.SolarFlareLightBase16 => "base16/solar-flare-light.min.css",
			CodeBlockTheme.SolarFlareBase16 => "base16/solar-flare.min.css",
			CodeBlockTheme.SolarizedDarkBase16 => "base16/solarized-dark.min.css",
			CodeBlockTheme.SolarizedLightBase16 => "base16/solarized-light.min.css",
			CodeBlockTheme.SpacemacsBase16 => "base16/spacemacs.min.css",
			CodeBlockTheme.SummercampBase16 => "base16/summercamp.min.css",
			CodeBlockTheme.SummerfruitDarkBase16 => "base16/summerfruit-dark.min.css",
			CodeBlockTheme.SummerfruitLightBase16 => "base16/summerfruit-light.min.css",
			CodeBlockTheme.SynthMidnightTerminalDarkBase16 => "base16/synth-midnight-terminal-dark.min.css",
			CodeBlockTheme.SynthMidnightTerminalLightBase16 => "base16/synth-midnight-terminal-light.min.css",
			CodeBlockTheme.T3024Base16 => "base16/t3024.min.css",
			CodeBlockTheme.TangoBase16 => "base16/tango.min.css",
			CodeBlockTheme.TenderBase16 => "base16/tender.min.css",
			CodeBlockTheme.TomorrowNightBase16 => "base16/tomorrow-night.min.css",
			CodeBlockTheme.TomorrowBase16 => "base16/tomorrow.min.css",
			CodeBlockTheme.TwilightBase16 => "base16/twilight.min.css",
			CodeBlockTheme.UnikittyDarkBase16 => "base16/unikitty-dark.min.css",
			CodeBlockTheme.UnikittyLightBase16 => "base16/unikitty-light.min.css",
			CodeBlockTheme.VulcanBase16 => "base16/vulcan.min.css",
			CodeBlockTheme.Windows10LightBase16 => "base16/windows-10-light.min.css",
			CodeBlockTheme.Windows10Base16 => "base16/windows-10.min.css",
			CodeBlockTheme.Windows95LightBase16 => "base16/windows-95-light.min.css",
			CodeBlockTheme.Windows95Base16 => "base16/windows-95.min.css",
			CodeBlockTheme.WindowsHighContrastLightBase16 => "base16/windows-high-contrast-light.min.css",
			CodeBlockTheme.WindowsHighContrastBase16 => "base16/windows-high-contrast.min.css",
			CodeBlockTheme.WindowsNtLightBase16 => "base16/windows-nt-light.min.css",
			CodeBlockTheme.WindowsNtBase16 => "base16/windows-nt.min.css",
			CodeBlockTheme.WoodlandBase16 => "base16/woodland.min.css",
			CodeBlockTheme.XcodeDuskBase16 => "base16/xcode-dusk.min.css",
			CodeBlockTheme.ZenburnBase16 => "base16/zenburn.min.css",
			_ => string.Empty
		};
}