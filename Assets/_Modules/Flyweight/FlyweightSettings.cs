using UnityEngine;

public enum FlyweightType {
    Bullet,
    Enemy,
}

[CreateAssetMenu(fileName = "FlyweightSettings", menuName = "Flyweight/FlyweightSettings", order = 0)]
public class FlyweightSettings : ScriptableObject {
    public FlyweightType type;
    public GameObject prefab;

    public virtual Flyweight Create() {
        var go = Instantiate(prefab);
        go.SetActive(false);
        go.name = prefab.name;

        var flyweight = go.AddComponent<Flyweight>();
        flyweight.settings = this;

        return flyweight;
    }

    public virtual void OnGet(Flyweight f) => f.gameObject.SetActive(true);
    public virtual void OnRelease(Flyweight f) => f.gameObject.SetActive(false);
    public virtual void OnDestroyPoolObject(Flyweight f) => Destroy(f.gameObject);
}