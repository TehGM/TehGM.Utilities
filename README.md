# TehGM's C# Utility Libraries
[![GitHub top language](https://img.shields.io/github/languages/top/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities) [![GitHub](https://img.shields.io/github/license/TehGM/TehGM.Utilities)](LICENSE) [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/TehGM/TehGM.Utilities/.NET%20Build)](https://github.com/TehGM/TehGM.Utilities/actions) [![GitHub issues](https://img.shields.io/github/issues/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities/issues)

This solution contains utility libraries that I created to make features easy to re-use in multiple projects.

## Installation
Install `TehGM.Utilities` using your NuGet package manager.

Alternatively, you can install selected libraries individually.

### Requirements
The library targets [.NET Standard 2.0](https://docs.microsoft.com/en-gb/dotnet/standard/net-standard), and therefore works with .NET Core 2.0+, .NET Framework 4.6.1+ and .NET 5+.

## Included Libraries
This project currently contains following libraries:

- [TehGM.Utilities.UniqueID](TehGM.Utilities.UniqueID) - includes types and methods for generating unique IDs.
- [TehGM.Utilities.Logging](TehGM.Utilities.Logging) - includes helpers for logging.
- [TehGM.Utilities.Randomization](TehGM.Utilities.Randomization) - utilities for generating random values.
- [TehGM.Utilities.Time](TehGM.Utilities.Time) - time conversion and formatting utilities.
- [TehGM.Utilities.Validation](TehGM.Utilities.Validation) - type and data validation utilities.

More libraries might be added as needed, when needed (by me)... or when I feel like it.

### JSON.NET Support
Some of the libraries might have an additional package, which extends their functionality by adding JSON.NET support (such as converters).  
These libraries need to be installed separately. This is because they depend on Newtonsoft.Json package, which might only pollute projects that don't make use of it

- [TehGM.Utilities.Time.JsonNet](JsonNet/TehGM.Utilities.Time.JsonNet) - JSON.NET support for [TehGM.Utilities.Time](TehGM.Utilities.Time).

## Contributing
In case you want to report a bug or request a new feature, open a new [Issue](https://github.com/TehGM/TehGM.Utilities/issues).

If you want to contribute a patch or update, fork repository, implement the change, and open a pull request.

## License
Copyright (c) 2022 TehGM 

Licensed under [MIT License](LICENSE).