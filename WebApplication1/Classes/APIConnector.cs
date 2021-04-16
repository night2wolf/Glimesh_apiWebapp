using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Glimesh.Base;
using Glimesh.Base.Clients;
using Glimesh.Base.Models.Channels;
using Glimesh.Base.Models.Clients.Channel;
using Glimesh.Base.Models.Clients.Chat;
using Glimesh.Base.Models.Users;
using StreamingClient.Base.Util;

//TODO: Clean this up for our purposes. this was taken from the Glimesh Streaming Client Library Examples:
// https://github.com/SaviorXTanren/StreamingClientLibrary/blob/master/Glimesh/Samples/Glimesh.ChatSample.Console/Program.cs
namespace PSG_Webapp.Classes
{
    public class APIConnector
    {
        // Change these clientID and secret depending on who is using it
        public const string clientID = "86cbc95fe6e583fd72654af65c68a0a2cea8890cde4464de26c0f946d24fae1a";
        public const string clientSecret = "8562d68a91a1913e558b333115801b95f3db05699ee4c1f0300cef19f54fd839";

        private static List<OAuthClientScopeEnum> scopes = new List<OAuthClientScopeEnum>()
        {
            OAuthClientScopeEnum.publicinfo,
            OAuthClientScopeEnum.chat,
            OAuthClientScopeEnum.email,
            OAuthClientScopeEnum.streamkey
        };

        private static GlimeshConnection connection;
        private static UserModel user;
        private static ChannelModel channel;
        private static ChatEventClient client;

        private static void Client_OnChatMessageReceived(object sender, ChatMessagePacketModel message)
        {
            System.Console.WriteLine(string.Format("{0}: {1}", message.User?.displayname, message.Message));
        }

        private static void Client_OnChannelUpdated(object sender, ChannelUpdatePacketModel channelUpdate)
        {
            System.Console.WriteLine(string.Format("Stream Title: {0}", channelUpdate.Channel.title));
        }

        private static void Client_OnFollowOccurred(object sender, FollowPacketModel follow)
        {
            System.Console.WriteLine(string.Format("User Followed: {0}", follow.Follow.user?.username));
        }

        private static void Logger_LogOccurred(object sender, Log log)
        {
            System.Console.WriteLine(string.Format("LOG: {0} - {1}", log.Level, log.Message));
        }
    }
}
