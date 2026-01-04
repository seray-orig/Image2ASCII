using Image2ASCII.Core;
using Image2ASCII.Implementations.Converters;

IConverter Converter = ConverterFactory.Create(args);
Converter.Run();
