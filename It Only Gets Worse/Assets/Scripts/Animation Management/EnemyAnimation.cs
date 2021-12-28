using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator anim;
    [SerializeField] EnemyController controller;

    [Header("Animation Settings")]
    [SerializeField] AnimState animState;

    public enum AnimState
    {
        Idle,
        Dead,
        Sprinting,
        Attacking
    }

    private void Start()
    {
        if(!controller.navMesh.isStopped)
        {
            SetSprinting();
        }
        else if (!controller.isMoving)
        {
            //SetIdle();
            SetAttack();
        }
    }

    public void SetIdle()
    {
        anim.SetBool("isIdle", true);
        animState = AnimState.Idle;
    }

    public void SetSprinting()
    {
        anim.SetBool("isSprinting", true);
        animState = AnimState.Sprinting;
    }

    public void SetDie()
    {
        anim.SetBool("die", true);
        animState = AnimState.Dead;
    }

    public void SetAttack()
    {
        float num = 1f; //there are 2 animations with the asset, so whenever the enemy attacks the player, this will add a integer value which will be a random number with 1 min and 2 max. if 1, then atttack1. if 2 then attack2.
        num = Random.Range(1, 2);

        Debug.Log(num);

        string s = "attack" + num;

        anim.SetBool(s, true);
    }
}
