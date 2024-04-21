using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [Header("Locations")]
    [SerializeField] private GameObject _respawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }

            CharacterController controller = other.GetComponent<CharacterController>();

            if(controller != null)
            {
                controller.enabled = false;
            }

            other.transform.position = _respawnPoint.transform.position;

            StartCoroutine(CCEnableRoutine(controller));
        }
    }

    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.3f);
        controller.enabled = true;
    }
}
