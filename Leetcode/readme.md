﻿﻿﻿# Notes

# Array 

Array.Sort(seats);
Array.Fill(counts, 1);

## Conversion

When converting math formula to from `int` to `long`, 
Convert the first value to long first, 
So the following computation will be `long` instead of `int`. 
Otherwise, the computation will be `int`.

Right Way:
```csharp
long ans = (long)q * l % MOD;
```

Wrong Way:
```csharp
long ans = (long)(q * l % MOD);
```

# Math

## Greatest Common Divisor

```csharp
private int gcd(int x, int y)
{
    if (x == 0) return y;
    return gcd(y % x, x);
}
```

## Least Common Multiple
```
int l = a / gcd(a, b) * b;
```

## Compare the square instead of the square root.
```csharp
long distance2 = x * x + y * y;
if (distance2 <= bombI[2] * bombI[2])
{
    graph[i][j] = 1;
}
```

## Beware of integer overflow, add i>0 in for loop

```csharp
public class Solution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        int result = left;
        for (int i = left + 1; i <= right && i > 0; i++)
        {
            result = result & i;
            if (result == 0)
            {
                return 0;
            }
        }

        return result;
    }
}

```

Without `i > 0`, if right is `int.MaxValue`, then the next value will be `int.MinValue`. Thus the result will be wrong.

## Max/Min

```csharp
private int Min(params int[] values)
{
    int result = values[0];
    for (int i = 1; i < values.Length; i++)
    {
        result = Math.Min(result, values[i]);
    }
    return result;
}
```

# Strings

Using `StringBuilder` to concatenate strings.

## Implements

228. Trie
137. Binary Search Tree Iterator
297. Serialize and Deserialize Binary Tree
Better finish this first.
