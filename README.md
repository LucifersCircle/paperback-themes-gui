# Paperback Themes GUI
## _Theming GUI for the iOS Paperback app_

Paperback:
 - [Github](https://github.com/Paperback-iOS/app)
 - [Website](https://paperback.moe/)
 - [Themes Github](https://github.com/Celarye/paperback-themes)

Paperback Themes GUI is a graphical user interface to help you visualize your Paperback themes colors and save theme files.
Created with inspiration from [Paperback Themes](https://github.com/Celarye/paperback-themes) and guidance from [Celarye](https://github.com/Celarye).

## Images
![Default Theme](./images/defaulttheme.png)
![Custom Theme](./images/customtheme.png)

## Features
 - Open theme files
 - View/Edit theme colors and alphas
 - Save theme files
 - Optional save HEXA file
 - Optional save RGBA file

Optional files may be required if you plan on submitting your theme to the official themes repository.

## Tech
Paperback Themes GUI uses these projects to work properly:

- [Newtonsoft.Json] - Popular high-performance JSON framework for .NET
- [Visual Studio (2022)] - The most comprehensive IDE for .NET and C++ developers on Windows.
- [.NET Framework 4.7.2] - .NET Framework is a Windows-only version of .NET for building client and server applications.

And of course Paperback Themes GUI itself is open source with a [public repository](https://github.com/LucifersCircle/paperback-themes-gui) on GitHub.

## Installation

Paperback Themes GUI requires [.NET 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) or higher to run.

A Github [Workflow](https://github.com/LucifersCircle/paperback-themes-gui/blob/master/.github/workflows/build.yml) is used to build and publish the release files to the Releases tab.

Download "paperback-themes-gui.zip" from the [Releases](https://github.com/LucifersCircle/paperback-themes-gui/releases) tab.
The zip structure will look like this:
 - paperback-themes-gui.zip
    - Newtonsoft.Json.dll
    - pbtgui.exe

Extract the zip archive to its own directory.
Double click "pbtgui.exe" to start the applicaton.


## Development

Want to contribute? Great!

All [pull requests](https://github.com/LucifersCircle/paperback-themes-gui/pulls) are welcome!

## Building from source

Download the [project source](https://github.com/LucifersCircle/paperback-themes-gui/archive/refs/heads/master.zip) or attain it by other means.

Unzip the source to a new directory.

__(Using Visual Studio)__
Double click "pbtgui.sln" to open the solution in the Visual Studio solution explorer.
Build the project with the run button.

__(Using Command Line)__
Requires [MSBuild](https://learn.microsoft.com/en-us/visualstudio/msbuild/walkthrough-using-msbuild?view=vs-2022#install-msbuild)
CD to the project directory.
run `msbuild /t:build /p:Configuration=Release src/pbtgui.sln`
executable will output to ./bin/Release/

## License

This project is licensed under the [GNU General Public License v3.0](https://www.gnu.org/licenses/gpl-3.0.txt).
   
   [Newtonsoft.Json]: <https://github.com/JamesNK/Newtonsoft.Json>
   [Visual Studio (2022)]: <https://visualstudio.microsoft.com/downloads/>
   [.NET Framework 4.7.2]: <https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472>