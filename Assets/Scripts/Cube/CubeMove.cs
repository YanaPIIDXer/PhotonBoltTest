using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

namespace Game.Cube
{
    /// <summary>
    /// キューブの移動
    /// </summary>
    public class CubeMove : MonoBehaviour
    {
        /// <summary>
        /// 移動ベクトル
        /// </summary>
        private Vector3 moveVec = Vector3.zero;

        /// <summary>
        /// Rigidbody
        /// </summary>
        private Rigidbody rigidBody = null;

        /// <summary>
        /// BoltEntity
        /// </summary>
        private BoltEntity entity = null;

        void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            entity = GetComponent<BoltEntity>();
        }

        void Update()
        {
            if (!entity.IsOwner) { return; }

            moveVec.x = Input.GetAxis("Horizontal");
            moveVec.z = Input.GetAxis("Vertical");
        }

        void FixedUpdate()
        {
            rigidBody.velocity = moveVec;
        }
    }
}
