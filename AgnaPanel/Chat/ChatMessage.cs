using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace AgnaPanel.Chat
{
    public class ChatMessage
    {
        /// <summary>
        /// IRC message identifier
        /// </summary>
        public enum ServerMsgType //https://www.alien.net.au/irc/irc2numerics.html
        {
            NONE = 000,
            RPL_WELCOME = 001,
            RPL_YOURHOST = 002,
            RPL_CREATED = 003,
            RPL_MYINFO = 004,
            RPL_NAMREPLY = 353,
            RPL_ENDOFNAMES = 366,
            RPL_MOTD = 372,
            RPL_MOTDSTART = 375,
            RPL_ENDOFMOTD = 376,
            ERR_UNKNOWNCOMMAND = 421
        }
        public ServerMsgType ServerMessageType { get; set; } = ServerMsgType.NONE;

        /// <summary>
        /// General message identifier
        /// </summary>
        public enum MsgType
        {
            NULL,
            UNKNOWN,
            PRIVMSG,
            WHISPER,
            NOTICE,
            SERVER
        }
        public MsgType MessageType { get; set; } = MsgType.UNKNOWN;


        /// <summary>
        /// Raw IRC Text
        /// </summary>
        private string RawMessage;
        /// <summary>
        /// Username of who sent the message
        /// </summary>
        public string Username;
        /// <summary>
        /// Body text of the message
        /// </summary>
        public string Message;

        public DateTime Timestamp;

        public ChatMessage()
        {
            RawMessage = String.Empty;
            Timestamp = DateTime.Now;
        }

        public ChatMessage(string rawMessage, string userName, string channel)
        {
            if (rawMessage.Equals(String.Empty))
            {
                MessageType = MsgType.NULL;
                return;
            }

            Match PrivMsg = Regex.Match(rawMessage, @"(\w+)\.tmi\.twitch\.tv PRIVMSG", RegexOptions.None);
            Match Whisper = Regex.Match(rawMessage, @"", RegexOptions.None);
            Match Notice = Regex.Match(rawMessage, @"", RegexOptions.None);
            Match IRCServer = Regex.Match(rawMessage, @"tmi\.twitch\.tv (\d{3}) " + userName, RegexOptions.None);

            if (PrivMsg.Success)
            {
                MessageType = MsgType.PRIVMSG;
                Username = PrivMsg.Groups[1].ToString();
                Message = rawMessage.Split(':')[2];
            }
            else if (IRCServer.Success)
            {
                MessageType = MsgType.SERVER;
                ServerMessageType = (ServerMsgType)Convert.ToInt16(IRCServer.Groups[1].ToString());
                Message = rawMessage.Split(':')[2];
            }

            RawMessage = rawMessage;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return MessageType == MsgType.NULL ? String.Empty
                : MessageType + (MessageType == MsgType.SERVER ? $" - {ServerMessageType.ToString()}" : String.Empty) + (!String.IsNullOrWhiteSpace(Message) ? $": {Message}" : String.Empty);
        }

        public static class Capabilities
        {
            public static string Membership() => "CAP REQ :twitch.tv/membership";
            public static string Commands() => "CAP REQ :twitch.tv/commands";
            public static string Tags() => "CAP REQ :twitch.tv/tags";
        }

    }
}