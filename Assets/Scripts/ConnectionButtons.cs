using Unity.Netcode;
using UnityEngine;

public class ConnectionButtons : MonoBehaviour
{
    public void StartAsHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void JoinAsClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
