using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int goldValue;
    public int attackPower;
    public float swingSpeed;
}
