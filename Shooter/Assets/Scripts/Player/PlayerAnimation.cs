using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string _ANIMATION_ON_MOVE = "on_move";

    [SerializeField] private Animator _animator;

    void Update()
    {
        float moveVer = Input.GetAxis("Vertical");
        float moveHor = Input.GetAxis("Horizontal");
        Vector2 moveVec = new Vector2(moveHor, moveVer);

        bool isMoving = moveVec != Vector2.zero;
        _animator.SetBool(_ANIMATION_ON_MOVE, isMoving);
    }
}
