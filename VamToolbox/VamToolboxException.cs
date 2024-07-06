using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace VamToolbox;

[Serializable]
[ExcludeFromCodeCoverage]
public class VamToolboxException : Exception
{
    public VamToolboxException()
    {
    }

    public VamToolboxException(string message)
        : base(message)
    {
    }

    public VamToolboxException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}