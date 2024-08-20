using UnityEngine;

public class ShootingGun : Weapon, IPickable
{
    private const float _BULLET_SPEED = 3.0f;

    [SerializeField] private BoxCollider _collider;
    [SerializeField] private GameObject _bulletPref;

    private ObjectPooling _pool = null;
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
        transform.rotation = playerTr.localRotation;

        Destroy(_collider);

        _pool = new ObjectPooling(_bulletPref, 10);
        Debug.Log("Shooting Weapon Inited");
    }

    public override void UseWeapon()
    {
        GameObject tempBullet = _pool.SpawnBullet();
        tempBullet.transform.position = transform.position + transform.forward * 1.2f;

        Rigidbody rb = tempBullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(_playerTr.forward * _BULLET_SPEED);

        Debug.Log("Shoot!!! =>" + Time.time);
    }
}
