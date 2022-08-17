using UnityEngine;
public interface IPool 
{
    public void InitPool(int amountToPool);
    public void GenerateObject();
    public GameObject GetObject();
    public void ReturnObject(GameObject gameObject);
}
