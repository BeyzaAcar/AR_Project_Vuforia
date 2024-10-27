using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 2.0f;  // Hareket hızı
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Kullanıcının ok tuşlarına göre hareket yönünü belirle
        float moveX = Input.GetAxis("Horizontal"); // Sol-sağ hareket
        float moveZ = Input.GetAxis("Vertical");   // İleri-geri hareket

        // Hareket vektörü oluştur
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;

        // Nesnenin pozisyonunu güncelle
        transform.Translate(move);
    }
}
