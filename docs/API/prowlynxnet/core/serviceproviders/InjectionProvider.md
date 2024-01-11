# InjectionProvider `Public class`

## Description
The injection provider for [InjectorService](../services/injector/InjectorService.md) .

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.ServiceProviders
  ProwlynxNET.Core.ServiceProviders.InjectionProvider[[InjectionProvider]]
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
ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1 --> ProwlynxNET.Core.ServiceProviders.InjectionProvider
```

## Details
### Summary
The injection provider for [InjectorService](../services/injector/InjectorService.md) .

### Inheritance
 - [`ServiceProviderBase`](./ServiceProviderBaseT.md)&lt;[`IInjectionService`](../models/services/IInjectionService.md)&gt;

### Constructors
#### InjectionProvider
[*Source code*](https://github.com///blob//ProwlynxNET.Core/ServiceProviders/InjectionProvider.cs#L21)
```csharp
public InjectionProvider()
```
##### Summary
Create a new injection provider adding a single [InjectorService](../services/injector/InjectorService.md) service.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
