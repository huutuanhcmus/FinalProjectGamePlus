using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DangKyTK : NetworkManager
{
    public class CustomMeesageTypes
    {
        public static short AuthenticationMsgType = short.MaxValue;
        public static short AuthenticationReplyType = short.MaxValue - 1;
    }

    public enum AuthenticationResponse
    {
        UnknownError = -1,
        Authenticated = 0,
        WrongUsernameOrPassword = 1
    }

    public class AuthenticationParameters
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.LogWarning("Dev: Started OnClientConnect");
        conn.RegisterHandler(CustomMeesageTypes.AuthenticationReplyType, AuthenticateResponse);
        SendAuthentication(conn);
        Debug.LogWarning("Dev: Finished OnClientConnect");
        base.OnClientConnect(conn);
    }

    void SendAuthentication(NetworkConnection conn)
    {
        Debug.LogWarning("Dev: Started SendAuthentication");
        AuthenticationMessage message = new AuthenticationMessage()
        {
            username = AuthenticationParameters.UserName,
            password = AuthenticationParameters.Password
        };
        conn.Send(CustomMeesageTypes.AuthenticationMsgType, message);
        Debug.LogWarning("Dev: Finished SendAuthentication");
    }

    void AuthenticateResponse(NetworkMessage message)
    {
        Debug.LogWarning("Dev: Started AuthenticateResponse");
        AuthenticationReplyMessage msg = message.ReadMessage<AuthenticationReplyMessage>();
        if (msg.ResponseCode == AuthenticationResponse.Authenticated)
        {
            Debug.Log("Authenticated");
            //base.OnClientConnect (message.conn);
            return;
        }
        else if (msg.ResponseCode == AuthenticationResponse.WrongUsernameOrPassword)
            Debug.Log(msg.ResponseCode);
        else
            Debug.Log("Error: @" + msg + " : " + msg.ResponseCode);
        message.conn.Disconnect();
    }

    public class AuthenticationMessage : MessageBase
    {
        public string username, password;
    }

    public class AuthenticationReplyMessage : MessageBase
    {
        public AuthenticationResponse ResponseCode;
    }
}
