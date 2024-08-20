using UnityEngine;

public class Sword : Weapon, IPickable
{
    [SerializeField] private Collider _collider;

    private Transform _playerTr;

    public Weapon OnPicked()
    {
        Debug.Log("Shooting Gun is Picked => " + Time.time);
        return this;
    }

    public override void DropWeapon()
    {
        Debug.Log("Shooting Weapon Dropped");
    }

    public override void InitWeapon(Transform parentTr, Transform playerTr)
    {
        _playerTr = playerTr;

        transform.parent = parentTr;
        transform.position = parentTr.position;
        transform.rotation = _playerTr.rotation;
        transform.Rotate(45.0f, 0.0f, 30.0f);

        Destroy(_collider);
        Debug.Log("Shooting Weapon Inited");
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
