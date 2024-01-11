# ArgumentProvider `Public class`

## Description
The provider for protection arguments.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.ServiceProviders
  ProwlynxNET.Core.ServiceProviders.ArgumentProvider[[ArgumentProvider]]
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
ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1 --> ProwlynxNET.Core.ServiceProviders.ArgumentProvider
```

## Details
### Summary
The provider for protection arguments.

### Inheritance
 - [`ServiceProviderBase`](./ServiceProviderBaseT.md)&lt;[`IArgumentService`](../models/services/IArgumentService.md)&gt;

### Constructors
#### ArgumentProvider
```csharp
public ArgumentProvider()
```

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
