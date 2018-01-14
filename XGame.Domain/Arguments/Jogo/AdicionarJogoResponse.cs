using System;
using XGame.Domain.Resource;

namespace XGame.Domain.Arguments.Jogo
{
    public class AdicionarJogoResponse
    {
        public Guid Id { get; set; }

        public string Mensagem { get; set; }

        public static explicit operator AdicionarJogoResponse(Entities.Jogo entidade)
        {
            return new AdicionarJogoResponse
            {
                Id = entidade.Id,
                Mensagem = Mensagens.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
