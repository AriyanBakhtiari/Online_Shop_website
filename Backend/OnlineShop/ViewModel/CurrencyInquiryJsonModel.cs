namespace OnlineShop.ViewModel;

public class CurrencyInquiryJsonModel
{
    public CurrencyInquiryParameters Parameters { get; set; }
    public Status Status { get; set; }
}

public class CryptoCurrencyInquiryJsonModel
{
    public CryptoCurrencyParameters Parameters { get; set; }
    public Status Status { get; set; }
}
public class CurrencyInquiryParameters
{
    public CurrencyInquiryDataList[] CurrencyInquiryDataList { get; set; }
}

public class CurrencyInquiryDataList
{
    public string Change24H { get; set; }

    public string Change24HPercent { get; set; }

    public string ExtraInfo { get; set; }

    public string HighestPrice { get; set; }

    public string Icon { get; set; }

    public string LastUpdate { get; set; }

    public string LowestPrice { get; set; }

    public string Name { get; set; }

    public string Price { get; set; }

    public string ShowName { get; set; }
}

public class Status
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class CryptoCurrencyParameters
{
    public CryptoCurrencyInquiryDataList[] CryptoCurrencyInquiryDataList { get; set; }
}

public class CryptoCurrencyInquiryDataList
{
    public string Change24H { get; set; }
    public string Change24HPercent { get; set; }
    public string ExtraInfo { get; set; }
    public string Icon { get; set; }
    public string LastUpdate { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public string PriceRial { get; set; }
    public string ShowName { get; set; }
    public string Symbol { get; set; }
}
