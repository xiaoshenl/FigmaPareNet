namespace FigmaPareNet.Client
{
    public interface IFigmaClient
    {
        /// <summary>
        /// Get a Figma node by file key and node id
        /// </summary>
        /// <param name="fileKey">The key of the file</param>
        /// <param name="nodeId">The id of the node</param>
        /// <returns>The node</returns>
        Task<string> GetFigmaNode(string fileKey, string nodeId);

        /// <summary>
        /// Get a Figma node image by file key, node id and format
        /// </summary>
        /// <param name="fileKey">The key of the file</param>
        /// <param name="nodeId">The id of the node</param>
        /// <param name="format">The format of the image</param>
        /// <returns>The image</returns>
        Task<string> GetFigmaNodeImage(string fileKey, string nodeId, string format);
    }
}
