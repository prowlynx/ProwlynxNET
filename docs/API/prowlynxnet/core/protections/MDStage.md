# MDStage `Public class`

## Description
Base of all stages that change metadata or a PEImage being written.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Protections
  ProwlynxNET.Core.Protections.MDStage[[MDStage]]
  class ProwlynxNET.Core.Protections.MDStage abstractStyle;
  ProwlynxNET.Core.Protections.ProtectionStageBase[[ProtectionStageBase]]
  class ProwlynxNET.Core.Protections.ProtectionStageBase abstractStyle;
  end
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
ProwlynxNET.Core.Models.Stages.IMDStage --> ProwlynxNET.Core.Protections.MDStage
ProwlynxNET.Core.Models.IProtectionStage --> ProwlynxNET.Core.Models.Stages.IMDStage
ProwlynxNET.Core.Models.IProtection --> ProwlynxNET.Core.Models.IProtectionStage
ProwlynxNET.Core.Protections.ProtectionStageBase --> ProwlynxNET.Core.Protections.MDStage
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `void` | [`Process`](#process)([`ObfuscationTask`](../ObfuscationTask.md) t, `IPEImage` peImage)<br>Process the stage. |

## Details
### Summary
Base of all stages that change metadata or a PEImage being written.

### Inheritance
 - [
`IMDStage`
](../models/stages/IMDStage.md)
 - [
`IProtectionStage`
](../models/IProtectionStage.md)
 - [
`IProtection`
](../models/IProtection.md)
 - [
`ProtectionStageBase`
](./ProtectionStageBase.md)

### Constructors
#### MDStage
[*Source code*](https://github.com///blob//ProwlynxNET.Core/Protections/MDStage.cs#L25)
```csharp
protected MDStage(IProtection parentProtection)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| [`IProtection`](../models/IProtection.md) | parentProtection | The parent protection. |

##### Summary
Create a new [MDStage](prowlynxnet/core/protections/MDStage.md) owned by the specified protection.

### Methods
#### Process
```csharp
public abstract void Process(ObfuscationTask t, IPEImage peImage)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| [`ObfuscationTask`](../ObfuscationTask.md) | t | The task, noting that Module is inaccessible (null). |
| `IPEImage` | peImage | The PE Image with DotNetDirectory. |

##### Summary
Process the stage.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
