using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Entities.Base;
using XGame.Domain.Enums;
using XGame.Domain.Extensions;
using XGame.Domain.Resource;
using XGame.Domain.ValueObject;

namespace XGame.Domain.Entities
{
    public class Jogador : EntityBase
    {
        public Jogador()
        {

        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Status = SituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, Mensagens.X0_E_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "6", "32"));

            if (IsValid())
                Senha = Senha.ConvertToMD5();

            AddNotifications(nome, email);
        }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, Mensagens.X0_DEVE_TER_ENTRE_X1_E_X2.ToFormat("Senha", "6", "32"));

            if (IsValid())
                Senha = Senha.ConvertToMD5();
        }

        public void AlterarJogador(Nome nome, Email email, SituacaoJogador status)
        {
            Nome = nome;
            Email = email;
            Status = status;

            new AddNotifications<Jogador>(this)
                .IfFalse(x => x.Status == SituacaoJogador.Ativo, Mensagens.NAO_E_POSSIVEL_ALTERAR_JOGADOR_SE_ELE_ESTIVER_ATIVO);

            AddNotifications(nome, email);
        }

        public Nome Nome { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public SituacaoJogador Status { get; private set; }
    }
}
