using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

namespace Game.Network
{
    /// <summary>
    /// ログ受信
    /// </summary>
    [BoltGlobalBehaviour]
    public class LogReceiver : GlobalEventListener
    {
        /// <summary>
        /// ログ受信
        /// </summary>
        /// <param name="log">ログ</param>
        public override void OnEvent(LogEvent log)
        {
            Debug.Log(log.Message);
        }
    }
}
