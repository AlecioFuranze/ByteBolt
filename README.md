# ByteBolt

#### C# High-level library for byte manipulation, and fast encode/decode of datas


## Usage

#### Namespace
```csharp
using ByteBolt; // api
```
```csharp
using ByteBolt.Core; // internal
```

#### Accepted Types
```
// byte
byte;
byte[];

// int | Int32
int;
uint;

// short | Int16
short;
ushort;

// long | Int64
long;
ulong;

// arithmetic
float;
double;

// other
char;
string;
```

- ### Writer
  ```csharp
  using System;
  using ByteBolt;
  using ByteBolt.Core;
  
  // create instance
  Writer w = new Writer();                  // default;
                                            /*
  Writer w = new Writer(int <length>);      // set default Segment length
  Writer w = bew Writer(Segment <segment>); // set existent Segment
                                            */
  
  // write
  w.Write("int, string, byte[], char, float, double, ...");
  
  // encoded result
  byte[]  array   = w.ToArray();
  Segment segment = w.ToSegment(); 
  ```
- ### Reader
    ```csharp
    ```
#### Sample
```csharp
 using System;
 using ByteBolt;
 
 // Writer instance
 Writer writer = new Writer();
 
 // write data
 writer.Write((byte) 255);
 writer.Write((int) 1024);
 writer.Write((byte[]) new byte[] { 1, 2, 3, 4 });
 writer.Write((string) "ByteBolt");
 
 // encoded bytes
 byte[] encoded = writer.ToArray();
 
 // Reader instance
 Reader reader = new Reader(encoded); // accept: byte[], Writer, ... 
 
 // reader data
 byte     myByte    = reader.ReadByte();   // output: 255
 int      myInt     = reader.ReadInt();    // output: 1024
 byte[]   myBytes   = reader.ReadBytes();  // output: [ 1, 2, 3, 4 ]
 string   myString  = reader.ReadString(); // output: ByteBolt
 
```
