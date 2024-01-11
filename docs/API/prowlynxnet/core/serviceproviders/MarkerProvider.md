# MarkerProvider `Public class`

## Description
The marker provider for the [MarkerService](../services/marker/MarkerService.md) .

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.ServiceProviders
  ProwlynxNET.Core.ServiceProviders.MarkerProvider[[MarkerProvider]]
  ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1[[ServiceProviderBase< T >]]
  class ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1 abstractStyle;
  ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1T((T));
  ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1 -- where --o ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1T
ProwlynxNET.Core.Models.IService --> ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1T

  end
  subgraph ProwlynxNET.Core.Models
  ProwlynxNET.Core.Models.IService[[IService]]
  class ProwlynxNET.Core.Models.IService interfaceStyle;
  end
ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1 --> ProwlynxNET.Core.ServiceProviders.MarkerProvider
```

## Details
### Summary
The marker provider for the [MarkerService](../services/marker/MarkerService.md) .

### Inheritance
 - [`ServiceProviderBase`](./ServiceProviderBaseT.md)&lt;[`IMarkerService`](../models/services/IMarkerService.md)&gt;

### Constructors
#### MarkerProvider
[*Source code*](https://github.com///blob//ProwlynxNET.Core/ServiceProviders/MarkerProvider.cs#L21)
```csharp
public MarkerProvider()
```
##### Summary
Create a new marker provider adding a single [MarkerService](../services/marker/MarkerService.md) service.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
