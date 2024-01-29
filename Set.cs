/// <summary>
/// Represents a set of elements of type T.
/// </summary>
/// <typeparam name="T">The type of elements in the set.</typeparam>
public class Set<T>
{
    /// <summary>
    /// Gets the list of elements in the set.
    /// </summary>
    public List<T> Elements { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Set class with the provided elements.
    /// </summary>
    /// <param name="elements">The initial elements of the set.</param>
    public Set(List<T> elements)
    {
        Elements = elements;
    }

    /// <summary>
    /// Initializes a new instance of the Set class with the provided elements.
    /// </summary>
    /// <param name="elements">The initial elements of the set.</param>
    public Set(T[] elements)
    {
        Elements = new List<T>(elements);
    }

    /// <summary>
    /// Initializes a new empty instance of the Set class.
    /// </summary>
    public Set()
    {
        Elements = new List<T>();
    }

    /// <summary>
    /// Adds an element to the set if it is not already present.
    /// </summary>
    /// <param name="element">The element to add.</param>
    public void Add(T element)
    {
        if (!Elements.Contains(element))
        {
            Elements.Add(element);
        }
    }

    /// <summary>
    /// Removes an element from the set if it exists.
    /// </summary>
    /// <param name="element">The element to remove.</param>
    public void Remove(T element)
    {
        Elements.Remove(element);
    }

    /// <summary>
    /// Checks if the set contains a specific element.
    /// </summary>
    /// <param name="element">The element to check for.</param>
    /// <returns>True if the element is in the set; otherwise, false.</returns>
    public bool Contains(T element)
    {
        return Elements.Contains(element);
    }

    /// <summary>
    /// Returns the number of elements in the set.
    /// </summary>
    /// <returns>The cardinality of the set.</returns>
    public int Cardinality()
    {
        return Elements.Count;
    }

    /// <summary>
    /// Computes the union of the set with another set.
    /// </summary>
    /// <param name="otherSet">The other set to union with.</param>
    /// <returns>The union of the two sets.</returns>
    public Set<T> Union(Set<T> otherSet)
    {
        Set<T> union = new Set<T>();
        foreach (T element in Elements)
        {
            union.Add(element);
        }
        foreach (T element in otherSet.Elements)
        {
            union.Add(element);
        }
        return union;
    }

    /// <summary>
    /// Computes the intersection of the set with another set.
    /// </summary>
    /// <param name="otherSet">The other set to intersect with.</param>
    /// <returns>The intersection of the two sets.</returns>
    public Set<T> Intersection(Set<T> otherSet)
    {
        Set<T> intersection = new Set<T>();
        foreach (T element in Elements)
        {
            if (otherSet.Contains(element))
            {
                intersection.Add(element);
            }
        }
        return intersection;
    }

    /// <summary>
    /// Computes the universal set based on a list of subsets.
    /// </summary>
    /// <param name="subsets">The list of subsets to consider.</param>
    /// <returns>The universal set containing all unique elements from the subsets.</returns>
    public Set<T> UniversalSet(List<Set<T>> subsets)
    {
        Set<T> universalSet = new Set<T>();
        foreach (var subset in subsets)
        {
            foreach (T element in subset.Elements)
            {
                universalSet.Add(element);
            }
        }

        return universalSet;
    }

    /// <summary>
    /// Checks if the set is a subset of another set.
    /// </summary>
    /// <param name="otherSet">The other set to check against.</param>
    /// <returns>True if the set is a subset of the other set; otherwise, false.</returns>
    public bool IsSubsetOf(Set<T> otherSet)
    {
        foreach (T element in Elements)
        {
            if (!otherSet.Contains(element))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks if the set is a superset of another set.
    /// </summary>
    /// <param name="otherSet">The other set to check against.</param>
    /// <returns>True if the set is a superset of the other set; otherwise, false.</returns>
    public bool IsSupersetOf(Set<T> otherSet)
    {
        return otherSet.IsSubsetOf(this);
    }

    /// <summary>
    /// Checks if the set is a proper subset of another set.
    /// </summary>
    /// <param name="otherSet">The other set to check against.</param>
    /// <returns>True if the set is a proper subset of the other set; otherwise, false.</returns>
    public bool IsProperSubsetOf(Set<T> otherSet)
    {
        return IsSubsetOf(otherSet) && !IsSupersetOf(otherSet);
    }
    /// <summary>
    /// Check if the set is empty
    /// </summary>
    /// <returns>Returns boolean of empty status</returns>
    public bool IsEmptySet()
    {
        return Elements.Count == 0;
    }

    /// <summary>
    /// Returns a string representation of the set.
    /// </summary>
    /// <returns>A string containing the elements of the set enclosed in curly braces.</returns>
    public override string ToString()
    {
        return "{" + string.Join(", ", Elements) + "}";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>Objects that belong to A and not to B</returns>
    public static Set<T> operator -(Set<T> a, Set<T> b)
    {
        Set<T> result = new Set<T>();
        foreach (T element in a.Elements)
        {
            if (!b.Contains(element))
            {
                result.Add(element);
            }
        }
        return result;
    }
    public static bool operator ==(Set<T> a, Set<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        {
            return true;
        }
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        {
            return false;
        }

        return a.Elements.OrderBy(e => e).SequenceEqual(b.Elements.OrderBy(e => e));
    }

    public static bool operator !=(Set<T> a, Set<T> b)
    {
        return !(a == b);
    }
}