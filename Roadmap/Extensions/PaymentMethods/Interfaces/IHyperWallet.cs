using System;

    public interface IHyperWallet : IPaymentMethod, IAutoOrderPaymentMethod
    {
        HyperWalletType Type { get; set; }
        string WalletAccountDisplay { get; set; }
    }

    public enum HyperWalletType
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,
    }
