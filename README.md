# Result for 50MB files
``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.345 (1803/April2018Update/Redstone4)
Intel Core i5-6200U CPU 2.30GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3190.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3190.0


```
|           Method |     Mean |   Error |  StdDev |   Median |
|----------------- |---------:|--------:|--------:|---------:|
|  InMemoryParsing | 107.25 s | 2.283 s | 3.554 s | 106.14 s |
| StreamingParsing |  61.80 s | 2.123 s | 6.090 s |  58.93 s |
