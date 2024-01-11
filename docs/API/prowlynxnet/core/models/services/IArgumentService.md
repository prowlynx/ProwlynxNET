# IArgumentService `Public interface`

## Description
The argument service used by a single [IProtection](../IProtection.md) to check for arguments to alter the way in which a [IProtection](../IProtection.md) would run.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Models.Services
  ProwlynxNET.Core.Models.Services.IArgumentService[[IArgumentService]]
  class ProwlynxNET.Core.Models.Services.IArgumentService interfaceStyle;
  end
  subgraph ProwlynxNET.Core.Models
  ProwlynxNET.Core.Models.IService[[IService]]
  class ProwlynxNET.Core.Models.IService interfaceStyle;
  end
ProwlynxNET.Core.Models.IService --> ProwlynxNET.Core.Models.Services.IArgumentService
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| `NameValueCollection` | [`Arguments`](#arguments)<br>The list of arguments for a particular [IProtection](../IProtection.md) | `get` |
| `string` | [`Item`](#item) | `get, set` |

### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `void` | [`Add`](#add)(`string` name, `string` value)<br>Add an argument to the current argument service. |
| `bool` | [`Has`](#has)(`string` name)<br>Check whether the argument name exists. |

## Details
### Summary
The argument service used by a single [IProtection](../IProtection.md) to check for arguments to alter the way in which a [IProtection](../IProtection.md) would run.

### Inheritance
 - [
`IService`
](../IService.md)

### Methods
#### Add
```csharp
public void Add(string name, string value)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | name | The name of the argument (key) |
| `string` | value | The value of the argument |

##### Summary
Add an argument to the current argument service.

#### Has
```csharp
public bool Has(string name)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | name | The name of the argument (key) passed in when added. |

##### Summary
Check whether the argument name exists.

##### Returns
Whether or not the argument exists.

### Properties
#### Arguments
```csharp
public NameValueCollection Arguments { get; }
```
##### Summary
The list of arguments for a particular [IProtection](../IProtection.md)

#### Item
```csharp
public string Item { get; set; }
```

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
