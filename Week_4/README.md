
<!-- # ![mg-builder](/img~/mg-builder.png) -->

# Lesson 3

Developing Mobile Game lesson for Ankara university - Week 3

At the beginning of the lesson , "Package Manager" will be mentioned.
Then we will import Dotween and CartoonFX unitypackages from asset store.


  ## Demo 1

* Run Particle Effect
* Instantiate command
* Rigidbody.AddForce command

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo12.png"></td>

  </tr>
 </table>

```csharp

public class Demo12 : MonoBehaviour
{

    public GunBehaviour GunBehaviour;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GunBehaviour.Shoot();
        }
    }
}

```

```csharp

public class GunBehaviour : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletReference;

    public const float velocity = 5000;

    public void Shoot()
    {
        var bullet = Instantiate(Bullet, BulletReference.position, Quaternion.identity);
        var rgb = bullet.GetComponent<Rigidbody>();
        rgb.AddForce(BulletReference.forward * velocity, ForceMode.Force);
    }
}

```

  ## Demo 2

* PingPong Motion

 ```csharp

public class Demo2Run : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rgb;

    private void Start()
    {
    }

    private void Update()
    {
        Slide(tr, Vector3.right);
    }

    void Slide(Transform target, Vector3 railDirection)
    {
        Vector3 heading = target.position - transform.position;
        Vector3 force = Vector3.Project(heading, railDirection);

        rgb.AddForce(force);
    }

}

  ```

  ## Demo 3

* Dotween

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo7.png"></td>

  </tr>
 </table>

 ```csharp

public class Demo7_Object1 : MonoBehaviour
{
    private void Start()
    {
        Tween tween =
         transform.DOMoveX(2f, 2f)
        .SetRelative(false) // move to relative position
        .SetEase(Ease.OutQuad)
        .SetDelay(5f)
        .SetSpeedBased(false) // zaman yerine hiz
        .SetId("PlayerMove")
        .SetLoops(5, LoopType.Yoyo);

        tween.onComplete = delegate { Debug.Log("onComplete"); };
        tween.onStepComplete = delegate { Debug.Log("onStepComplete"); };
        tween.onKill = delegate { Debug.Log("onKill"); };

        tween.Play();

        transform.DORotate(Vector3.up * 360, 2, RotateMode.FastBeyond360)
            .SetLoops(5, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}

  ```

[👉 Learn more about Dotween](https://yasirkula.com/2018/07/04/unity-dotween-kullanimi/)

  ## Demo 4

* Time class

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo8.png"></td>

  </tr>
 </table>

 ```csharp

public class Demo8 : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DisplayCommandIEnumerator());
    }

    IEnumerator DisplayCommandIEnumerator()
    {
        var yieldReturn = new WaitForSeconds(1f);

        while (true)
        {
            yield return yieldReturn;

            Debug.Log($" Time.time {Time.time}");
            Debug.Log($" Time.realtimeSinceStartup {Time.realtimeSinceStartup}");
            Debug.Log($" Time.captureDeltaTime {Time.captureDeltaTime}");
            Debug.Log($" Time.fixedDeltaTime {Time.fixedDeltaTime}");
            Debug.Log($" Time.frameCount {Time.frameCount}");
            Debug.Log($" Time.deltaTime {Time.deltaTime}");
            Debug.Log($" Time.unscaledDeltaTime {Time.unscaledDeltaTime}");
            Debug.Log($" Time.captureFramerate {Time.captureFramerate}");
            Debug.Log($" Time.fixedTime {Time.fixedTime}");
            Debug.Log($" Time.unscaledTime {Time.unscaledTime}");
            Debug.Log($" Time.timeSinceLevelLoad {Time.timeSinceLevelLoad}");
            Debug.Log($" Time.timeAsDouble {Time.timeAsDouble}");
            Debug.Log($" Time.fixedUnscaledTimeAsDouble {Time.fixedUnscaledTimeAsDouble}");

        }
    }
}

  ```

[👉 Learn more about Time Class](https://docs.unity3d.com/ScriptReference/Time.html)


  ## Demo 5

* Camera - Viewport Rect 

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo9.png"></td>

  </tr>
 </table>



 ## Demo 6

* Scriptable Objects

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo10.png"></td>

  </tr>
 </table>

 ```csharp

[CreateAssetMenu(menuName = "Scriptable Objects/Demo10", fileName = "Demo10", order = 1001)]
public class Demo10 : ScriptableObject
{
    public float period;
}


public class Demo10Manager : MonoBehaviour
{
    public Demo10 demo10;

    private void Start()
    {
        StartCoroutine(DebugLogIEnumerator());
    }

    IEnumerator DebugLogIEnumerator()
    {
        var yieldReturn = new WaitForSeconds(demo10.period);

        while (true)
        {
            yield return yieldReturn;

            Debug.Log("Log");
        }

    }
}

```

[👉 Learn more about Scriptable Object](https://docs.unity3d.com/Manual/class-ScriptableObject.html)



 ## Demo 7

* Vector3.Slerp
* Sun Rise Motion



 ```csharp


public class Run : MonoBehaviour
{

    public Transform sunrise;
    public Transform sunset;

    // Time to move from sunrise to sunset position, in seconds.
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;

    void Start()
    {
        // Note the time at the start of the animation.
        startTime = Time.time;
    }

    void Update()
    {
        // The center of the arc
        Vector3 center = (sunrise.position + sunset.position) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0, 10, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;

        //  transform.position = Vector3.SlerpUnclamped(riseRelCenter, setRelCenter, fracComplete);
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
    }

}

```


  ## Demo 8

* Material
* Standart Shader

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo5.png"></td>

  </tr>
 </table>

[👉 Learn more about Material](https://docs.unity3d.com/ScriptReference/Material.html)

  ## Demo 9

* Particle System

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo6.png"></td>

  </tr>
 </table>

[👉 Learn more about Particle System](https://docs.unity3d.com/ScriptReference/ParticleSystem.html)


## Resources

- [:book: Scriptable Object](https://www.youtube.com/watch?v=BFYRUDk6TDs)
- [:book: Particle System](https://www.youtube.com/watch?v=FEA1wTMJAR0)
- [:book: Movement](https://www.youtube.com/watch?v=ixM2W2tPn6c)

## Next Lesson Topics

- Rigidbody
- Colliders
- Gravity
- Physic materials, bounce, colliding
- Raycasting
- Collision matrix 

