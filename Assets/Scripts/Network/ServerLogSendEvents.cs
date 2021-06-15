using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

namespace Game.Network
{
    /// <summary>
    /// サーバからのログ送信イベント
    /// </summary>
    [BoltGlobalBehaviour(BoltNetworkModes.Server)]
    public class ServerLogSendEvents : GlobalEventListener
    {
        /// <summary>
        /// 接続された
        /// </summary>
        /// <param name="connection">接続したクライアント</param>
        public override void Connected(BoltConnection connection)
        {
            var log = LogEvent.Create();
            log.Message = connection.RemoteEndPoint.ToString() + " Connected.";
            log.Send();
        }

        /// <summary>
        /// 切断された
        /// </summary>
        /// <param name="connection">切断したクライアント</param>
        public override void Disconnected(BoltConnection connection)
        {
            var log = LogEvent.Create();
            log.Message = connection.RemoteEndPoint.ToString() + " Disconnected.";
            log.Send();
        }
    }
}
