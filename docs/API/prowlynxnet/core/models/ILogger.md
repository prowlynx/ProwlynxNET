# ILogger `Public interface`

## Description
A logger for a [ObfuscationTask](../ObfuscationTask.md) .

## Diagram
```mermaid
  flowchart LR
  classDef interfaceStyle stroke-dasharray: 5 5;
  classDef abstractStyle stroke-width:4px
  subgraph ProwlynxNET.Core.Models
  ProwlynxNET.Core.Models.ILogger[[ILogger]]
  class ProwlynxNET.Core.Models.ILogger interfaceStyle;
  end
```

## Members
### Methods
#### Public  methods
| Returns | Name |
| --- | --- |
| `void` | [`LogDebug`](#logdebug)(`string` message)<br>Log debug message. |
| `void` | [`LogError`](#logerror)(`string` message)<br>Log an error. |
| `void` | [`LogInfo`](#loginfo)(`string` message)<br>Log information message. |
| `void` | [`LogSuccess`](#logsuccess)(`string` message)<br>Log a success message. |
| `void` | [`LogWarn`](#logwarn)(`string` message)<br>Log a warning. |

## Details
### Summary
A logger for a [ObfuscationTask](../ObfuscationTask.md) .

### Methods
#### LogDebug
```csharp
public void LogDebug(string message)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | message | The message to log. |

##### Summary
Log debug message.

#### LogInfo
```csharp
public void LogInfo(string message)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | message | The message to log. |

##### Summary
Log information message.

#### LogError
```csharp
public void LogError(string message)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | message | The message to log. |

##### Summary
Log an error.

#### LogSuccess
```csharp
public void LogSuccess(string message)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | message | The message to log. |

##### Summary
Log a success message.

#### LogWarn
```csharp
public void LogWarn(string message)
```
##### Arguments
| Type | Name | Description |
| --- | --- | --- |
| `string` | message | The message to log. |

##### Summary
Log a warning.

*Generated with* [*ModularDoc*](https://github.com/hailstorm75/ModularDoc)
