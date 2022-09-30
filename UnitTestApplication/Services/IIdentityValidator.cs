namespace UnitTestApplication.Services;

public interface IIdentityValidator
{
    bool IsValid(string identityNumber);
}