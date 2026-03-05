using UnityEngine;

// 弾の生成を管理するクラス
public class BulletManager : MonoBehaviour
{
    // シングルトン（どこからでもアクセスできるようにする）
    public static BulletManager Instance;

    void Awake()
    {
        // 既にInstanceが存在する場合は削除
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // 弾を生成するメソッド
    public GameObject SpawnBullet(GameObject bulletPrefab, Vector3 position, Quaternion rotation)
    {
        // 弾を生成
        GameObject bullet = Instantiate(bulletPrefab, position, rotation);

        return bullet;
    }
}