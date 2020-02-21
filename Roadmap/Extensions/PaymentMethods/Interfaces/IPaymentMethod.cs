using System.Web.Mvc;

    [ModelBinder(typeof(IPaymentMethodModelBinder))]
    public interface IPaymentMethod
    {
        bool IsComplete { get; }
        bool IsValid { get; }
    }
