using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTrapController : MonoBehaviour
{
  public GameObject SkyTrapObject;
    private void Start() {
        StartCoroutine(skyTrap());
    }


   IEnumerator skyTrap()
   {
      while (true)
      {
      Vector3 poz = new Vector3(Random.Range(-65, 72), transform.position.y, Random.Range(10, 100));
      Instantiate(SkyTrapObject, poz, transform.rotation);//SkyTrapObject prefabı yaratır
      yield return new WaitForSeconds(7f);//7 saniye bekle
      } 
   }
}
