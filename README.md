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

[MIT License](LICENSE)
