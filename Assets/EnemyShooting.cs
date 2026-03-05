using UnityEngine;

// 敵が一定時間ごとに弾を発射するスクリプト
public class EnemyShooting : MonoBehaviour
{
    [Header("弾の設定")]

    // 発射する弾のPrefab
    // Inspectorから設定する
    public GameObject bulletPrefab;

    // 弾を発射する位置
    // Enemyの子オブジェクトなどを指定しておくと便利
    public Transform firePoint;

    // 弾を発射する間隔（秒）
    public float fireInterval = 1.0f;

    // 発射タイミングを管理するタイマー
    private float timer;

    void Update()
    {
        // 毎フレーム、経過時間を加算する
        // Time.deltaTime は「前フレームからの経過時間（秒）」
        timer += Time.deltaTime;

        // 指定した発射間隔を超えたら弾を発射
        if (timer >= fireInterval)
        {
            Shoot();

            // タイマーをリセット
            timer = 0f;
        }
    }

    // 弾を発射する処理
    void Shoot()
    {
        // bulletPrefab を生成する
        // 位置 : firePoint.position
        // 回転 : firePoint.rotation
        BulletManager.Instance.SpawnBullet(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
            );
    }
}