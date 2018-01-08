using XGame.Domain.Resource;

namespace XGame.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Message = Mensagens.OPERACAO_REALIZADA_COM_SUCESSO;
        }

        public string Message { get; set; }
    }
}
