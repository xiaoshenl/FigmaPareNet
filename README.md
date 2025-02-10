# FigmaPareNet

A .NET library for parsing Figma node information through Figma's backend API, including CSS styles.

## Installation

Add the service in your `Program.cs` or startup configuration:

```csharp
var configuration = builder.Configuration;
builder.Services.AddFigmaPareNet(configuration);
```

## Usage

```csharp
// Using the service
await _figmaPareService.GetFigmaNodeDesignJson(new FigmaPareNet.Models.FigmaNodeQuery
{
    FileKey = "your figma file key",
    NodeId = "figma file node id"
});
```

## Parameters

- `FileKey`: The unique identifier of your Figma file
- `NodeId`: The node ID within the Figma file

## Response

Returns a JSON object containing node information, including:

- Node name
- Node type
- Style properties
- Other design attributes

## License

MIT License

Copyright (c) [year] [FigmaPareNet]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
