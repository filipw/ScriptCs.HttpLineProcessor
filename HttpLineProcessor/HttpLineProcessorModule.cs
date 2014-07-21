using ScriptCs.Contracts;

namespace HttpLineProcessor
{
    [Module("httpprocessor")]
    public class HttpLineProcessorModule : IModule
    {
        public void Initialize(IModuleConfiguration config)
        {
            config.LineProcessor<HttpLineProcessor>();
        }
    }
}
