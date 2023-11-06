using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AmThanh : MonoBehaviour
{
    
   // public GameObject praticlePrefab;
    private AudioSource audio_src;
    public AudioClip fili_amthanh;
    void Start()
    {
        audio_src = GetComponent<AudioSource>();
        audio_src.clip = fili_amthanh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="nhanvat")
        {
            audio_src.Play();
            Invoke("DungNhac", 0.5f);
           
        }
    }

    void DungNhac()
    {
        audio_src.Stop();
    }
    // void ShowParticles()
    // {
    //     // Tạo một đối tượng hạt từ prefab
    //     GameObject particle = Instantiate(praticlePrefab, transform.position, Quaternion.identity);
    //   
    //     ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
    //     particleSystem.Play();
    //
    //     Debug.Log(particle.transform.position.ToString());
    //
    //     // Hủy bỏ hạt sau một khoảng thời gian ngẫu nhiên
    //     // Destroy(particle, Random.Range(5.0f, 7.0f));
    // }
}
