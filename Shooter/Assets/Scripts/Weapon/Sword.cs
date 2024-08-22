using UnityEngine;

public class Sword : Weapon, IPickable
{

    public Weapon OnPicked()
        => this;

    public override void InitWeapon(Transform parentTr, Transform playerTr)
    {
        base.InitWeapon(parentTr, playerTr);
        transform.Rotate(45.0f, 0.0f, 30.0f);
    }

    public override void UseWeapon()
    {
        
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 0.5f, _playerTr.forward, 3.0f);
        string res = default;
        foreach (RaycastHit hit in hits)
            res += hit.transform.gameObject.name + " ";
        Debug.Log(res + " => " + Time.time);
    }
}
