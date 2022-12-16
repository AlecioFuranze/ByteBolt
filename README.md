# ByteBolt

#### C# High-level library for byte manipulation, and fast encode/decode of datas


## Usage

#### Namespace
```csharp
using ByteBolt; // default: Writer, Reader
```
```csharp
using ByteBolt.Core; // internal usage
```

#### Accepted Types

| TYPE          | VALUE        |
| ---           | ---          |
| Byte          | byte, byte[] |
| Char          | char, string |
| Int16         | short, ushort|
| Int32         | int, uint    |
| Int64         | long, ulong  |
| Floating-Point| float, double|

- ### Writer

  ```csharp
  using System;                             
  using ByteBolt;                           // import to use: Writer, Reader
  using ByteBolt.Core;                      // import to use: Segment, Encode [ ASCII, UTF7, UTF8, UTF32, UNICODE ]
  
  // create instance
  Writer w = new Writer();                  // default;
                                            /*
  Writer w = new Writer(int <length>);      // set default Segment length
  Writer w = bew Writer(Segment <segment>); // set existent Segment
                                            */
  
  // write
  w.Write("ByteBolt", Encode.UTF8); // Write string with (Encode), the default is UTF8. 
  w.Write("int, string, byte[], char, float, double, ...");
  
  // encoded result
  byte[]  array   = w.ToArray();
  Segment segment = w.ToSegment(); 
  ```
- ### Reader
    ```csharp
    using System;
    using ByteBolt;
    
    // create instance
    Reader r = new Reader(ref w);             // default;
                                              /*
    Reader r = new Reader(byte[] <buffer>);   // set  Buffer
    Reader r = new Reader(Writer <writer>);   // set  Writer
    Reader r = bew Reader(Segment <segment>); // set  Segment
                                              */
    
    // reader
    byte myByte       = r.ReadByte();
    string myString   = r.ReadString();
    string myStrName  = r.ReadString(Encode.UTF8); // Reader string with (Encode), the default is UTF8.
    
    // other
    byte peekIndex    = r.Peek();   // peek current reading index
    byte peekMyIndex  = r.Peek(7);  // peek at custom segment index
    
    int current = r.Current; // get the current reading index
    int length  = r.Length;  // get the reader Segment length
    
    // Seek: move the current reading Segment position:
    // Syntax: Reader.Seek(int <position>);    
    // WARNING (use this only if you know what you're doing)
    r.Seek(current);
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
