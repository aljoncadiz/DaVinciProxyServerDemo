using System;

namespace ProxyServerNetCore.Models
{
    public class GetLTISummaryRequest
    {
        public string MerchantsInventoryVehicleId { get; set; }
        public int CustomerId { get; set; }
        public string FleetName { get; set; }
        public string Vin { get; set; }
        public string InsuranceProvider { get; set; }
        public string State { get; set; }
    }

    public class LTISummary
    {
        public LTISummaryDataSet1 DataSet1 { get; set; }

        public LTISummaryDataSet2 DataSet2 { get; set; }

        public InsuranceCardDownloadAvailability InsuranceCard { get; set; }

        public class LTISummaryDataSet1 : ConditionalDataSet
        {
            public byte? TitleCodeId { get; set; }
            public string TitleStatus { get; set; }
            public DateTime? TitleReceivedDate { get; set; }
        }

        public class LTISummaryDataSet2
        {
            public string PlateNumber { get; set; }
            public string PlateState { get; set; }
            public DateTime? PlateExpirationDate { get; set; }
            public string PlateType { get; set; }

            public LTIInsuranceSummaryEntry[] InsurancePolicies { get; set; }
        }

        public class InsuranceCardDownloadAvailability
        {
            public bool Implemented { get; set; }
            public bool Existing { get; set; }
        }

        public class ConditionalDataSet
        {
            public bool ConditionMet { get; set; }
        }

        public class LTIInsuranceSummaryEntry
        {
            public string InsuranceCompanyName { get; set; }

            public DateTime? PolicyExpirationDate { get; set; }
        }
    }
}
