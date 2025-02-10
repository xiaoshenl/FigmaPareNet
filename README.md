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
- eg.
``` json
{
    "Id": "1:1",
    "Name": "Main",
    "Type": "FRAME",
    "Text": "",
    "MainComponent": null,
    "ComponentSet": null,
    "ComponentProperties": null,
    "Style": {
        "width": "1600px",
        "display": "flex",
        "flexDirection": "column",
        "paddingLeft": "24px",
        "paddingRight": "24px"
    },
    "IsAutoLayout": true,
    "Children": [
        {
            "Id": "1:2",
            "Name": "_Custom / Page Heading",
            "Type": "FRAME",
            "Text": "",
            "MainComponent": null,
            "ComponentSet": null,
            "ComponentProperties": null,
            "Style": {
                "display": "flex",
                "flexDirection": "column",
                "paddingTop": "16px",
                "paddingBottom": "16px"
            },
            "IsAutoLayout": true,
            "Children": [
                {
                    "Id": "2:1",
                    "Name": "<Breadcrumbs>",
                    "Type": "INSTANCE",
                    "Text": "",
                    "MainComponent": "Separator=Text*, Collapsed=False",
                    "ComponentSet": "<Breadcrumbs>",
                    "ComponentProperties": {
                        "Separator Icon#10120:169": {
                            "Value": "3037:13577",
                            "Type": "INSTANCE_SWAP"
                        },
                        "Icon#10028:17": {
                            "Value": "false",
                            "Type": "BOOLEAN"
                        },
                        "Separator": {
                            "Value": "Text*",
                            "Type": "VARIANT"
                        },
                        "Collapsed": {
                            "Value": "False",
                            "Type": "VARIANT"
                        }
                    },
                    "Style": {
                        "display": "flex",
                        "flexDirection": "row"
                    },
                    "IsAutoLayout": true,
                    "Children": [],
                    "PreviewImageUrl": null
                }
            ],
            "PreviewImageUrl": null
        }
    ],
    "PreviewImageUrl": null
}
```

## License

MIT License

Copyright (c) [2025] [FigmaPareNet]

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
