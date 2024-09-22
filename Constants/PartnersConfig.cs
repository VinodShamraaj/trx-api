namespace TransactionAPI.Constants;

public static class PartnersConfig
{
    public static readonly List<PartnerStruct> partners = new List<PartnerStruct>()
    {
        new PartnerStruct("FG-00001", "FAKEGOOGLE", "FAKEPASSWORD1234"),
        new PartnerStruct("FG-00002", "FAKEPEOPLE", "FAKEPASSWORD4578")
    };
}
