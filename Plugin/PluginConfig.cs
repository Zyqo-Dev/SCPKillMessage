using Exiled.API.Interfaces;

namespace SCPKillMessage
{
    public class PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool EnableSuicideMessage { get; set; } = true;
        public bool EnableKillMessage { get; set; } = true;
        public string SuicideMessage { get; set; } = "<size=25><b>[Server Name] SCP-kill Message:</b>\n<color=#B72334>{role}</color> [{nickname}] has killed himself\nReason: <color=#B72334>{reason}</color></size>";
        public string KillMessage { get; set; } = "<size=25><b>[Server Name] SCP-kill Message:</b>\n<color=#B72334>{role}</color> [{nickname}] was killed by <color=#B72334>{killer}</color>\nReason: <color=#B72334>{reason}</color></size>";
        public ushort BroadcastDuration { get; set; } = 10;
    }
}
