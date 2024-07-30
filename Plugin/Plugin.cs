using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Core.Attributes;
using System;

namespace SCPKillMessage
{
    public class SCPKillMessage : Plugin<PluginConfig>
    {
        public override string Name => "SCPKillMessage";
        public override string Author => "Kuze";
        public override string Prefix => "scp_kill_msg";
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
            var player = ev.Player;
            var damageHandler = ev.DamageHandler;

            if (player.Role.Type.ToString().StartsWith("Scp"))
            {
                string message;
                string scpName = player.Role.Type.ToString().Replace("Scp", "Scp-");
                string damageName = damageHandler?.Type.ToString() ?? "Unknown";
                var attacker = damageHandler?.Attacker;

                if (attacker == player)
                {
                    // Suicide message
                    message = Config.SuicideMessage
                        .Replace("{role}", scpName)
                        .Replace("{nickname}", player.Nickname)
                        .Replace("{reason}", damageName);
                }
                else
                {
                    string killerName = attacker?.Nickname ?? "Unknown";
                    // Kill message
                    message = Config.KillMessage
                        .Replace("{role}", scpName)
                        .Replace("{nickname}", player.Nickname)
                        .Replace("{killer}", killerName)
                        .Replace("{reason}", damageName);
                }

                Map.Broadcast(new Exiled.API.Features.Broadcast(message, Config.BroadcastDuration));
            }
        }
    }
}
