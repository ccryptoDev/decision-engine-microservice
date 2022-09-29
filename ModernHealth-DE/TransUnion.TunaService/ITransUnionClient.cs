using System.Threading.Tasks;

namespace DecisionEngine.TunaService
{
    public delegate void RawXmlHandler(string xml);

    public interface ITransUnionClient
    {
        RawXmlHandler RequestXmlHandler { get; set; }

        RawXmlHandler ResponseXmlHandler { get; set; }

        Task<TOutput> ExecuteAsync<TInput, TOutput>(TInput request)
           where TInput : Request.RequestBase
           where TOutput : Response.ResponseBase;
    }
}
