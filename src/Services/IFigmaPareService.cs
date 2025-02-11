using FigmaPareNet.Models;

namespace FigmaPareNet.Services
{
    public interface IFigmaPareService
    {
        /// <summary>
        /// Get a Figma node design json by file key and node id
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>The node design json</returns>
        Task<string> GetFigmaNodeDesignJson(FigmaNodeQuery input);
    }
}
