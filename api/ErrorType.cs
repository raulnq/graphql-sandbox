namespace api;

public class ErrorType : InterfaceType<IError>
{
    protected override void Configure(
        IInterfaceTypeDescriptor<IError> descriptor)
    {

    }
}

public class MaxLengthErrorType : ObjectType<MaxLengthError>
{
    protected override void Configure(
        IObjectTypeDescriptor<MaxLengthError> descriptor)
    {
        descriptor.Implements<ErrorType>();
    }
}

public class NotEmptyErrorType : ObjectType<NotEmptyError>
{
    protected override void Configure(
        IObjectTypeDescriptor<NotEmptyError> descriptor)
    {
        descriptor.Implements<ErrorType>();
    }
}

public class AddPostPayloadErrorType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("AddPostPayloadError");
        descriptor.Type<MaxLengthErrorType>();
        descriptor.Type<NotEmptyErrorType>();
    }
}
