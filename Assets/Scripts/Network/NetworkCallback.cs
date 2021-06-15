using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

namespace Game.Network
{
    /// <summary>
    /// ネットワークコールバック
    /// </summary>
    [BoltGlobalBehaviour]
    public class NetworkCallback : GlobalEventListener
    {
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
