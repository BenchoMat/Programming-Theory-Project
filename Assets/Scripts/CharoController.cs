using UnityEngine;
using System.Collections;

public class CharoController : PetBehaviour // INHERITANCE
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        runForce = 6.0f;
        eatingSpeed = 4.9f;
    }
    public override void Run(Vector3 runDirection, float runForce) // POLYMORPHISM OVERRIDING
    {
        petRb.AddForce(runDirection * runForce, ForceMode.Impulse);
    }

    public override void Run(float horizontalInput, float verticalInput) // POLYMORPHISM OVERRIDING
    {
        Vector3 move = new Vector3(horizontalInput, 0, verticalInput).normalized;
        petRb.AddForce(move * runForce, ForceMode.Force);
    }

    /*
    public override IEnumerator DelayEating(float m_eatingSpeed)
    {
        isEating = true;
        petRb.linearVelocity = Vector3.zero;
        petRb.angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(m_eatingSpeed);
        isEating = false;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))
        {
            StartCoroutine(DelayEating(eatingSpeed));
            Destroy(other.gameObject);
        }      
    }
    */

}
