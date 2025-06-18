using System.Collections;
using UnityEngine;

public class PetBehaviour : MonoBehaviour
{
    public Vector3 runDirection;
    public bool canControl = false;
    public Rigidbody petRb;
    public float runForce = 10.0f;
    public float horizontalInput;
    public float verticalInput;
    private float m_eatingSpeed = 3.0f;
    public bool isEating = false;
    public float eatingSpeed
    {
        get { return m_eatingSpeed; }
        set
        {
            if (value < 0.0f || value > 5.0f)
            {
                Debug.LogError("You can't set a negative or above 5 eating speed value");
            }
            else
            {
                m_eatingSpeed = value;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        petRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canControl) return;
        if (Input.GetKeyDown(KeyCode.Space) && isEating == false)
        {
            runDirection = transform.forward;
            Run(runDirection, runForce);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (isEating == false)
        {
            Run(horizontalInput, verticalInput);
        }
    }

    public virtual void Run(Vector3 runDirection, float runForce)
    {
        petRb.AddForce(runDirection * runForce, ForceMode.Impulse);
    }

    public virtual void Run(float horizontalInput, float verticalInput)
    {
        Vector3 move = new Vector3(horizontalInput, 0, verticalInput).normalized;
        petRb.AddForce(move * runForce, ForceMode.Force);
    }

    public virtual IEnumerator DelayEating(float m_eatingSpeed)
    {
        isEating = true;
        petRb.linearVelocity = Vector3.zero;
        petRb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(m_eatingSpeed);
        isEating = false;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))
        {
            StartCoroutine(DelayEating(eatingSpeed));
            Destroy(other.gameObject);
        }      
    }
}
