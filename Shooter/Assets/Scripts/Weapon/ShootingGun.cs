using UnityEngine;

public class ShootingGun : Weapon, IPickable
{
    private const float _BULLET_SPEED = 3.0f;

    [SerializeField] private GameObject _bulletPref;

    private ObjectPooling _pool = null;
    
    public Weapon OnPicked()
        => this;

    public override void InitWeapon(Transform parentTr, Transform playerTr)
    {
        base.InitWeapon(parentTr, playerTr);
        _pool = new ObjectPooling(_bulletPref, 10);
    }

    public override void UseWeapon()
    {
        GameObject tempBullet = _pool.SpawnBullet();
        tempBullet.transform.position = transform.position + transform.forward * 1.2f;

        Rigidbody rb = tempBullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(_playerTr.forward * _BULLET_SPEED);
    }
}
