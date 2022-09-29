using System.Threading.Tasks;

namespace DecisionEngine.Services
{
    public interface ITransUnionService
    {
        Task<Models.Response.CreditReportResult> GetCreditReportAsync(Models.Request.CreditReportRequest request);
    }
}
