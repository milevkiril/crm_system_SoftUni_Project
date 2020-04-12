namespace CRMSystem.Data.Models.Enumerators
{
    using System.ComponentModel;

    public enum Stage
    {
        Other = 0,
        Negotiation = 1,
        [Description("Sent offer")]
        SentOffer = 2,
        [Description("Accepted offer")]
        AcceptedOffer = 3,
        [Description("Rejected offer")]
        RejectedOffer = 4,
        [Description("Deal lost")]
        DealLost = 5,
        [Description("Deal Won")]
        DealWon = 6,
        [Description("Reconsidering offer")]
        ReconsideringOffer = 7,
    }
}
