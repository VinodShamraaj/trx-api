namespace TransactionAPI.Constants;

public struct PartnerStruct
{
    public string partnerNo;
    public string allowedPartner;
    public string partnerPassword;

    public PartnerStruct(string _partnerNo, string _allowedPartner, string _partnerPassword)
    {
        partnerNo = _partnerNo;
        allowedPartner = _allowedPartner;
        partnerPassword = _partnerPassword;
    }
}