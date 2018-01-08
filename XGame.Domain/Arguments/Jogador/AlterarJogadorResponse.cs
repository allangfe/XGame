using System;
using XGame.Domain.Resource;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Mensagem { get; set; }

        public static explicit operator AlterarJogadorResponse(Entities.Jogador entidade)
        {
            return new AlterarJogadorResponse
            {
                Id = entidade.Id,
                Email = entidade.Email.Endereco,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Mensagem = Mensagens.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}


