using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace AgnaPanel
{
    public class ChatClient
    {
        public class Twitch
        {
            public TcpClient TcpClient { get; set; }
            public StreamReader Reader { get; set; }
            public StreamWriter Writer { get; set; }
            public string Username { get; set; }
            private string OAuthToken { get; set; }
            public string Channel { get; set; }

            public bool Connected
            {
                get
                {
                    if (TcpClient != null)
                        return TcpClient.Connected;
                    else
                        return false;
                }
            }

            private int connectionTimeout = 10000;

            public Twitch()
            {
                //Assign TcpClient
                TcpClient = new TcpClient();

                //Handle Connection Errors
                if (!TcpClient.ConnectAsync("irc.chat.twitch.tv", 6667).Wait(connectionTimeout))
                {
                    Debug.WriteLine("Failed to connect to irc.chat.twitch.tv:6667");
                    return;
                }

                //Assign stream variables
                Reader = new StreamReader(TcpClient.GetStream());
                Writer = new StreamWriter(TcpClient.GetStream());
                Writer.AutoFlush = true;
            }

            public Twitch(string hostname, int port)
            {
                //Assign TcpClient
                TcpClient = new TcpClient();

                //Handle Connection Errors
                if (!TcpClient.ConnectAsync(hostname, port).Wait(connectionTimeout))
                {
                    Debug.WriteLine("Failed to connect to {0}:{1}", hostname, port);
                    return;
                }

                //Assign stream variables
                Reader = new StreamReader(TcpClient.GetStream());
                Writer = new StreamWriter(TcpClient.GetStream());
            }

            public bool Authenticate(string userName, string oauthToken)
            {
                //Store user account variables
                Username = userName.ToLower();
                OAuthToken = oauthToken;

                //Authenticate user
                Writer.WriteLine("PASS {0}\nNICK {1}\nUSER {1} 8 * :", OAuthToken, Username);

                //Check for failure to connect
                string nextLine = Reader.ReadLine();
                for (int i = nextLine.Split(':').Length - 1; i < nextLine.Split(':').Length; i++)
                {
                    if (nextLine.Split(':')[i].Equals("Login unsuccessful"))
                    {
                        Debug.WriteLine("Invalid Username/OAuth Token");
                        return false;
                    }
                }

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

            public string ReturnMessage()
            {
                if (TcpClient.Available > 0 || Reader.Peek() >= 0)
                    return Reader.ReadLine();
                else
                    return String.Empty;
            }

            public void SendMessage(string message) => Writer.WriteLine("{0}", message);

            public Message ParseMessage(string message) => new Message(message, Username, Channel);
        }

        public class Message
        {
            public string Raw { get; set; }
            public DateTime Timestamp { get; set; }

            public string Text { get; set; }
            public string Username { get; set; }

            public enum msgType { IRCServer, IRCPing, IRCUser, IRCRoom, CAP_ACK, RoomState, UnknownCommand, Notice, Chat, Whisper, Null, Unknown }
            public msgType Type { get; set; }

            public bool isCommand { get; set; }

            public Message(string message, string username, string channel)
            {
                if (!String.IsNullOrWhiteSpace(message))
                {
                    /* Determine Message Type */
                    //IRC Types
                    Match IRCServer = Regex.Match(message, String.Format(@"^:tmi\.twitch\.tv \d+ {0} :(.*)$", username), RegexOptions.None);
                    Match IRCPing;
                    Match IRCRoom1 = Regex.Match(message, String.Format(@"^:{0}\.tmi\.twitch\.tv \d+ {0} #{1} :(.*)$", username, channel), RegexOptions.None);
                    Match IRCRoom2 = Regex.Match(message, String.Format(@"^:{0}\.tmi\.twitch\.tv \d+ {0} = #{1} :(.*)$", username, channel), RegexOptions.None);
                    Match IRCUser = Regex.Match(message, String.Format(@"^:{0}!{0}@{0}\.tmi.twitch\.tv (.*)$", username), RegexOptions.None);
                    Match CapabilityAcknowledgement = Regex.Match(message, @"^:tmi\.twitch\.tv CAP \* ACK :(.*)$", RegexOptions.None);
                    Match RoomState = Regex.Match(message, String.Format(@"^:tmi\.twitch\.tv ROOMSTATE #{0}:(.*)$", channel), RegexOptions.None);
                    Match UnknownCommand = Regex.Match(message, String.Format(@"^:tmi.twitch.tv \d+ {0} (\/\w+) :Unknown command$", username), RegexOptions.None);

                    //Chat Types
                    Match Notice = Regex.Match(message, String.Format(@"^:tmi\.twitch\.tv NOTICE #{0} :(.*)$", channel), RegexOptions.None);
                    Match ChatMessage = Regex.Match(message, String.Format(@"^:(\w+)!\w+@\w+\.tmi\.twitch\.tv PRIVMSG #{0} :(.*)$", channel), RegexOptions.None);
                    Match Whisper = Regex.Match(message, String.Format(@"^:(\w+)!\w+@\w+.tmi.twitch.tv WHISPER {0} :(.*)$", username), RegexOptions.None);

                    Raw = message;
                    Timestamp = DateTime.Now;

                    if (IRCServer.Success)
                    {
                        Type = msgType.IRCServer;
                        Text = IRCServer.Groups[1].ToString();
                    }
                    else if (UnknownCommand.Success)
                    {
                        Type = msgType.UnknownCommand;
                        Text = UnknownCommand.Groups[1].ToString();
                    }
                    else if (IRCRoom1.Success)
                    {
                        Type = msgType.IRCRoom;
                        Text = IRCRoom1.Groups[1].ToString();
                    }
                    else if (IRCRoom2.Success)
                    {
                        Type = msgType.IRCRoom;
                        Text = IRCRoom2.Groups[1].ToString();
                    }
                    else if (Notice.Success)
                    {
                        Type = msgType.Notice;
                        Text = Notice.Groups[1].ToString();
                    }
                    else if (ChatMessage.Success)
                    {
                        Type = msgType.Chat;
                        Text = ChatMessage.Groups[2].ToString();
                        Username = ChatMessage.Groups[1].ToString();
                    }
                    else if (Whisper.Success)
                    {
                        Type = msgType.Whisper;
                        Text = Whisper.Groups[2].ToString();
                        Username = Whisper.Groups[1].ToString();

                        //Check if command
                    }
                    else if (IRCUser.Success)
                    {
                        Type = msgType.IRCUser;
                        Text = IRCUser.Groups[1].ToString();
                    }
                    else if (CapabilityAcknowledgement.Success)
                    {
                        Type = msgType.CAP_ACK;
                        Text = CapabilityAcknowledgement.Groups[1].ToString();
                    }
                    else if (RoomState.Success)
                    {
                        Type = msgType.RoomState;
                        Text = RoomState.Groups[1].ToString();
                    }
                    else
                    {
                        Type = msgType.Unknown;
                    }
                }
                else
                {
                    Type = msgType.Null;
                }
            }

            public Message(msgType type, string username, string channel, string message)
            {
                if (type == msgType.Chat)
                {
                    Raw = String.Format(":{0}!{0}@{0}.tmi.twitch.tv PRIVMSG #{1} :{2}", Username, channel, message);
                    Timestamp = DateTime.Now;

                    Type = msgType.Chat;
                    Username = username;
                    Text = message;
                }
                else
                {
                    Type = msgType.Null;
                }
            }

            public override string ToString()
            {
                if (Type == msgType.Chat)
                    return String.Format("{0} - {1}: {2}", Timestamp.ToString("h:mm"), Username, Text);
                else if (Type == msgType.Whisper)
                    return String.Format("{0} - Whisper from @{1}: {2}", Timestamp.ToString("h:mm"), Username, Text);
                else
                    return String.Format("{0} - {1}: {2}", Timestamp.ToString("h:mm"), Type, Text);
            }
        }

        public class Hitbox
        {

        }
    }
}