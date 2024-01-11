# IMDStage `Public interface`

## Description
A protection stage that relates to metadata/writing contents.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Models.Stages
  ProwlynxNET.Core.Models.Stages.IMDStage[[IMDStage]]
  class ProwlynxNET.Core.Models.Stages.IMDStage interfaceStyle;
  end
  subgraph ProwlynxNET.Core.Models
  ProwlynxNET.Core.Models.IProtectionStage[[IProtectionStage]]
  class ProwlynxNET.Core.Models.IProtectionStage interfaceStyle;
  ProwlynxNET.Core.Models.IProtection[[IProtection]]
  class ProwlynxNET.Core.Models.IProtection interfaceStyle;
  end
ProwlynxNET.Core.Models.IProtectionStage --> ProwlynxNET.Core.Models.Stages.IMDStage
ProwlynxNET.Core.Models.IProtection --> ProwlynxNET.Core.Models.IProtectionStage
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `void` | [`Process`](#process)([`ObfuscationTask`](../../ObfuscationTask.md) t, `IPEImage` peImage)<br>Process the stage. |

## Details
### Summary
A protection stage that relates to metadata/writing contents.

### Inheritance
 - [
`IProtectionStage`
](../IProtectionStage.md)
 - [
`IProtection`
](../IProtection.md)

### Methods
#### Process
```csharp
public void Process(ObfuscationTask t, IPEImage peImage)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| [`ObfuscationTask`](../../ObfuscationTask.md) | t | The task, noting that Module is inaccessible (null). |
| `IPEImage` | peImage | The PE Image with DotNetDirectory. |

##### Summary
Process the stage.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
