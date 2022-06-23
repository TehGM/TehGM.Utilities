# TehGM's C# Utility Libraries - Logging
[![Nuget](https://img.shields.io/nuget/v/TehGM.Utilities.Logging)](https://www.nuget.org/packages/TehGM.Utilities.Logging/) [![GitHub top language](https://img.shields.io/github/languages/top/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities) [![GitHub](https://img.shields.io/github/license/TehGM/TehGM.Utilities)](LICENSE) [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/TehGM/TehGM.Utilities/.NET%20Build)](https://github.com/TehGM/TehGM.Utilities/actions) [![GitHub issues](https://img.shields.io/github/issues/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities/issues)

This library contains a set of types, wrappers and methods to make logging easier.

This library depends on [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions/), and should be compatible with any major logging library.

- Exception logging - utility class that simply logs given exception and returns true - this is to be used with `when` keyword to [preserve log context](https://stackoverflow.com/questions/71519014/how-to-preserve-log-scopes-for-unhandled-exceptions).

## License
Copyright (c) 2022 TehGM 

Licensed under [MIT License](../LICENSE).