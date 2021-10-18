using BepInEx;
using BepInEx.Configuration;
using Newtonsoft.Json;
using UnityEngine;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Collections;

namespace LordAshes
{
	[BepInPlugin(Guid, Name, Version)]
    [BepInDependency(ChatServicePlugin.Guid)]
	public partial class ChatWhisperPlugin : BaseUnityPlugin
	{
		// Plugin info
		public const string Name = "Chat Whisper Plug-In";
		public const string Guid = "org.lordashes.plugins.chatwhisper";
		public const string Version = "1.1.0.0";

        /// <summary>
        /// Function for initializing plugin
        /// This function is called once by TaleSpire
        /// </summary>
        void Awake()
		{
			UnityEngine.Debug.Log("Chat Whisper Plugin: Active.");

            ChatServicePlugin.handlers.Add("/w ", (chatMessage, sender, source) =>
            {
                if (chatMessage.StartsWith("/w"))
                {
                    chatMessage = chatMessage.Substring(2).Trim() + " ";
                    string target = chatMessage.Substring(0, chatMessage.IndexOf(" "));
                    if (target == ".") { target = CampaignSessionManager.GetPlayerName(LocalPlayer.Id); }
                    if (target == ".." || target.ToUpper() == "GM") { target = FindGM(); }
                    chatMessage = chatMessage.Substring(chatMessage.IndexOf(" ") + 1);
                    Debug.Log("Whisper From '" + sender + "' To '" + target + "' (Received By '" + CampaignSessionManager.GetPlayerName(LocalPlayer.Id) + "')");
                    if (CampaignSessionManager.GetPlayerName(LocalPlayer.Id) != target)
                    {
                        return null;
                    }
                    chatMessage = "(Whisper) " + chatMessage;
                }
                return chatMessage;
            });

            ChatServicePlugin.handlers.Add("/w! ", (chatMessage, sender, source) =>
            {
                if (chatMessage.StartsWith("/w!"))
                {
                    chatMessage = chatMessage.Substring(3).Trim() + " ";
                    string target = chatMessage.Substring(0, chatMessage.IndexOf(" "));
                    if (target == ".") { target = CampaignSessionManager.GetPlayerName(LocalPlayer.Id); }
                    if (target == ".." || target.ToUpper() == "GM") { target = FindGM(); }
                    chatMessage = chatMessage.Substring(chatMessage.IndexOf(" ") + 1);
                    Debug.Log("Whisper From '" + sender + "' To Everyone But '" + target + "' (Received By '" + CampaignSessionManager.GetPlayerName(LocalPlayer.Id) + "')");
                    if (CampaignSessionManager.GetPlayerName(LocalPlayer.Id) == target)
                    {
                        return null;
                    }
                    chatMessage = "(Whisper) " + chatMessage;
                }
                return chatMessage;
            });
        }

        public static string FindGM()
        {
            foreach(KeyValuePair<PlayerGuid, PlayerInfo> player in CampaignSessionManager.PlayersInfo)
            {
                if (player.Value.Rights.CanGm) { return player.Value.Name; }
            }
            return "";
        }
    }
}
