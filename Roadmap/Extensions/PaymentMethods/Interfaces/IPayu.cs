using System;

    public interface IPayu : IPaymentMethod, IAutoOrderPaymentMethod
    {
        PayuType Type { get; set; }
        string Token { get; set; }
    }

    public enum PayuType
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,
    }
