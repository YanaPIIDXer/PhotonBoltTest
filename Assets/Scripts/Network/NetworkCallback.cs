using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using System;

namespace Game.Network
{
    /// <summary>
    /// ネットワークコールバック
    /// </summary>
    [BoltGlobalBehaviour]
    public class NetworkCallback : GlobalEventListener
    {
        /// <summary>
        /// Bolt起動
        /// </summary>
        public override void BoltStartDone()
        {
            if (BoltNetwork.IsServer)
            {
                BoltMatchmaking.CreateSession(Guid.NewGuid().ToString(), null, "Game");
            }
            else
            {
                Debug.Log("Bolt start as Client!");
            }
        }

        /// <summary>
        /// シーンロードが完了した
        /// </summary>
        /// <param name="scene">シーン名</param>
        /// <param name="token">プロトコルトークン</param>
        public override void SceneLoadLocalDone(string scene, IProtocolToken token)
        {
            Debug.Log("Scene:" + scene);
        }
    }
}
