using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Photon.Bolt;

namespace Game.UI
{
    /// <summary>
    /// サーバボタン
    /// </summary>
    public class ServerButton : MonoBehaviour
    {
        /// <summary>
        /// ボタン
        /// </summary>
        private Button button = null;

        void Awake()
        {
            button = GetComponent<Button>();
            button.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    BoltLauncher.StartServer();
                }).AddTo(gameObject);
        }
    }
}
