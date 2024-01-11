# DictionaryExtensions `Public class`

## Description
A collection of extensions for dictionaries.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Extensions
  ProwlynxNET.Core.Extensions.DictionaryExtensions[[DictionaryExtensions]]
  end
```

## Members
### Methods
#### Public Static methods
| Returns | Name |
| --- | --- |
| `Dictionary`&lt;`TKey`, `TValue`&gt; | [`AddOrUpdate`](#addorupdate)(`Dictionary`&lt;`TKey`, `TValue`&gt; current, `Dictionary`&lt;`TKey`, `TValue`&gt; additional) |

## Details
### Summary
A collection of extensions for dictionaries.

### Methods
#### AddOrUpdate
[*Source code*](https://github.com///blob//ProwlynxNET.Core/Extensions/DictionaryExtensions.cs#L26)
```csharp
public static Dictionary<TKey, TValue> AddOrUpdate<TKey, TValue>(Dictionary<TKey, TValue> current, Dictionary<TKey, TValue> additional)
where TKey : 
where TValue : 
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `Dictionary`&lt;`TKey`, `TValue`&gt; | current |   |
| `Dictionary`&lt;`TKey`, `TValue`&gt; | additional |   |

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
