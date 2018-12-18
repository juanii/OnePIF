# OnePIF

OnePIF is a [KeePass](https://keepass.info/) 2.x plugin to import 1Password Interchange Format (1pif) files.

This plugin was made using Dmitry Wolf's [1P2KeePass](https://github.com/diimdeep/1P2KeePass) as a guide and example. There are copy-pasted bits of 1P2KeePass code I was lazy to rewrite myself.

## Features and support

### Brief list of features

* The plugin imports:
  - Most item types available in 1Password 6: Logins, Secure Notes, Credit Cards, Identities, Passwords, Bank Accounts, Databases, Driver Licenses, Email Accounts, Memberships, Outdoor Licenses, Passports, Reward Programs, Servers, Social Security Numbers, Software Licenses, Wireless Routers, User-defined Folders.<sup id="a1">[1](#f1)</sup>
  - All template fields, web form fields and user-defined fields.
  - Previously used passwords list.
  - User-defined tags.
  - Favorite flag (as a tag).
  - Trashed items.
  - Custom user-provided icons<sup id="a2">[2](#f2)</sup> (not the rich icons provided by AgileBits).
* Organizes items into the standard 1Password categories or using preexistent user-defined folders.
* Proper handling of line endings in multiline fields.
* Customizable date formats: ISO 8601 or user locale.

### (Un)tested and (un)supported file formats and platforms

* The plugin was tested using files exported by 1Password 6 standalone for macOS. All item types (from the above list of supported items) and template fields were tested.
  - It was *not* tested with 1Password for Families/Teams/Businesses vaults.<sup id="a3">[3](#f3)</sup>
  - It does *not* support 1pif files exported from 1Password 4 for MS-Windows.
* The plugin was tested with KeePass 2.x running on MS-Windows 10 and Ubuntu 18.04.

### What's next

I expect to keep fixing bugs, adding some features and broadening support for more variants of 1pif files. Here are some of the plans, in no particular order:

* Better mapping of 1Password fields to standard KeePass fields.
* Support 1pif files exported from 1Password 4 for MS-Windows.
* Log/summary of import errors.
* Import attachments.

## Download and installation

You can get the latest release from the [Releases](https://github.com/juanii/OnePIF/releases/latest) page. To install, unpack the archive and copy its contents to the KeePass Plugins directory.

If you're using KeePass 2.08 or older, you'll have to build the DLL version of the plugin. See next section for instructions.

## Building and debugging

### Prerequisites

Before building the plugin you must either download and place a copy of KeePass software in the `KeePass` directory inside the solution directory, or adjust the paths all over the projects<sup id="a4">[4](#f4)</sup> to point to your current KeePass installation.

The plugin depends on [Newtonsoft Json.NET](https://www.newtonsoft.com/). If you're using Visual Studio, enable the NuGet automatic download and installation of missing packages in `Tools > Options > NuGet Package Manager > General`. If you're using MSBuild use the `nuget restore` command to restore dependencies before building.

### Building the PLGX version

You don't have to actually compile anything, just build the `PackagePLGX` project which consists of only a few post-build commands. KeePass will compile the plugin code upon first load of the PLGX package.

### Building the DLL version

Build the `OnePIF` project and you're ready to go.

If you're copying this version to your KeePass installation path, don't forget to copy the dependecies and localization satellite DLLs. Copy the files to the _root_ KeePass installation path and not inside the Plugins directory. If KeePass finds the satellite DLLs in the Plugins directory, it will try (and fail) to load them as plugins. I still couldn't find an easy way to embed the localized resources in the main DLL.

### Debugging

To debug the plugin, configure `OnePIF` project Debug settings to start the KeePass executable.

## Disclaimer

This software is provided as-is without any warranty of any kind. I take no responsability or liabiity for any damage it may cause. If it breaks your data you can keep its pieces.

**Vaults often contain very sensitive information. Thoroughly check imported data for completeness and correctess before deleting the original files.**

<b id="f1">1</b> Smart Folders are not supported since KeePass seems to lack a similar feature. [↩](#a1)

<b id="f2">2</b> Only icons saved as image formats supported by .NET `System.Drawing.Bitmap` class, namely: BMP, GIF, EXIF, JPEG, PNG and TIFF. [↩](#a2)

<b id="f3">3</b> Sample 1pif files completely or partially failing to be imported are welcome to expand support. **If they're from a real vault, don't forget to redact private information.** [↩](#a3)

<b id="f4">4</b> Currently the post-build event in the PackagePLGX project, the build output path and the reference to the KeePass executable in the OnePIF project are dependent on the KeePass installation path. [↩](#a5)
