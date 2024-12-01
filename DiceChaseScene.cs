using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DiceChaseScene : MonoBehaviour
{
    public Rigidbody rb;

    public bool hasLanded;
    public bool thrown;
    private Renderer rend;
    private BoxCollider diceChaseCollider;
    


    Vector3 initPosition;

    public int diceValue;


    public DiceSide[] diceSides;
    public objectMovement ObjectMovementScriptPolice;
    public GameObject diceResetPosition;



    public Transform diceTransform;
    float distanceFromObject = 0f;
    float distanceFromCamera = 1f;
    public float turnSpeed = 5.0f;



    void Start()
    {
        //  rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    public  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }

        else if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            SideValueCheck();


        }
        else if (rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            if (ObjectMovementScriptPolice.routePosition == 0 || ObjectMovementScriptPolice.routePosition <= 11)
            {
                RollAgain();
            }
            else if (ObjectMovementScriptPolice.routePosition >= 12 && ObjectMovementScriptPolice.routePosition <= 18)
            {
              RollAgainSecondLine();
            }
            else if (ObjectMovementScriptPolice.routePosition >= 19 && ObjectMovementScriptPolice.routePosition <= 28)
            {
                RollAgainThirdLine();
            }
            else if (ObjectMovementScriptPolice.routePosition >= 29 && ObjectMovementScriptPolice.routePosition <= 34)
            {
                RollAgainFourthLine();
            }


        }
    }

    public void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            StartCoroutine(RollDiceFunction());

        }
       


    }

    public void RollDiceSecondLine()
    {
        if (!thrown && !hasLanded)
        {
            StartCoroutine(RollDiceSecondLineFunction());

        }
        

    }
    public void RollDiceThirdLine()
    {
        if (!thrown && !hasLanded)
        {
            StartCoroutine(RollDiceThirdLineFunction());

        }
      


    }
    public void RollDiceFourthLine()
    {
        if (!thrown && !hasLanded)
        {
            StartCoroutine(RollDiceFourthLineFunction());

        }
       

    }
    public void RollAgain()
    {
        Reset();
        StartCoroutine(RollDiceFunction());
        Debug.Log("Rolled Forward");

    }
    void RollAgainSecondLine()
    {
        Reset();
        StartCoroutine(RollDiceSecondLineFunction());
        Debug.Log("Rolled Right");
    }
    void RollAgainThirdLine()
    {
        Reset();
        StartCoroutine(RollDiceThirdLineFunction());
        Debug.Log("Rolled Left");
    }
    void RollAgainFourthLine()
    {
        Reset();
        StartCoroutine(RollDiceFourthLineFunction());
        Debug.Log("Rolled Backward");
    }

    void Reset()
    {
        transform.position = initPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }





    void SideValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue + " has been rolled!");

            }
        }
    }

    public IEnumerator RollDiceFunction()
    {
        yield return new WaitForSeconds(0f);
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;
        Vector3 ForwardOfCamera = -diceResetPosition.transform.forward * distanceFromObject;
        diceTransform.position = diceResetPosition.transform.position + ForwardOfCamera;
        diceTransform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

        thrown = true;
        rb.useGravity = true;
        rb.AddForce(Random.Range(2400, 2600), Random.Range(-100, -300), (0));
        rb.AddTorque((2000000),(10000000),(8000));

    }
    public IEnumerator RollDiceSecondLineFunction()
    {
        yield return new WaitForSeconds(0f);
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;
        Vector3 ForwardOfCamera = -diceResetPosition.transform.forward * distanceFromObject;
        diceTransform.position = diceResetPosition.transform.position + ForwardOfCamera;
        diceTransform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        thrown = true;
        rb.useGravity = true;
        rb.AddForce((0), Random.Range(100, 300), Random.Range(1600, 1900));
        rb.AddTorque((2000000), (10000000), (8000));

    }
    public IEnumerator RollDiceThirdLineFunction()
    {
        yield return new WaitForSeconds(0f);
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;
        Vector3 ForwardOfCamera = -diceResetPosition.transform.forward * distanceFromObject;
        diceTransform.position = diceResetPosition.transform.position + ForwardOfCamera;
        diceTransform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

        thrown = true;
        rb.useGravity = true;
        rb.AddForce(Random.Range(-1600, -1900), Random.Range(100, 300), (0));
        rb.AddTorque((-2000000), (-10000000), (-8000));

    }

    public IEnumerator RollDiceFourthLineFunction()
    {
        yield return new WaitForSeconds(0f);
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;
        Vector3 ForwardOfCamera = -diceResetPosition.transform.forward * distanceFromObject;
        diceTransform.position = diceResetPosition.transform.position + ForwardOfCamera;
        diceTransform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        thrown = true;
        rb.useGravity = true;
        rb.AddForce((0), Random.Range(100, 300), Random.Range(-1600, -1900));
       rb.AddTorque((-2000000),(-10000000),(-8000));


    }

    public void showDiceForOne()
    {
        StartCoroutine(showDiceNumberForOne());
    }

    public void showDiceForTwo()
    {
        StartCoroutine(showDiceNumberForTwo());
    }

    public void showDiceForThree()
    {
        StartCoroutine(showDiceNumberForThree());
    }
    public void showDiceForFour()
    {
        StartCoroutine(showDiceNumberForFour());
    }
    public void showDiceForFive()
    {
        StartCoroutine(showDiceNumberForFive());
    }
    public void showDiceForSix()
    {
        StartCoroutine(showDiceNumberForSix());
    }
    public void ResetDicePositionVoid()
    {
        StartCoroutine(ResetDicePosition());
    }
    public IEnumerator showDiceNumberForOne()
    {
        // Set initial parameters
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(-19.386f, -106.264f, 2.321f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.rotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        
        
    }


    public IEnumerator showDiceNumberForTwo()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0f, 0f, 90f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.rotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        

    }
    public IEnumerator showDiceNumberForThree()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(108.746f, 83.557f, 98.449f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.rotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
      

    }
    public IEnumerator showDiceNumberForFour()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(3.319f, 163.906f, 22.036f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.rotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        

    }
    public IEnumerator showDiceNumberForFive()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0f, 0f, 270f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.rotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
      

    }
    public IEnumerator showDiceNumberForSix()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(17.75f, 74.779f, -3.359f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.rotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
       
    }


    public IEnumerator ResetDicePosition()
    {
        yield return new WaitForSeconds(0);
        rb.useGravity = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = diceResetPosition.transform.position;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0f, 0f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.rotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        hasLanded = false;
        thrown = false;
        diceValue = 0;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;



    }
    public int GetDiceValue()
    {
        return diceValue;
    }
}

