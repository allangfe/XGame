using System;

namespace XGame.Domain.Arguments.Jogo
{
    public class JogoResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Produtora { get; set; }

        public string Distribuidora { get; set; }

        public string Genero { get; set; }

        public string Site { get; set; }

        public static explicit operator JogoResponse(Entities.Jogo entidade)
        {
            return new JogoResponse
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
                Distribuidora = entidade.Distribuidora,
                Nome = entidade.Nome,
                Genero = entidade.Genero,
                Produtora = entidade.Produtora,
                Site = entidade.Site
            };
        }
    }
}
