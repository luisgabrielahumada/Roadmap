﻿
using System.Collections.Generic;

    public class PeruConfiguration : IMarketConfiguration
    {
        private MarketName marketName = MarketName.Peru;

        public MarketName MarketName
        {
            get
            {
                return marketName;
            }
        }

        #region Properties
        // Shopping
        public IOrderConfiguration Orders
        {
            get
            {
                return new OrderConfiguration();
            }
        }
        public IOrderConfiguration AutoOrders
        {
            get
            {
                return new AutoOrderConfiguration();
            }
        }

        // Back Office
        public IOrderConfiguration BackOfficeOrders
        {
            get
            {
                return new BackOfficeOrderConfiguration();
            }
        }
        public IOrderConfiguration BackOfficeAutoOrders
        {
            get
            {
                return new BackOfficeAutoOrderConfiguration();
            }
        }

        // Enrollment Packs
        public IOrderConfiguration EnrollmentKits
        {
            get
            {
                return new EnrollmentKitConfiguration();
            }
        }
        public IOrderConfiguration EnrollmentOrders
        {
            get
            {
                return new EnrollmentOrderOrderConfiguration();
            }
        }
        public IOrderConfiguration EnrollmentAutoOrders
        {
            get
            {
                return new EnrollmentAutoOrderConfiguration();
            }
        }
        #endregion

        // Base Order Configuration
        public class BaseOrderConfiguration : IOrderConfiguration
        {
            public BaseOrderConfiguration()
            {
                //WarehouseID = Warehouses.Peru;
                //PickUpWarehouseID = Warehouses.Peru;
                CurrencyCode = CurrencyCodes.PeruSol;
               // PriceTypeID = PriceTypes.Retail;
                LanguageID = Languages.Spanish_Peru;
                DefaultCountryCode = CountryCodes.Peru;
                DefaultShipMethodID = 115;
                PickUpShippingID = 157;
                AvailableShipMethods = new List<int> { 115 };
            }

            public int WarehouseID { get; set; }
            public string CurrencyCode { get; set; }
            public int PriceTypeID { get; set; }
            public int LanguageID { get; set; }
            public string DefaultCountryCode { get; set; }
            public int DefaultShipMethodID { get; set; }
            public List<int> AvailableShipMethods { get; set; }
            public int CategoryID { get; set; }
            public int FeaturedCategoryID { get; set; }
            public int PickUpWarehouseID { get; set; }
            public int PickUpShippingID { get; set; }
            /// <summary>
            /// Checks to see if market has a pickup warehouse designated
            /// </summary>
            public bool HasPickUpOption { get { return PickUpWarehouseID != 0; } }
            /// <summary>
            /// Checks if warehouse for pickup is the same as main warehouse (pseudo pickup market)
            /// </summary>
            public bool HasUniquePickupWarehouse { get { return HasPickUpOption && PickUpWarehouseID != WarehouseID; } }

        }

        #region Configurations

        #region Replicated Site
        // Replicated Site - Product List
        public class OrderConfiguration : BaseOrderConfiguration
        {
            public OrderConfiguration()
            {
                CategoryID = 323;
            }
        }

        // Replicated Site - Auto Order Manager
        public class AutoOrderConfiguration : BaseOrderConfiguration
        {
            public AutoOrderConfiguration()
            {
                CategoryID = 324;
                //PriceTypeID = PriceTypes.Preferred;
            }
        }
        #endregion


        #region Enrollment
        // Replicated Site - Enrollment Kits
        public class EnrollmentKitConfiguration : BaseOrderConfiguration
        {
            public EnrollmentKitConfiguration()
            {
                CategoryID = 326;
               // //PriceTypeID = PriceTypes.Wholesale;
            }
        }

        // Replicated Site - Enrollment Shopping
        public class EnrollmentOrderOrderConfiguration : BaseOrderConfiguration
        {
            public EnrollmentOrderOrderConfiguration()
            {
                CategoryID = 321;
                ////PriceTypeID = PriceTypes.Wholesale;
            }
        }

        // Replicated Site - Auto Order Manager
        public class EnrollmentAutoOrderConfiguration : BaseOrderConfiguration
        {
            public EnrollmentAutoOrderConfiguration()
            {
                CategoryID = 322;
                ////PriceTypeID = PriceTypes.Wholesale;
            }
        }
        #endregion


        #region Back Office
        // Back Office - Product List
        public class BackOfficeOrderConfiguration : BaseOrderConfiguration
        {
            public BackOfficeOrderConfiguration()
            {
                CategoryID = 336;
                ////PriceTypeID = PriceTypes.Wholesale;
            }
        }

        // Back Office - Auto Order Manager
        public class BackOfficeAutoOrderConfiguration : BaseOrderConfiguration
        {
            public BackOfficeAutoOrderConfiguration()
            {
                CategoryID = 337;
                ////PriceTypeID = PriceTypes.Wholesale;
            }
        }
        #endregion
        #endregion
    }
