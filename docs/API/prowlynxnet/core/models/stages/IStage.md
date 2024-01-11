# IStage `Public interface`

## Description
A protection stage that does not relate to writing. Most protections will have at least one of this stage type.

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
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
ProwlynxNET.Core.Models.IProtectionStage --> ProwlynxNET.Core.Models.Stages.IStage
ProwlynxNET.Core.Models.IProtection --> ProwlynxNET.Core.Models.IProtectionStage
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `void` | [`Process`](#process)([`ObfuscationTask`](../../ObfuscationTask.md) t)<br>Process the stage. |

## Details
### Summary
A protection stage that does not relate to writing. Most protections will have at least one of this stage type.

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
public void Process(ObfuscationTask t)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| [`ObfuscationTask`](../../ObfuscationTask.md) | t | The obfuscation task currently being processed |

##### Summary
Process the stage.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
