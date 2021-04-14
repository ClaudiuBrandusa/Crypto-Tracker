namespace MobileClient.Services.Validation
{
    public interface IValidator
    {
        string Message { get; }
        bool Check(object[] values);
        string[] GetNeededPropertiesName();
    }
}
