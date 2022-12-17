# TehGM's C# Utility Libraries - ASP.NET Core
[![Nuget](https://img.shields.io/nuget/v/TehGM.Utilities.AspNetCore)](https://www.nuget.org/packages/TehGM.Utilities.AspNetCore/)  [![GitHub top language](https://img.shields.io/github/languages/top/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities) [![GitHub](https://img.shields.io/github/license/TehGM/TehGM.Utilities)](LICENSE) [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/TehGM/TehGM.Utilities/.NET%20Build)](https://github.com/TehGM/TehGM.Utilities/actions) [![GitHub issues](https://img.shields.io/github/issues/TehGM/TehGM.Utilities)](https://github.com/TehGM/TehGM.Utilities/issues)

This library contains a of general utilities for ASP.NET Core.

- **ByteRouteConstraint** - a route constraint requiring route value to be a valid `byte`.
- **SbyteRouteConstraint** - a route constraint requiring route value to be a valid `sbyte`.
- **ShortRouteConstraint** - a route constraint requiring route value to be a valid `short`.
- **UintRouteConstraint** - a route constraint requiring route value to be a valid `uint`.
- **UlongRouteConstraint** - a route constraint requiring route value to be a valid `ulong`.
- **UshortRouteConstraint** - a route constraint requiring route value to be a valid `ushort`.

### Usage
When configuring services, configure routing by adding your selected route constraints:
```csharp
services.AddRouting(options => 
{
	options.ConstraintMap.Add("byte", typeof(TehGM.Utilities.AspNetCore.Routing.Constraints.ByteRouteConstraint));
	options.ConstraintMap.Add("sbyte", typeof(TehGM.Utilities.AspNetCore.Routing.Constraints.SbyteRouteConstraint));
	options.ConstraintMap.Add("short", typeof(TehGM.Utilities.AspNetCore.Routing.Constraints.ShortRouteConstraint));
	options.ConstraintMap.Add("uint", typeof(TehGM.Utilities.AspNetCore.Routing.Constraints.UintRouteConstraint));
	options.ConstraintMap.Add("ulong", typeof(TehGM.Utilities.AspNetCore.Routing.Constraints.UlongRouteConstraint));
	options.ConstraintMap.Add("ushort", typeof(TehGM.Utilities.AspNetCore.Routing.Constraints.UshortRouteConstraint));
});
```

## License
Copyright (c) 2022 TehGM 

Licensed under [MIT License](../LICENSE).