using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine.UI;

public class MyPlayer : MonoBehaviourPun {


    public float Speed = 10f;
    public float Health = 100;
    public Image healthBar;
    public Transform shotPos;
    public GameObject bulletPrefab;

    private void Start()
    {
        if (photonView.IsMine)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void Update()
    {
        healthBar.fillAmount = Health / 100;

        if (photonView.IsMine)
        {
            InputMovement();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        ChangeHealth(-10);
    }

    void ChangeHealth(float value)
    {
        Health += value;
    }

    // used as Observed component in a PhotonView, this only reads/writes the position
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            Vector3 pos = transform.localPosition;
            stream.Serialize(ref pos);
            stream.SendNext(Health);
        }
        else
        {
            Vector3 pos = Vector3.zero;
            stream.Serialize(ref pos);  // pos gets filled-in. must be used somewhere
            Health = (float)stream.ReceiveNext();
        }
    }

    void Fire()
    {
        PhotonNetwork.Instantiate(bulletPrefab.name, shotPos.transform.position, shotPos.rotation);
    }

    void InputMovement()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime* 100;
        float v = Input.GetAxis("Vertical") * Time.deltaTime* Speed;

        transform.Translate(0, 0, v);
        transform.Rotate(0, h, 0);
    }
}
