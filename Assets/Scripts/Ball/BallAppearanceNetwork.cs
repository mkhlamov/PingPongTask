﻿using Photon.Pun;
using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Ball
{
    public class BallAppearanceNetwork : BallAppearance
    {
        public BallAppearanceNetwork(SpriteRenderer image, IRandomService randomService, Transform transform, float minSize, float maxSize, string colorStr) : base(image, randomService, transform, minSize, maxSize, colorStr)
        {
        }

        public override void SetNewBall()
        {
            if (!PhotonNetwork.IsMasterClient) return;
            base.SetNewBall();
        }
    }
}