using Exiled.API.Interfaces;
using System.ComponentModel;

namespace WelcomeMessage
{
    public class Config : IConfig
    {
        [Description("Indica se il plugin è abilitato.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Messaggio di benvenuto personalizzato.")]
        public string Broadcast { get; set; } = "Benvenuto nel server!";

        [Description("Tempo di visualizzazione del messaggio in secondi.")]
        public ushort MessageDuration { get; set; } = 15;

        [Description("Indica se il debug è abilitato.")]
        public bool Debug { get; set; } = false;
    }
}
