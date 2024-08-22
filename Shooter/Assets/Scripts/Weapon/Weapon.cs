using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float _PICK_UP_DELAY = 2.0f;

    [SerializeField] private Collider _collider;

    protected Transform _playerTr;
    private Rigidbody _rb;

    public abstract void UseWeapon();

    public virtual void DropWeapon()
    {
        transform.parent = null;
        transform.position += _playerTr.forward * 2.0f;

        _rb = this.gameObject.AddComponent<Rigidbody>();
        StartCoroutine(OnDropped());
    }

    public virtual void InitWeapon(Transform parentTr, Transform playerTr)
    {
        _playerTr = playerTr;

        transform.parent = parentTr;
        transform.position = parentTr.position;
        transform.rotation = playerTr.localRotation;

        _collider.enabled = false;
    }

    private IEnumerator OnDropped()
    {
        yield return new WaitForSeconds(_PICK_UP_DELAY);
        _collider.enabled = true;
        Destroy(_rb);
    }
}
