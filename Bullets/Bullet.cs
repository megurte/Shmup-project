﻿using Character;
using DefaultNamespace;
using Environment;
using UI.Scene.Special;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Bullets
{
    public class Bullet : MonoBehaviour, IDestroyable
    {
        public float startSpeed = 0.1f;
        public BulletType bulletType;
        public GameObject destroyEffect;
        public Vector3 direction;
        public float angle = 180;

        private void FixedUpdate()
        {
            Moving();
        }

        protected void Moving()
        {
            transform.Translate(direction.normalized * startSpeed, Space.World);
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.IfHasComponent<PlayerBase>(component =>
            {
                PlayerBase.TakeDamage(1);
                GlobalEvents.HealthChanged(component.health);
                DestroySelf();
            });

            collision.gameObject.IfHasComponent<Border>(component =>
            {
                if (bulletType != BulletType.Chain)
                    Destroy(gameObject);
            });
        }

        public void DestroySelf()
        {
            Instantiate(destroyEffect, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
}
