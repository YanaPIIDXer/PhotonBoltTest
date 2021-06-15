using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using System;
using UdpKit;

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
        }

        /// <summary>
        /// セッションリストが更新された
        /// </summary>
        /// <param name="sessionList">セッションリスト</param>
        public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
        {
            Debug.LogFormat("Session list updated: {0} total sessions", sessionList.Count);

            foreach (var session in sessionList)
            {
                UdpSession photonSession = session.Value as UdpSession;

                if (photonSession.Source == UdpSessionSource.Photon)
                {
                    BoltMatchmaking.JoinSession(photonSession);
                    break;
                }
            }
        }

        /// <summary>
        /// シーンロードが完了した
        /// </summary>
        /// <param name="scene">シーン名</param>
        /// <param name="token">プロトコルトークン</param>
        public override void SceneLoadLocalDone(string scene, IProtocolToken token)
        {
            if (scene != "Game") { return; }

            var pos = new Vector3(UnityEngine.Random.Range(-3.0f, 3.0f), 0.2f, UnityEngine.Random.Range(-3.0f, 3.0f));
            BoltNetwork.Instantiate(BoltPrefabs.Cube, pos, Quaternion.identity);
        }
    }
}
