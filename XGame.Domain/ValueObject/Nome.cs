using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Resource;

namespace XGame.Domain.ValueObject
{
    public class Nome : Notifiable
    {
        protected Nome()
        {

        }

        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 50, Mensagens.X0_E_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Primeiro nome", "3", "50"))
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 50, Mensagens.X0_E_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Último nome", "3", "50"));
        }

        public string PrimeiroNome { get; private set; }

        public string UltimoNome { get; private set; }
    }
}
