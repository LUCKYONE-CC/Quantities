# Quantities

The `Set<T>` class is a generic implementation of a set data structure in C#. It allows you to work with sets of elements of type `T`, providing operations such as union, intersection, subset checking, and more.

## Introduction

In mathematics, a set is a collection of distinct elements, and the `Set<T>` class is designed to represent and manipulate sets in C#. It provides the following key features:

- Adding and removing elements to/from a set.
- Checking if an element exists in a set.
- Calculating the union and intersection of two sets.
- Checking for subset, superset, and proper subset relationships between sets.
- Computing the universal set based on a list of subsets.

## Getting Started

To use the `Set<T>` class in your C# project, you can include the `Set.cs` file in your codebase or compile it into a library. The class is designed to be generic, allowing you to work with sets of any data type.

## Usage

### Creating a Set

You can create a new empty set or initialize a set with an array or a list of elements:

```csharp
Set<int> setA = new Set<int>();
Set<int> setB = new Set<int>(new int[] { 1, 2, 3 });
```

### Adding and Removing Elements

```csharp
setA.Add(4);
setB.Remove(2);
```

### Set Operations

```csharp
Set<int> unionSet = setA.Union(setB);
Set<int> intersectionSet = setA.Intersection(setB);
Set<int> differenceSet = setA - setB;
```

### Subset Relationships

```csharp
bool isSubset = setA.IsSubsetOf(setB);
bool isSuperset = setA.IsSupersetOf(setB);
bool isProperSubset = setA.IsProperSubsetOf(setB);
```

### Universal Set

```csharp
List<Set<int>> subsets = new List<Set<int>> { setA, setB };
Set<int> universalSet = setA.UniversalSet(subsets);
```

### Examples

```csharp
Set<int> setA = new Set<int>(new int[] { 1, 2, 3 });
Set<int> setB = new Set<int>(new int[] { 2, 3, 4 });

Set<int> unionSet = setA.Union(setB); // {1, 2, 3, 4}
Set<int> intersectionSet = setA.Intersection(setB); // {2, 3}
Set<int> differenceSet = setA - setB; // {1}
bool isSubset = setA.IsSubsetOf(setB); // False
bool isSuperset = setA.IsSupersetOf(setB); // False
bool isProperSubset = setA.IsProperSubsetOf(setB); // False

List<Set<int>> subsets = new List<Set<int>> { setA, setB };
Set<int> universalSet = setA.UniversalSet(subsets); // {1, 2, 3, 4}
```

## Contributing

Contributions to this project are welcome. If you find any issues or have suggestions for improvements, please create an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
