# ArgumentDictionary `Public class`

## Description
A read-only dictionary for arguments.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Services.Argument
  ProwlynxNET.Core.Services.Argument.ArgumentDictionary[[ArgumentDictionary]]
  end
  subgraph System.Collections.ObjectModel
System.Collections.ObjectModel.ReadOnlyDictionary_2[[ReadOnlyDictionary]]
  end
System.Collections.ObjectModel.ReadOnlyDictionary_2 --> ProwlynxNET.Core.Services.Argument.ArgumentDictionary
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| `string` | [`Item`](#item) | `get, set` |

## Details
### Summary
A read-only dictionary for arguments.

### Inheritance
 - `ReadOnlyDictionary`&lt;`string`, `string`&gt;

### Constructors
#### ArgumentDictionary
[*Source code*](https://github.com///blob//ProwlynxNET.Core/Services/Argument/ArgumentDictionary.cs#L34)
```csharp
public ArgumentDictionary(IDictionary<string, string> dictionary)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `IDictionary`&lt;`string`, `string`&gt; | dictionary |   |

### Properties
#### Item
```csharp
public string Item { get; set; }
```

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
