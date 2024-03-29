# InjectorService `Public class`

## Description
The primary injector for injecting types into a target module.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Services.Injector
  ProwlynxNET.Core.Services.Injector.InjectorService[[InjectorService]]
  end
  subgraph ProwlynxNET.Core.Models.Services
  ProwlynxNET.Core.Models.Services.IInjectionService[[IInjectionService]]
  class ProwlynxNET.Core.Models.Services.IInjectionService interfaceStyle;
  end
  subgraph ProwlynxNET.Core.Models
  ProwlynxNET.Core.Models.IService[[IService]]
  class ProwlynxNET.Core.Models.IService interfaceStyle;
  end
ProwlynxNET.Core.Models.Services.IInjectionService --> ProwlynxNET.Core.Services.Injector.InjectorService
ProwlynxNET.Core.Models.IService --> ProwlynxNET.Core.Models.Services.IInjectionService
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| `string` | [`Description`](#description)<br>Description of the service. | `get` |
| `string` | [`Name`](#name)<br>The unique name of the service. | `get` |

### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `IList`&lt;`TypeDefinition`&gt; | [`Inject`](#inject-13)(`...`)<br>Injects the specified Module to another module.<br>                Does NOT add the result to the module. |

## Details
### Summary
The primary injector for injecting types into a target module.

### Inheritance
 - [
`IInjectionService`
](../../models/services/IInjectionService.md)
 - [
`IService`
](../../models/IService.md)

### Constructors
#### InjectorService
```csharp
public InjectorService()
```

### Methods
#### Inject [1/3]
[*Source code*](https://github.com///blob//ProwlynxNET.Core/Services/Injector/InjectorService.cs#L28)
```csharp
public virtual IList<TypeDefinition> Inject(ModuleDefinition injectModule, ModuleDefinition target)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `ModuleDefinition` | injectModule | The source ModuleDefMD. |
| `ModuleDefinition` | target | The target module. |

##### Summary
Injects the specified Module to another module.
                Does NOT add the result to the module.

#### Inject [2/3]
[*Source code*](https://github.com///blob//ProwlynxNET.Core/Services/Injector/InjectorService.cs#L44)
```csharp
public virtual T Inject<T>(T def, ModuleDefinition target)
where T : IMemberDefinition
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `T` | def |   |
| `ModuleDefinition` | target |   |

#### Inject [3/3]
[*Source code*](https://github.com///blob//ProwlynxNET.Core/Services/Injector/InjectorService.cs#L53)
```csharp
public virtual IList<T> Inject<T>(IEnumerable<T> def, ModuleDefinition target)
where T : IMemberDefinition
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `IEnumerable`&lt;`T`&gt; | def |   |
| `ModuleDefinition` | target |   |

### Properties
#### Name
```csharp
public virtual string Name { get; }
```
##### Summary
The unique name of the service.

#### Description
```csharp
public virtual string Description { get; }
```
##### Summary
Description of the service.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
