using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class PlayVideoOnDetection : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private ObserverBehaviour observerBehaviour;
    private MeshRenderer quadRenderer; // Quad'ın MeshRenderer bileşeni

    void Start()
    {
        // Image Target üzerindeki ObserverBehaviour ve VideoPlayer bileşenlerini bul
        observerBehaviour = GetComponent<ObserverBehaviour>();
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        quadRenderer = videoPlayer.GetComponent<MeshRenderer>(); // Quad'ın MeshRenderer'ını bul

        if (observerBehaviour)
        {
            // Algılama olaylarını dinle
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        if (videoPlayer)
        {
            videoPlayer.Pause(); // Başlangıçta videoyu durdur
        }

        if (quadRenderer)
        {
            quadRenderer.enabled = false; // Başlangıçta Quad'ı gizle
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Image Target algılandığında veya kaybolduğunda video oynatma durumunu kontrol et
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            // Image Target algılandığında videoyu başlat ve Quad'ı görünür yap
            if (videoPlayer && !videoPlayer.isPlaying)
            {
                videoPlayer.Play();
            }
            if (quadRenderer)
            {
                quadRenderer.enabled = true; // Quad'ı görünür yap
            }
        }
        else
        {
            // Image Target kaybolduğunda videoyu durdur ve Quad'ı gizle
            if (videoPlayer && videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
            }
            if (quadRenderer)
            {
                quadRenderer.enabled = false; // Quad'ı gizle
            }
        }
    }

    void OnDestroy()
    {
        // Olay aboneliğini kaldır
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
