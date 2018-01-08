using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador, Guid>, IRepositoryJogador
    {
        public RepositoryJogador(XGameContext context) : base(context)
        {

        }
    }
}
