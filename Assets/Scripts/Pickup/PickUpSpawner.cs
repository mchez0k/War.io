using UnityEditor;
using UnityEngine;
using WarIO.Shooting;

namespace WarIO.Pickup
{
    public class PickUpSpawner : MonoBehaviour
    {
        [SerializeField]
        private PickUpItem pickUpPrefab;

        [SerializeField]
        private float range = 2f;

        [SerializeField]
        private int maxCount = 2;

        [SerializeField]
        private float minSpawnIntervalSec = 10f;
        [SerializeField]
        private float maxSpawnIntervalSec = 20f;

        private float currentSpawnTime;
        private int currentCount = 0;

        protected void Update()
        {
            if (currentCount < maxCount)
            {
                currentSpawnTime += Time.deltaTime;
                if (currentSpawnTime > Random.Range(minSpawnIntervalSec, maxSpawnIntervalSec)) // Вызывается каждый кадр, но величина всё равно остаётся случайной
                {
                    currentSpawnTime = 0f;
                    currentCount++;

                    var randomPointInside = Random.insideUnitCircle * range;
                    var randomPosition = new Vector3(randomPointInside.x, 0f, randomPointInside.y) + transform.position;

                    var pickUp = Instantiate(pickUpPrefab, randomPosition, Quaternion.identity, transform);
                    pickUp.OnPickedUp += OnItemPickedUp;
                }
            }
        }

        private void OnItemPickedUp(PickUpItem pickedUpItem)
        {
            currentCount--;
            pickedUpItem.OnPickedUp -= OnItemPickedUp;
        }

        protected void OnDrawGizmos()
        {
            var cashedcolor = Handles.color;
            Handles.color = Color.blue;
            Handles.DrawWireDisc(transform.position, Vector3.up, range);
            Handles.color = cashedcolor;
        }
    }
}