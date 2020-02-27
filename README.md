
CypressDocTree
## Synopsis
CypressDocTree is a logical document tree generator uitilizing the Composite and Visitor patterns. The library allows you to generate a simple Document Object tree without specifying how the tree will be rendered. Only a bare minimum of presentational elements are included in the library. The actual rendering of the document would be done via the use of an IDocumentVisior. A sample HTMLVisitor and FlowdocumentVisitor are provided with the library and can be used to generate simple HTML or WPF Flowdocuments. Other types of Visitors (i.e. PDF, plaintext, VTS, etc.) could be coded by the client to render the document tree as desired. 

## Code Example
```C#
//Usage
//First construct the document tree
CyDocument doc = new CyDocument();
CyHeading heading = new CyHeading("TEST HEADING");
doc.AddChild(heading);
CyParagraph paragraph = new CyParagraph("This is a test paragraph");
doc.AddChild(paragraph);

//Render the document as flowdocument
FlowDocument fd = new FlowDocument();
FlowDocumentVisitor flowDocVisitor = new FlowDocumentVisitor(fd);
flowDocVisitor.Visit(doc);
//At this point, fd has been populated and can be used elsewhere

//Render the document as HTML
HTMLVisitor htmlVisitor = new HTMLVisitor();
htmlVisitor.visit(doc);
string html = htmlVisitor.HTML;
```
## Motivation
I started the project as a way to simplify document creation in several different formats.

## Contributors
Please feel free to contribute or provide constructive criticism. 

## License
MIT License
