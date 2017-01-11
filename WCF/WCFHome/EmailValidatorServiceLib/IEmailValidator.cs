using System.ServiceModel;

namespace EmailValidatorServiceLib
{
    [ServiceContract]
    public interface IEmailValidator
    {
        [OperationContract]
        bool ValidateAddress(string emailAddress);
    }
}
