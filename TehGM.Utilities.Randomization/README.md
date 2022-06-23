# TehGM's C# Utility Libraries - Randomization
[![Nuget](https://img.shields.io/nuget/v/TehGM.Utilities.Randomization)](https://www.nuget.org/packages/TehGM.Utilities.Randomization/) [![GitHub top language](https://img.shields.io/github/languages/top/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities) [![GitHub](https://img.shields.io/github/license/TehGM/TehGM.Utilities)](LICENSE) [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/TehGM/TehGM.Utilities/.NET%20Build)](https://github.com/TehGM/TehGM.Utilities/actions) [![GitHub issues](https://img.shields.io/github/issues/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities/issues)

This library contains a set of types, wrappers and methods for random number generation.

- **RandomSeed** - an utility type, which is designed to provide cross application domain deterministic string to hashcode conversion.
- **IRandomizer** and **RandomizerService** - a Dependency-Injection friendly wrapper for *Random*, with additional extension methods.
- **IRandomizerProvider** and **RandomizerProvider - a Dependency-Injection friendly container and creater for **IRandomizers**.

## License
Copyright (c) 2022 TehGM 

Licensed under [MIT License](../LICENSE).