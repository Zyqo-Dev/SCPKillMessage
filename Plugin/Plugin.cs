using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;

namespace SCPKillMessage
{
    public class SCPKillMessage : Plugin<PluginConfig>
    {
        public override string Name => "SCPKillMessage";
        public override string Author => "Kuze";
        public override string Prefix => "scp_kill_msg";
        public override Version Version => new Version(1, 0, 3);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);

        public override void OnEnabled()
        {
            base.OnEnabled();
            Exiled.Events.Handlers.Player.Dying += OnPlayerDying;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.Dying -= OnPlayerDying;
        }

        private void OnPlayerDying(DyingEventArgs ev)
        {
            if (!Config.IsEnabled)
                return;

            var player = ev.Player;
            var damageHandler = ev.DamageHandler;

            var roleType = player.Role.Type;

            // Check if the role type starts with "Scp" and is not SCP-049-2
            if (roleType.ToString().StartsWith("Scp") && roleType != RoleTypeId.Scp0492)
            {
                string message = null;
                string scpName = roleType.ToString().Replace("Scp", "SCP-");
                string damageName = damageHandler?.Type.ToString() ?? "Unknown";
                var attacker = damageHandler?.Attacker;
                string killerName = attacker?.Nickname ?? "Unknown";

                if (killerName == "Unknown" && Config.EnableSuicideMessage)
                {
                    // Suicide message
                    message = Config.SuicideMessage
                        .Replace("{role}", scpName)
                        .Replace("{nickname}", player.Nickname)
                        .Replace("{reason}", damageName);
                }
                else if (killerName != "Unknown" && Config.EnableKillMessage)
                {
                    // Kill message
                    message = Config.KillMessage
                        .Replace("{role}", scpName)
                        .Replace("{nickname}", player.Nickname)
                        .Replace("{killer}", killerName)
                        .Replace("{reason}", damageName);
                }

                if (message != null)
                {
                    Map.Broadcast(new Exiled.API.Features.Broadcast(message, Config.BroadcastDuration));
                }
            }
        }
    }
}
