using FigmaPareNet.Models;

namespace FigmaPareNet.Services
{
    public interface IFigmaPareService
    {
        Task<string> GetFigmaNodeDesignJson(FigmaNodeQuery input);
    }
}
