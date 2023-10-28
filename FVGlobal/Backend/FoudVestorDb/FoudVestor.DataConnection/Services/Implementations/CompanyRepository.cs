namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class CompanyRepository : ICompanyRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public CompanyRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}