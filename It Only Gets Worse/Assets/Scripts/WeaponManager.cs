using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Animator weaponAnimator;

    private void Awake()
    {
        weaponAnimator = GetComponent<Animator>();
    }

    public void shootAnimation()
    {
        weaponAnimator.SetBool(AnimationTags.Shoot, true);
    }

    public void stopShooting()
    {
        weaponAnimator.SetBool(AnimationTags.Shoot, false);
    }
}