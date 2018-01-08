using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Resource;

namespace XGame.Domain.ValueObject
{
    public class Email : Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Endereco, Mensagens.X0_INVALIDO.ToFormat("E-mail"));
        }

        public string Endereco { get; private set; }
    }
}
