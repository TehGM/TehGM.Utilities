# TehGM's C# Utility Libraries
[![GitHub top language](https://img.shields.io/github/languages/top/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities) [![GitHub](https://img.shields.io/github/license/TehGM/TehGM.Utilities)](LICENSE) [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/TehGM/TehGM.Utilities/.NET%20Build)](https://github.com/TehGM/TehGM.Utilities/actions) [![GitHub issues](https://img.shields.io/github/issues/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities/issues)

This solution contains utility libraries that I created to make features easy to re-use in multiple projects.

#### Work in Progress
This set of libraries is currently Work in Progress - and it might stay in this state indefinitely.  
These libraries are designed primarily for personal use, so I do not guarantee that updates don't include breaking changes.  
Keep this in mind if upgrading these libraries for any version before `1.0.0`.

## Included Libraries
This NuGet package currently contains following libraries:

- ***TehGM.Utilities.UniqueID*** - includes types and methods for generating unique IDs.
- ***TehGM.Utilities.Logging*** - includes helpers for logging.
- ***TehGM.Utilities.Randomization*** - utilities for generating random values.
- ***TehGM.Utilities.Time*** - time conversion and formatting utilities.
- ***TehGM.Utilities.Validation*** - type and data validation utilities.

More libraries might be added as needed, when needed (by me)... or when I feel like it.

### JSON.NET Support
Some of the libraries might have an additional package, which extends their functionality by adding JSON.NET support (such as converters).  
These libraries need to be installed separately. This is because they depend on Newtonsoft.Json package, which might only pollute projects that don't make use of it

- ***TehGM.Utilities.Time.JsonNet*** - JSON.NET support for **TehGM.Utilities.Time**.

## Source Repository
TehGM.Utilities is open source, with code hosted on [GitHub](https://github.com/TehGM/TehGM.Utilities).