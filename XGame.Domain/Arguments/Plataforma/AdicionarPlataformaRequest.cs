using System;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Plataforma
{
    public class AdicionarPlataformaRequest : IRequest
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Mensagem { get; set; }
    }
}
