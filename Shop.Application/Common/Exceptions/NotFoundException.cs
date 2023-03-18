using System.Runtime.Serialization;

namespace Shop.Application.Common.Exceptions;

[Serializable]
public sealed class NotFoundException : Exception
{
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) not found.") { }

    private NotFoundException(SerializationInfo info, StreamingContext context)
       : base(info, context) { }

    public override void GetObjectData(SerializationInfo info, StreamingContext context) =>
        base.GetObjectData(info, context);
}
