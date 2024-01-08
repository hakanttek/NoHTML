using NoHTML.SharpPage.Tags.Linking;
using NoHTML.SharpPage.Tags.Scripting;

namespace NoHTML.SharpPage.Modules.Bootstrap
{
    public static class BootstrapCDN
    {
        public static Link CSS(string? version = null) => new()
        {
            Href = $"https://cdn.jsdelivr.net/npm/bootstrap{(version is null ? "" : "@" + version)}/dist/css/bootstrap.min.css",
            Rel = "stylesheet",
            Integrity = "sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN",
            Crossorigin = "anonymous"
        };

        public static Script JS(string? version = null) => new()
        {
            Src = $"https://cdn.jsdelivr.net/npm/bootstrap{(version is null ? "" : "@" + version)}/dist/js/bootstrap.bundle.min.js",
            Rel = "stylesheet",
            Integrity = "sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL",
            Crossorigin = "anonymous"
        };
    }
}
