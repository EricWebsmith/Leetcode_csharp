# Notes

## Array Sort

Array.Sort(seats);

## Conversion

When converting math formula to from int to long, 
Convert the first value to long first, 
So the following computation will be long instead of int. 
Otherwise the computation will be int.

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

## Implements

Trie: 228
