# ByteBolt

<br>

> ### C# High-level library for byte manipulation

<br>

## Abount

### This lib has the function of facilitating the usability and manipulation of bytes, whether to encode and decode or use it as a base to create your own data type, ex: zip, png, mp4


<br>

## Usage
```csharp
// dotnet 6 / console app
using System;
using Bolt;

// crete
var w = new ByteWrite();
w.Write(1024); // int
w.Write(10.24f); // float

// get all bytes in added list
var buffer = w.GetBuffer();

// read
// create new 
var r = ByteRead();

// add buffer
r.AddBuffer(buffer);

// or 
r.ConcatBuffer(buffer);

// read data
var _int = r.ReadInt(); // output: 1024
var _float = r.ReadFloat(); // output: 10.24

// restore Reader
r.Release();
```

### Write
```csharp
using System;
```

### Read
```csharp
using System;
```
## Buffer
```csharp
using System;
```

## Seek
```csharp
using System;
```
