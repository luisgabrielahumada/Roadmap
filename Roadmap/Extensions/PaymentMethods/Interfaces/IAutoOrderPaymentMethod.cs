﻿public interface IAutoOrderPaymentMethod
    {
        int[] AutoOrderIDs { get; set; }

        bool IsUsedInAutoOrders { get; }
        //AutoOrderPaymentType AutoOrderPaymentType { get; }
    }
