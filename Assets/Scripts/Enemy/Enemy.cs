using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : Unit
    {
        [SerializeField] private float countdown;

        private Transform _target;
        private Vector2 _destination;
        private float currentTime;
        private bool isPointReached;

        public void Reset()
        {
            currentTime = countdown;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void SetDestination(Vector2 destination)
        {
            _destination = destination;
            isPointReached = false;
        }

        private void FixedUpdate()
        {
            if (currentTime > 0)
            {
                currentTime -= Time.fixedDeltaTime;
            }

            if (isPointReached)
            {
                Fire();
            }
            else
            {
                MoveToDestination();
            }
        }

        private void MoveToDestination()
        {
            Vector2 vector = _destination - (Vector2)transform.position;
            if (vector.magnitude <= 0.25f)
            {
                isPointReached = true;
                return;
            }

            Move(vector.normalized);
        }

        public override void Fire()
        {
            if (currentTime <= 0)
            {
                Vector2 vector = (Vector2)_target.transform.position - (Vector2)FirePoint.position;
                Vector2 direction = vector.normalized;
                BulletManager.SpawnBullet(BulletConfig, FirePoint.position, direction);

                currentTime += countdown;
            }
        }
    }
}
