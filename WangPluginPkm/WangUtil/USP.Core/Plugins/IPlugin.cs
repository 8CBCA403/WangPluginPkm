
namespace USP.Core
{
    public delegate ulong EvalExecute(string expres);
    public delegate byte[] ReadBytes(ulong offset, int length);
    public delegate void WriteBytes(byte[] data, ulong offset);
    public interface IPlugin
    {
        /// <summary>
        /// Plugin Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Plugin Loading Priority (lowest is initialized first).
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Entry point for the parent to initialize the plugin with provided arguments.
        /// </summary>
        /// <param name="args">Arguments containing objects useful for initializing the plugin.</param>
        void Initialize(params object[] args);

        void Execute();

        /// <summary>
        /// Notifies the plugin that a save file was just loaded.
        /// </summary>
        void NotifBotConnected();
    }
}
