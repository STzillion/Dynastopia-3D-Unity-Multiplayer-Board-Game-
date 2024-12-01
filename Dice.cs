using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Rigidbody rb;

    public bool hasLanded;
    public bool thrown;
    private Renderer rend;
    private BoxCollider diceChaseCollider;
    public GameManager gameManager;
    public objectMovement ObjectMovement;

    public AudioSource RollDiceAudio;

    Vector3 initPosition;

    public int diceValue;

    public DiceSide[] diceSides;

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

        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            SideValueCheck();


        }
        else if (rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            if(gameManager.isPlayerRollingDiceMove && gameManager.isPlayerRollingDiceRobBank == false)
            {
                if (gameManager.playerList[gameManager.activePlayer].position == 0 || gameManager.playerList[gameManager.activePlayer].position <= 20)
                {
                    RollAgain();

                }
                else if (gameManager.playerList[gameManager.activePlayer].position >= 21 && gameManager.playerList[gameManager.activePlayer].position <= 30)
                {
                    RollAgainSecondLine();
                }
                else if (gameManager.playerList[gameManager.activePlayer].position >= 31 && gameManager.playerList[gameManager.activePlayer].position <= 49)
                {
                    RollAgainThirdLine();
                }
                else if (gameManager.playerList[gameManager.activePlayer].position >= 50 && gameManager.playerList[gameManager.activePlayer].position <= 58)
                {
                    RollAgainFourthLine();
                }
            }
            else if(gameManager.isPlayerRollingDiceRobBank == true)
            {
                if (ObjectMovement.routePosition == 0 ||ObjectMovement.routePosition <= 11)
                {
                    RollAgain();

                }
                else if (ObjectMovement.routePosition >= 12 && ObjectMovement.routePosition <= 18)
                {
                    RollAgainSecondLine();
                }
                else if (ObjectMovement.routePosition >= 19 && ObjectMovement.routePosition <= 28)
                {
                    RollAgainThirdLine();
                }
                else if (ObjectMovement.routePosition >= 29 && ObjectMovement.routePosition <= 34)
                {
                    RollAgainFourthLine();
                }
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
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        Vector3 ForwardOfCamera = -Camera.main.transform.forward * distanceFromObject;
        diceTransform.position = Camera.main.transform.position + ForwardOfCamera;
        diceTransform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

        thrown = true;
        rb.useGravity = true;
        rb.AddForce(Random.Range(2400, 2600), Random.Range(-100, -300), (0));
        rb.AddTorque((2000000),(10000000),(8000));
        RollDiceAudio.Play();

    }
    public IEnumerator RollDiceSecondLineFunction()
    {
        yield return new WaitForSeconds(0f);
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        Vector3 ForwardOfCamera = Camera.main.transform.forward * distanceFromObject;
        diceTransform.position = Camera.main.transform.position + ForwardOfCamera;
        diceTransform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        thrown = true;
        rb.useGravity = true;
        rb.AddForce((0), Random.Range(100, 300), Random.Range(1600, 1900));
        rb.AddTorque((2000000), (10000000), (8000));
        RollDiceAudio.Play();

    }
    public IEnumerator RollDiceThirdLineFunction()
    {
        yield return new WaitForSeconds(0f);
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        Vector3 ForwardOfCamera = -Camera.main.transform.forward * distanceFromObject;
        diceTransform.position = Camera.main.transform.position + ForwardOfCamera;
        diceTransform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

        thrown = true;
        rb.useGravity = true;
        rb.AddForce(Random.Range(-1600, -1900), Random.Range(100, 300), (0));
        rb.AddTorque((-2000000), (-10000000), (-8000));
        RollDiceAudio.Play();

    }

    public IEnumerator RollDiceFourthLineFunction()
    {
        yield return new WaitForSeconds(0f);
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = true;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        Vector3 ForwardOfCamera = Camera.main.transform.forward * distanceFromObject;
        diceTransform.position = Camera.main.transform.position + ForwardOfCamera;
        diceTransform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        thrown = true;
        rb.useGravity = true;
        rb.AddForce((0), Random.Range(100, 300), Random.Range(-1600, -1900));
       rb.AddTorque((-2000000),(-10000000),(-8000));
        RollDiceAudio.Play();


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


    public void showDiceForRobberyOne()
    {
        StartCoroutine(showDiceRobberyNumberOne());
    }

    public void showDiceForRobberyTwo()
    {
        StartCoroutine(showDiceRobberyNumberTwo());
    }

    public void showDiceForRobberyThree()
    {
        StartCoroutine(showDiceRobberyNumberThree());
    }

    public void showDiceForRobberyFour()
    {
        StartCoroutine(showDiceRobberyNumberFour());
    }

    public void showDiceForRobberyFive()
    {
        StartCoroutine(showDiceRobberyNumberFive());
    }

    public void showDiceForRobberySix()
    {
        StartCoroutine(showDiceRobberyNumberSix());
    }

    public void ResetDicePositionVoid()
    {
        StartCoroutine(ResetDicePosition());
    }
    public IEnumerator showDiceNumberForOne()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, 180f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
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
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(270f, 0f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
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
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, 270f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
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
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, 90f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
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
            Quaternion startRotation = transform.localRotation;
            Quaternion endRotation = Quaternion.Euler(90f, 0f, 0f);

            float elapsedTime = 0f;
            float duration = 0.4f; // Adjust duration as needed for the desired speed

            while (elapsedTime < duration)
            {
                // Incrementally move and rotate the dice
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
                transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

                // Update time
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            // Ensure final position and rotation are set correctly
            transform.position = endPosition;
            transform.localRotation = endRotation;
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
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, 0f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;


    }

    public IEnumerator showDiceRobberyNumberOne()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, 180f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    public IEnumerator showDiceRobberyNumberTwo()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(270f, 0f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

    }

    public IEnumerator showDiceRobberyNumberThree()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, 270f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

    }
    public IEnumerator showDiceRobberyNumberFour()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, 90f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }
    public IEnumerator showDiceRobberyNumberFive()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(90f, 0f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }
    public IEnumerator showDiceRobberyNumberSix()
    {
        rb.useGravity = false;
        diceChaseCollider = GetComponent<BoxCollider>();
        diceChaseCollider.enabled = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, 0f, 0f);

        float elapsedTime = 0f;
        float duration = 0.4f; // Adjust duration as needed for the desired speed

        while (elapsedTime < duration)
        {
            // Incrementally move and rotate the dice
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);

            // Update time
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure final position and rotation are set correctly
        transform.position = endPosition;
        transform.localRotation = endRotation;
        rend = GetComponent<Renderer>();
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    public IEnumerator ResetDicePosition()
    {
        yield return new WaitForSeconds(0);
        rb.useGravity = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Camera.main.transform.position;
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
       



    }
    public int GetDiceValue()
    {
        return diceValue;
    }
}

