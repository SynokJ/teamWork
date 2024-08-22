using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform _weaponSnapPos;

    private Weapon _weapon = null;

    private void OnTriggerEnter(Collider other)
    {
        IPickable pickable = other.GetComponent<IPickable>();
        if (pickable != null && _weapon == null)
        {
            _weapon = pickable.OnPicked();
            _weapon.InitWeapon(_weaponSnapPos, transform);
        }
    }

    private void Update()
    {
        if (_weapon == null) return;

        if (Input.GetMouseButtonDown(0))
            _weapon.UseWeapon();

        if (Input.GetKeyDown(KeyCode.G))
        {
            _weapon.DropWeapon();
            _weapon = null;
        }
    }

}
