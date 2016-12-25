# Albite.Core
A Portable Class Library containing core functionality used in other projects for .NET

# Building
This repository does **NOT** contain the solution, only the projects.
The solution is available at [Albite.Core.Solution](https://github.com/dumbledore/Albite.Core.Solution)

In order to build it, clone the solution repo. It would fetch _this_ project as a _Git module_.

# Details
`Albite.Core` is a [.NET Standard 1.1](https://docs.microsoft.com/en-us/dotnet/articles/standard/library) library.

It includes:
* Collections
  * `CircularBufferQueue` and `CircularBufferStack`
  * `Tree` with a `DepthFirstTreeEnumerator`
  * `EnumerableExtensions`: A non-generic version of the extensions in `System.Linq.Enumerable`
  * `IdentityEqualityComparer`: for comparing objects by reference 
* Diagnostics with a simple logger interface that is statically controlled through the `Logger` class.
* IO Extensions for a `BinaryReader` and a `BinaryWriter` that implement serialization for simple types like:
  * `Enum`
  * `Type`
  * `DateTime`
  * `TimeSpan`
  * `DateTimeOffset`
  * `Guid`
* Reflection helpers:
  * Fields and properties are generallized via *IMemberValue* at the cost of not supporting indexed properties,
    which is actually beneficial as it simplifies the code considerably.
  * There is an extension method that for a given `TypeInfo`, returns a list of its `IMemberValue`s (i.e.
    its fields and propeties).
* Initial support for serialization (See [Albite.Serialization](https://github.com/dumbledore/Albite.Serialization)
  for the imlementation) via the `Serialized` attribute. Currently `CircularBuffer` and `Node` are marked as serialized.
