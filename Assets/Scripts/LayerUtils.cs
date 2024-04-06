﻿using UnityEngine;

namespace WarIO
{
    public static class LayerUtils
    {
        public const string BulletLayerName = "Bullet";
        public const string EnemyLayerName = "Enemy";

        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);

        public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName);

        public static bool isBullet(GameObject other) => other.layer == BulletLayer;
    }
}
