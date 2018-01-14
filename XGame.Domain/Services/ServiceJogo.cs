using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resource;

namespace XGame.Domain.Services
{
    public class ServiceJogo : Notifiable, IServiceJogo
    {
        private readonly IRepositoryJogo _repositoryJogo;

        public ServiceJogo(IRepositoryJogo repositoryJogo)
        {
            _repositoryJogo = repositoryJogo;
        }

        public AdicionarJogoResponse Adicionar(AdicionarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Mensagens.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarJogoRequest"));
                return null;
            } 

            var jogo = new Jogo(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            AddNotifications(jogo);

            if (IsInvalid()) return null;

            jogo = _repositoryJogo.Adicionar(jogo);

            return (AdicionarJogoResponse)jogo;
        }

        public ResponseBase Alterar(AlterarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Alterar", Mensagens.OBJETO_X0_E_OBRIGATORIO.ToFormat("AlterarJogoRequest"));
                return null;
            }

            var jogo = _repositoryJogo.ObterPorId(request.Id);

            if (jogo == null)
            {
                AddNotification("Id", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            jogo.Alterar(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            if (IsInvalid()) return null;

            _repositoryJogo.Editar(jogo);

            return new  ResponseBase();
        }

        public ResponseBase Excluir(Guid id)
        {
            var jogo = _repositoryJogo.ObterPorId(id);

            if (jogo == null)
            {
                AddNotification("Id", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryJogo.Remover(jogo);

            return new ResponseBase();
        }

        public IEnumerable<JogoResponse> Listar()
        {
            return _repositoryJogo.Listar().ToList().Select(jogador => (JogoResponse)jogador).ToList();
        }
    }
}
