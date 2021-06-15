using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

namespace Game.Cube
{
    /// <summary>
    /// キューブの移動
    /// </summary>
    public class CubeMove : EntityBehaviour<ICubeState>
    {
        /// <summary>
        /// 移動ベクトル
        /// </summary>
        private Vector3 moveVec = Vector3.zero;

        /// <summary>
        /// Rigidbody
        /// </summary>
        private Rigidbody rigidBody = null;

        public override void Attached()
        {
            rigidBody = GetComponent<Rigidbody>();
            state.SetTransforms(state.Transform, transform);
        }

        void Update()
        {
            moveVec.x = Input.GetAxis("Horizontal");
            moveVec.z = Input.GetAxis("Vertical");
        }

        void FixedUpdate()
        {
            rigidBody.velocity = moveVec;
        }
    }
}
