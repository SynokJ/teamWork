using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void UseWeapon();
    public abstract void DropWeapon();
    public abstract void InitWeapon(Transform parentTr, Transform playerTr);
}
