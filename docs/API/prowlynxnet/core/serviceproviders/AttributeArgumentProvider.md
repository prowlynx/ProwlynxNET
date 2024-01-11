# AttributeArgumentProvider `Public class`

## Description
The attribute argument provider for the [AttributeArgumentService](../services/argument/AttributeArgumentService.md) .

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.ServiceProviders
  ProwlynxNET.Core.ServiceProviders.AttributeArgumentProvider[[AttributeArgumentProvider]]
ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1[[ServiceProviderBase]]
  end
ProwlynxNET.Core.ServiceProviders.ServiceProviderBase_1 --> ProwlynxNET.Core.ServiceProviders.AttributeArgumentProvider
```

## Details
### Summary
The attribute argument provider for the [AttributeArgumentService](../services/argument/AttributeArgumentService.md) .

### Inheritance
 - `ServiceProviderBase`&lt;[`IAttributeArgumentService`](../models/services/IAttributeArgumentServiceT.md)&lt;[`ArgumentInfo`](../services/argument/ArgumentInfo.md)&gt;&gt;

### Constructors
#### AttributeArgumentProvider
[*Source code*](https://github.com///blob//ProwlynxNET.Core/ServiceProviders/AttributeArgumentProvider.cs#L21)
```csharp
public AttributeArgumentProvider()
```
##### Summary
Create a new attribute argument provider adding a single [AttributeArgumentService](../services/argument/AttributeArgumentService.md) service.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
