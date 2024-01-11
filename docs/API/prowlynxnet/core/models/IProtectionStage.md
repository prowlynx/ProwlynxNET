# IProtectionStage `Public interface`

## Description
A protection stage that is a part of a protection.
                Protection stages can also have sub-stages so protection stage inherits from [IProtection](./IProtection.md)

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Models
  ProwlynxNET.Core.Models.IProtectionStage[[IProtectionStage]]
  class ProwlynxNET.Core.Models.IProtectionStage interfaceStyle;
  ProwlynxNET.Core.Models.IProtection[[IProtection]]
  class ProwlynxNET.Core.Models.IProtection interfaceStyle;
  end
ProwlynxNET.Core.Models.IProtection --> ProwlynxNET.Core.Models.IProtectionStage
```

## Members
### Properties
#### Public  properties
| Type | Name | Methods |
| --- | --- | --- |
| [`IProtection`](./IProtection.md) | [`ParentProtection`](#parentprotection)<br>The protection that is directly the owner of the stage. | `get, set` |
| `int` | [`StagePriority`](#stagepriority)<br>The priority for the stage. A lower number is a higher priority. | `get, set` |

## Details
### Summary
A protection stage that is a part of a protection.
                Protection stages can also have sub-stages so protection stage inherits from [IProtection](./IProtection.md)

### Inheritance
 - [
`IProtection`
](./IProtection.md)

### Properties
#### StagePriority
```csharp
public int StagePriority { get; set; }
```
##### Summary
The priority for the stage. A lower number is a higher priority.

#### ParentProtection
```csharp
public IProtection ParentProtection { get; set; }
```
##### Summary
The protection that is directly the owner of the stage.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
