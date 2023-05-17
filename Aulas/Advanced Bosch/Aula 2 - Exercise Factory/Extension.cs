public static class CompanyBuilderExtension
{
    public static Company.CompanyBuilder InBrazil(this Company.CompanyBuilder builder)
    {
        builder.SetFactory(new BrazilProcessFactory());
        return builder;
    }
    public static Company.CompanyBuilder InArgentina(this Company.CompanyBuilder builder)
    {
        builder.SetFactory(new ArgentinaProcessFactory());
        return builder;
    }
    public static Company.CompanyBuilder InEUA(this Company.CompanyBuilder builder)
    {
        builder.SetFactory(new EUAProcessFactory());
        return builder;
    }
}