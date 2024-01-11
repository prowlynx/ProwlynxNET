# Stage `Public class`

## Description
Base of all regular stages that modify methods/modules/etc before writing beings.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Protections
  ProwlynxNET.Core.Protections.Stage[[Stage]]
  class ProwlynxNET.Core.Protections.Stage abstractStyle;
  ProwlynxNET.Core.Protections.ProtectionStageBase[[ProtectionStageBase]]
  class ProwlynxNET.Core.Protections.ProtectionStageBase abstractStyle;
  end
  subgraph ProwlynxNET.Core.Models.Stages
  ProwlynxNET.Core.Models.Stages.IStage[[IStage]]
  class ProwlynxNET.Core.Models.Stages.IStage interfaceStyle;
  end
  subgraph ProwlynxNET.Core.Models
  ProwlynxNET.Core.Models.IProtectionStage[[IProtectionStage]]
  class ProwlynxNET.Core.Models.IProtectionStage interfaceStyle;
  ProwlynxNET.Core.Models.IProtection[[IProtection]]
  class ProwlynxNET.Core.Models.IProtection interfaceStyle;
  end
ProwlynxNET.Core.Models.Stages.IStage --> ProwlynxNET.Core.Protections.Stage
ProwlynxNET.Core.Models.IProtectionStage --> ProwlynxNET.Core.Models.Stages.IStage
ProwlynxNET.Core.Models.IProtection --> ProwlynxNET.Core.Models.IProtectionStage
ProwlynxNET.Core.Protections.ProtectionStageBase --> ProwlynxNET.Core.Protections.Stage
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `void` | [`Process`](#process)([`ObfuscationTask`](../ObfuscationTask.md) t)<br>Process the stage. |

## Details
### Summary
Base of all regular stages that modify methods/modules/etc before writing beings.

### Inheritance
 - [
`IStage`
](../models/stages/IStage.md)
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
#### Stage
[*Source code*](https://github.com///blob//ProwlynxNET.Core/Protections/Stage.cs#L23)
```csharp
protected Stage(IProtection parentProtection)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| [`IProtection`](../models/IProtection.md) | parentProtection | The parent protection. |

##### Summary
Create a new [Stage](prowlynxnet/core/protections/Stage.md) owned by the specified protection.

### Methods
#### Process
```csharp
public abstract void Process(ObfuscationTask t)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| [`ObfuscationTask`](../ObfuscationTask.md) | t | The obfuscation task currently being processed |

##### Summary
Process the stage.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
