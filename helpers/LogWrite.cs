
namespace Api_Oxigeno.helpers
{
    public class LogWrite
    {
        private ILogger _logger;
        public LogWrite(ILogger<LogWrite> logger)
        {
            _logger = logger;
        }

        public Boolean WriteLog()
        {
            return true;
        }
    }
}