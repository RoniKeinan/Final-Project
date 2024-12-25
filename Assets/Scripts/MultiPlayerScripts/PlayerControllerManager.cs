using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerControllerManager : MonoBehaviour
{
    PhotonView view;

    void Awake()
    {
        view = GetComponent<PhotonView>();
    }
    void Start()
    {
        if(view.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RPM Player"), Vector3.zero, Quaternion.identity);

    }
}
