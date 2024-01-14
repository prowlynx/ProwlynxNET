# ProwlynxNET
An open source .NET 8 obfuscation engine for everyone.

# Features
* Simple to use, extend and run with.
* Provides a few useful services and an architecture that supports .NET and .NET Framework (legacy) obfuscation/protections.
* Dynamically (or not) loads protections from DLLs.

**Note**: Post Build Events use `xcopy` which may not be accessible on your platform. Check out the Example Protection csproj files.

# Building from Source
Executables and packages are not available to download directly. It is expected that you either:
* Build the project from source and edit it, or
* Include the project as a git submodule.

To build the project you will need to adjust the output type of ProwlynxNET project to be an executable (if you want to run the examples). Else, leave it as a library and ignore it for the most part. 

The ProwlynxNET.Core is the only real shared code that should be referenced by your project.

# Services
An obfuscator generally requires several services, why make this difficult? Let's not.

## Argument Service
This service focuses on helping out other protections with different values for parts of the module being obfuscated.

Check the [Prowlynx.NET -> Program.cs](/ProwlynxNET/Program.cs) file for an example of using this. ExampleProtection references this.

## Attribute Argument Service
This service provides the option for custom obfuscation markings on members using the `[Obfuscation]` custom attribute. 

For examples of how to use this please refer to the [TestAppCore/FW](/TestAppCore/Program.cs) projects which demonstrate the use case. Running the project once built will also produce a result from ExampleProtection showing which methods can/cannot be protected which are identified by the attribute argument service.

The attribute argument service is heavily used by the AttributeReader class inside the Marker Service.

## Marker Service
The above two services are fantastic, but they don't provide much (mainly for values), they can be difficult to work with. Hence the marker service was made.

The marker service allows you to quickly check whether a method, type, event, whatever it is that inherits from IMemberDefinition can be processed by some protection method.

You can also add marks to items to later come back and see if you can exclude or include them (perhaps you want to disable string encryption for a particular method internally...).

As always, the example protection covers this marker service extensively. Take a look.

## Injector Service
Made simple by AsmResolver's cloning abilities this allows you to quickly inject a type into a module. Incredibly popular and useful service but you can of course just use AsmResolver's cloning yourself if you like.

Check out the example protection for how to deal with .NET and .NET Framework to make sure the two are kept distinctly separate. 

## Cryptography Services
Simple cryptography services such as Aes and Hashing (SHA1, 256) have been implemented and are accessible through the ObfuscationTask.CryptoProvider. 


# Architecture
## Protections

A protection may have multiple stages each with different priorities in which to be run. A stage itself might have multiple different "sub-stages" that also have different priorties in which to be run. Therefore, a stage and protection both implement the same interface: [IProtection](/docs/API/prowlynxnet/core/models/IProtection.md).

A protection must inherit from [ProtectionBase](/docs/API/prowlynxnet/core/protections/ProtectionBase.md)

A stage must inherit from either a [Stage](/docs/API/prowlynxnet/core/protections/Stage.md) or [MDStage](/docs/API/prowlynxnet/core/protections/MDStage.md)

## Service Providers
A service provider provides service instances. It is in other words a glorified collection of service instances.

The currently implemented [Service Providers](/docs/API/prowlynxnet/core/serviceproviders) include:
* ArgumentProvider
* AttributeArgumentProvider
* CryptoProvider
* InjectionProvider
* MarkerProvider

A service provider may contain one or more service instances, some like the [Injection Provider](/docs/API/prowlynxnet/core/serviceproviders/InjectionProvider.md) add only one with a shortcut to it accessible using the [ServiceProviderBaseT.First](/docs/API/prowlynxnet/core/serviceproviders/ServiceProviderBaseT.md#first) property. 

## Services
Services all implement an interface of their same name which must implement the [IService](/docs/API/prowlynxnet/core/models/IService.md) interface.

## Engine
The engine used involves a simple setup and an [ObfuscationTask](/docs/API/prowlynxnet/core/ObfuscationTask.md).

An [ObfuscationTask](/docs/API/prowlynxnet/core/ObfuscationTask.md) contains the context of the obfuscation including the different [Service Providers](/docs/API/prowlynxnet/core/serviceproviders) available. It also keeps the module that is currently being processed (unless inside an [MDStage](/docs/API/prowlynxnet/core/protections/MDStage.md) in which it is null) as a property.

# Future Plans
It's always good to have something to be striving towards, right?

## Control Flow Graph Service/AST 
In the pipeline most certainly, perhaps using Echo, also by Washi1337.
Would provide trace services including getting arguments for instructions and breaking methods into basic blocks.

## StackTrace Support
Simply create a log of changes made perhaps as a service so that they can be resolved later. 

# Credits/Dependencies
* Uses the fantastic [AsmResolver](https://github.com/Washi1337/AsmResolver) as the backing library.

# Inspirations
* The once-famous Confuser and it's successor ConfuserEx source.