using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Netherforge.Combat
{
    public class Damage : MonoBehaviour
    {
        Health health;
        [SerializeField] Vector2 knockback = new Vector2(1f, 1f);
        GameObject equippedItem;

        private void Awake()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            equippedItem = FindObjectOfType<EquippedInventory>().activeItem;
            health = collision.GetComponent<Health>();
            if (collision.gameObject.CompareTag("Enemy") && equippedItem.GetComponent<WeaponInfo>())
            {
                int weaponDamge;
                weaponDamge = equippedItem.GetComponent<WeaponInfo>().weapon.attackPower;
                health.TakeDamage(weaponDamge, knockback);
            }
        }
    }
}
