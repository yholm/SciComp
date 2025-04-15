# SciComp
SciComp is a lightweight, extensible scientific computing library built for clarity and precision. It offers a range of mathematical and computational tools, including numerical operations, matrix manipulation, algebraic structures, and symbolic processing � perfect for simulations, math-heavy applications, or just playing around with numbers.

## Features
**Linear Algebra** - Matrix and vector operations (addition, multiplication, inversion, etc.)
**SI Unit handling** - Support for SI units and conversions
**Chemistry** - Basic chemical operations and structures

## Installation
``` bash
dotnet add package SciComp
```

## Usage Example
```csharp
using SciComp.LinearAlgebra;
using SciComp.Numerics;

var A = new Matrix( 
[
    new([1, 4]), // [ 1, 2, 3 ]
    new([2, 5]), // [ 4, 5, 6 ]
    new([3, 6])
]);
var B = new Matrix(
[
    new([7, 9, 11]),  // [ 7, 8 ]
    new([8, 10, 12]), // [ 9, 10]
]);                   // [11, 12]

var C = A * B;
```

## Contributing
Contributions are welcome! Whether it's a bug fix, a feature, or a simple improvement to docs feel free to open a PR or an issue.

## License
MIT License. See LICENSE for details.
