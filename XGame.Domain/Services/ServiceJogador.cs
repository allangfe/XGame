using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resource;
using XGame.Domain.ValueObject;
using System;
using XGame.Domain.Arguments.Base;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            var jogador = new Jogador(nome, email, request.Senha);

            AddNotifications(nome, email);

            if (IsInvalid()) return null;

            jogador = _repositoryJogador.Adicionar(jogador);

            return (AdicionarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse Alterar(AlterarJogadorRequest request)
        {
            if (request == null)
                AddNotification("AlterarJogadorRequest", Mensagens.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorRequest"));

            Jogador jogador = _repositoryJogador.ObterPorId(request.Id);

            if (jogador == null)
            {
                AddNotification("Id", Mensagens.DADOS_NAO_ENCONTRADOS);

                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email, jogador.Status);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
                return null;

            _repositoryJogador.Editar(jogador);

            return (AlterarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request)
        {
            if (request == null)
                AddNotification("AutenticarJogadorRequest", Mensagens.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
                return null;

            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == jogador.Email.Endereco, x => x.Senha == jogador.Senha);

            return (AutenticarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> Listar()
        {
            return _repositoryJogador.Listar().Select(jogador => (JogadorResponse)jogador).ToList();
        }

        public ResponseBase Excluir(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(id);

            if (jogador == null)
            {
                AddNotification("Id", Mensagens.DADOS_NAO_ENCONTRADOS);

                return null;
            }

            _repositoryJogador.Remover(jogador);

            return new ResponseBase();
        }
    }
}
