using System;
using System.IO;
using System.Net.Sockets;
using System.Diagnostics;

namespace AgnaPanel.Chat
{
    public class ChatClient
    {
        /// <summary>
        /// Chat client compatible with twitch.tv
        /// </summary>
        public class Twitch
        {
            private TcpClient TcpClient { get; set; }
            private StreamReader Reader { get; set; }
            private StreamWriter Writer { get; set; }
            /// <summary>
            /// Default timeout in establishing a connection through TcpClient
            /// </summary>
            private int Timeout = 10000;

            /// <summary>
            /// Twitch Username
            /// </summary>
            public string Username
            {
                get { return _Username; }
                set { _Username = value.ToLower(); }
            }
            private string _Username;
            /// <summary>
            /// Twitch OAuth Token
            /// </summary>
            public string OAuthToken
            {
                get { return _OAuthToken; }
                set { _OAuthToken = value.ToLower(); }
            }
            private string _OAuthToken;

            /// <summary>
            /// Twitch Channel
            /// </summary>
            public string Channel { get; set; }
            /// <summary>
            /// Gets a value indicating whether the underlying TcpClient is connected to a remote host.
            /// </summary>
            public bool Connected => TcpClient.Connected;


            public Twitch()
            {
                //Assign TcpClient
                TcpClient = new TcpClient();

                //Attempt to connect with a timeout
                TcpClient.ConnectAsync("irc.chat.twitch.tv", 6667).Wait(Timeout);

                //Setup chat streams
                if (TcpClient.Connected)
                {
                    Reader = new StreamReader(TcpClient.GetStream());
                    Writer = new StreamWriter(TcpClient.GetStream());
                    Writer.AutoFlush = true;
                }
            }

            public Twitch(int timeout)
            {
                //Assign TcpClient
                TcpClient = new TcpClient();

                //Attempt to connect with a timeout
                TcpClient.ConnectAsync("irc.chat.twitch.tv", 6667).Wait(timeout);

                //Setup chat streams
                if (TcpClient.Connected)
                {
                    Reader = new StreamReader(TcpClient.GetStream());
                    Writer = new StreamWriter(TcpClient.GetStream());
                    Writer.AutoFlush = true;
                }
            }

            /// <summary>
            /// Disconnect from Twitch Chat IRC
            /// </summary>
            public void Disconnect()
            {
                if (TcpClient.Connected)
                    TcpClient.Client.Disconnect(true);
            }

            /// <summary>
            /// Reconnect to Twitch Chat IRC
            /// </summary>
            /// <returns>Returns connection success/failure</returns>
            public bool Reconnect()
            {
                //Disconnect existing connection
                if (TcpClient.Connected)
                    TcpClient.Client.Disconnect(true);

                //Reconnect, return success/failure
                bool connectionStatus = TcpClient.ConnectAsync("irc.chat.twitch.tv", 6667).Wait(Timeout);

                //Setup chat streams
                if (TcpClient.Connected && (!String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(OAuthToken)))
                {
                    Reader = new StreamReader(TcpClient.GetStream());
                    Writer = new StreamWriter(TcpClient.GetStream());
                    Writer.AutoFlush = true;
                }

                return connectionStatus;
            }

            public bool Authenticate(string userName, string oauthToken)
            {
                //Make sure credentials will work
                if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(oauthToken) || !oauthToken.StartsWith("oauth:"))
                    return false;

                //Store user account variables
                Username = userName.ToLower();
                OAuthToken = oauthToken;

                //Authenticate user
                Writer.WriteLine("PASS {0}\nNICK {1}\nUSER {1} 8 * :", OAuthToken, Username);

                //Check for failure to connect
                string nextLine = ReaderMessage().ToString();
                for (int i = nextLine.Split(':').Length - 1; i < nextLine.Split(':').Length; i++)
                {
                    if (nextLine.Split(':')[i].Equals("Login authentication failed"))
                        return false;
                }

                //Successfully connected, return true
                return true;
            }

            public void JoinChannel(string channel)
            {
                //Store channel variable
                Channel = channel;

                //Join channel
                Writer.WriteLine("JOIN #{0}", Channel);
            }

            public void LeaveChannel()
            {
                //Leave channel
                Writer.WriteLine("PART #{0}", Channel);

                //Empty channel variable
                Channel = String.Empty;
            }

            public ChatMessage ReaderMessage()
            {
                if (!TcpClient.Connected || String.IsNullOrWhiteSpace(Username) || String.IsNullOrWhiteSpace(OAuthToken))
                    return new ChatMessage(String.Empty, Username, Channel);

                if (TcpClient.Available > 0 || Reader.Peek() >= 0)
                    return new ChatMessage(Reader.ReadLine(), Username, Channel);
                else
                    return new ChatMessage(String.Empty, Username, Channel);
            }

            public void SendMessage(string message) => Writer.WriteLine("{0}", message);
        }

        /// <summary>
        /// Chat client compatible with Hitbox.tv
        /// </summary>
        public class Hitbox
        { }

    }
}