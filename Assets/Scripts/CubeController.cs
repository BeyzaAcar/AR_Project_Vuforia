using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isMoving = false;
    private Coroutine currentRoutine;

    // X ve Y eksenindeki sınırlar, karenin köşe koordinatları
    private float xMin = -1f, xMax = 1f;
    private float yMin = -2f, yMax = 2f;

    private void Start()
    {
        // Başlangıç konumunu ve rotasyonunu kaydet
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void MoveAround()
    {
        if (isMoving)
        {
            StopCurrentRoutine();
            StartCoroutine(ResetToStartPosition(() => currentRoutine = StartCoroutine(MoveAroundRoutine())));
        }
        else
        {
            currentRoutine = StartCoroutine(MoveAroundRoutine());
        }
    }

    private IEnumerator MoveAroundRoutine()
    {
        isMoving = true;

        // Sınırlı kare kenarları boyunca saat yönünde hareket et
        Vector3[] points = new Vector3[]
        {
            new Vector3(xMax, yMax, transform.position.z),   // Sağ üst köşe
            new Vector3(xMax, yMin, transform.position.z),   // Sağ alt köşe
            new Vector3(xMin, yMin, transform.position.z),   // Sol alt köşe
            new Vector3(xMin, yMax, transform.position.z)    // Sol üst köşe
        };

        int currentPoint = 0;
        
        while (true)
        {
            Vector3 targetPoint = points[currentPoint];
            while (Vector3.Distance(transform.position, targetPoint) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint, 5f * Time.deltaTime);
                yield return null;
            }

            // Sıradaki köşeye geç
            currentPoint = (currentPoint + 1) % points.Length;
        }
    }

    public void StartRotation()
    {
        if (isMoving)
        {
            StopCurrentRoutine();
            StartCoroutine(ResetToStartPosition(() => currentRoutine = StartCoroutine(RotateCube())));
        }
        else
        {
            currentRoutine = StartCoroutine(RotateCube());
        }
    }

    private IEnumerator RotateCube()
    {
        isMoving = true;
        while (true)
        {
            transform.Rotate(Vector3.up, 100 * Time.deltaTime); // Kendi etrafında döner
            yield return null;
        }
    }

    public void CustomMove()
    {
        if (isMoving)
        {
            StopCurrentRoutine();
            StartCoroutine(ResetToStartPosition(() => currentRoutine = StartCoroutine(CustomMoveRoutine())));
        }
        else
        {
            currentRoutine = StartCoroutine(CustomMoveRoutine());
        }
    }

    private IEnumerator CustomMoveRoutine()
    {
        isMoving = true;

        while (true)
        {
            // Rastgele hedef noktaları belirli sınırlar dahilinde seç
            Vector3 targetPosition = new Vector3(
                Random.Range(xMin, xMax),
                Random.Range(yMin, yMax),
                transform.position.z
            );
            
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(1f); // Her hedefe ulaştığında kısa bir süre bekler
        }
    }

    private IEnumerator ResetToStartPosition(System.Action onComplete)
    {
        isMoving = false;

        // Küpü başlangıç konumuna geri döndür
        while (Vector3.Distance(transform.position, startPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 5f * Time.deltaTime);
            yield return null;
        }

        // Rotasyonu da başlangıç pozisyonuna ayarla
        transform.rotation = startRotation;
        onComplete.Invoke(); // Reset tamamlandığında yeni hareketi başlat
    }

    private void StopCurrentRoutine()
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
            currentRoutine = null;
        }
    }
}
