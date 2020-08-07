using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Tooltip tooltip;

    [TextArea(3, 5)]
    [SerializeField] string thisTooltipString;
    PickaxeInfo pickaxeInfo;
    WeaponInfo weaponInfo;

    private void Awake()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponent<PickaxeInfo>())
        {
            pickaxeInfo = GetComponent<PickaxeInfo>();
            thisTooltipString = ("Name: " + pickaxeInfo.pickaxe.name + System.Environment.NewLine +
                                 "Cost: " + pickaxeInfo.pickaxe.goldValue.ToString() + System.Environment.NewLine +
                                 "Mining Power: " + pickaxeInfo.pickaxe.miningPower.ToString() + System.Environment.NewLine +
                                 "Swing Speed: " + pickaxeInfo.pickaxe.swingSpeed.ToString());
        }

        else if (gameObject.GetComponent<WeaponInfo>())
        {
            weaponInfo = GetComponent<WeaponInfo>();
            thisTooltipString = ("Name: " + weaponInfo.weapon.name + System.Environment.NewLine +
                                 "Cost: " + weaponInfo.weapon.goldValue.ToString() + System.Environment.NewLine +
                                 "Attack Power: " + weaponInfo.weapon.attackPower.ToString() + System.Environment.NewLine +
                                 "Swing Speed: " + weaponInfo.weapon.swingSpeed.ToString());
        }
        tooltip.gameObject.SetActive(true);
        tooltip.ShowTooltip_Static(thisTooltipString);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
