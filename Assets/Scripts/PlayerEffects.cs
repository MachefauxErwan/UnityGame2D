using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public void AddSpeed(int speedGiven, float speedDuration)
    {
        PlayerMovement.instance.MoveSpeed += speedGiven;
        StartCoroutine(removeSpeed(speedGiven, speedDuration));
    }

   private IEnumerator removeSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovement.instance.MoveSpeed -= speedGiven;
    }
}
