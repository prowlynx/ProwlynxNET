# CryptoProvider `Public class`

## Description
The cryptography provider.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.ServiceProviders
  ProwlynxNET.Core.ServiceProviders.CryptoProvider[[CryptoProvider]]
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
ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1 --> ProwlynxNET.Core.ServiceProviders.CryptoProvider
```

## Details
### Summary
The cryptography provider.

### Inheritance
 - [`ServiceProviderBase`](./ServiceProviderBaseT.md)&lt;[`ICryptoService`](../models/services/ICryptoService.md)&gt;

### Constructors
#### CryptoProvider
```csharp
public CryptoProvider()
```

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
