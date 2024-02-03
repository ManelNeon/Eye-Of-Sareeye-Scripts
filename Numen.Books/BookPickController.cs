using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPickController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().bookCount++;
            if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().bookCount == 1)
            {
                GameObject.Find("Canvas").GetComponent<ButtonControl>().LoreFirstOn();
            }
            Destroy(this.gameObject);
            if (this.gameObject.name == ("bookBeast"))
            {
                GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasBeastiary = true;
            }
            else if (this.gameObject.name == ("bookMaid"))
            {
                GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasMaid = true;
            }
            else if (this.gameObject.name == ("bookME"))
            {
                GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasMarmacEntity = true;
            }
            else if (this.gameObject.name == ("bookMarmac"))
            {
                GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasMarmacBio = true;
            }
            else if (this.gameObject.name == ("bookMap"))
            {
                GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasMap = true;
            }
        }
    }
}
