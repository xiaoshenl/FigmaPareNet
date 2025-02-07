namespace FigmaPareNet.Client
{
    public interface IFigmaClient
    {
        Task<string> GetFigmaNode(string fileKey, string nodeId);
        Task<string> GetFigmaNodeImage(string fileKey, string nodeId, string format);
    }
}
