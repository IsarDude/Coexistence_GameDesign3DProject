using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    bool isKeyValid = false;
    bool locked = true;
    string keyId = "DrawbridgeKey";
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SetKeyId(string KeyId)
    {
        
        keyId = KeyId;
    }

   public bool CheckKey(GameObject key)
    {
        if(keyId == key.GetComponent<Key>().keyId)
        {
            isKeyValid = true;
            key.SetActive(false);
            
        }
        Debug.Log("Unlockable: " + isKeyValid);
        return isKeyValid;
    }

    
}
