# IInjectionService `Public interface`

## Description
A service that provides the ability to copy types and methods into another module.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Models.Services
  ProwlynxNET.Core.Models.Services.IInjectionService[[IInjectionService]]
  class ProwlynxNET.Core.Models.Services.IInjectionService interfaceStyle;
  end
  subgraph ProwlynxNET.Core.Models
  ProwlynxNET.Core.Models.IService[[IService]]
  class ProwlynxNET.Core.Models.IService interfaceStyle;
  end
ProwlynxNET.Core.Models.IService --> ProwlynxNET.Core.Models.Services.IInjectionService
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `IList`&lt;`TypeDefinition`&gt; | [`Inject`](#inject-13)(`...`)<br>Injects the specified Module to another module.<br>                Does NOT add the result to the module. |

## Details
### Summary
A service that provides the ability to copy types and methods into another module.

### Inheritance
 - [
`IService`
](../IService.md)

### Methods
#### Inject [1/3]
```csharp
public IList<TypeDefinition> Inject(ModuleDefinition injectModule, ModuleDefinition target)
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
```csharp
public T Inject<T>(T def, ModuleDefinition target)
where T : IMemberDefinition
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `T` | def |   |
| `ModuleDefinition` | target |   |

#### Inject [3/3]
```csharp
public IList<T> Inject<T>(IEnumerable<T> def, ModuleDefinition target)
where T : IMemberDefinition
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `IEnumerable`&lt;`T`&gt; | def |   |
| `ModuleDefinition` | target |   |

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
