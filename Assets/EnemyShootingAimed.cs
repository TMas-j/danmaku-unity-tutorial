using UnityEngine;
using System.Collections;

// 敵が一定時間ごとにプレイヤーに向けて（自機狙い）弾を発射するスクリプト
public class EnemyShootingAimed : MonoBehaviour
{
    [Header("弾の設定")]

    // 発射する弾のPrefab
    // Inspectorから設定する
    public GameObject bulletPrefab;

    // 弾を発射する位置
    // Enemyの子オブジェクトなどを指定しておくと便利
    public Transform firePoint;

    // 弾を発射する間隔（秒）
    public float fireInterval = 0.2f;

    [Header("ターゲット")]
    
    // Playerの位置を取得する
    public Transform player;

    [Header("連射設定")]

    // 1回に連射する弾の数
    // 0以下なら連続射撃
    public int burstCount = 5;

    // 休憩時間
    // burstCountが0以下の時は無意味
    public float restTime = 1f;

    void Start()
    {
        // コルーチン開始
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            // burstCountが0以下なら連続射撃
            if (burstCount <= 0)
            {
                Shoot();
                yield return new WaitForSeconds(fireInterval);
            }
            else
            {
                // 指定回数(burstCount回)撃つ
                for (int i = 0; i < burstCount; i++)
                {
                    Shoot();
                    yield return new WaitForSeconds(fireInterval);
                }

                // 休憩(WaitForSeconds秒)
                yield return new WaitForSeconds(restTime);
            }
        }
    }

    // 弾を発射する処理
    void Shoot()
    {
        // bulletPrefab を生成
        // 位置 : firePoint.position
        // 回転 : firePoint.rotation
        GameObject bullet = BulletManager.Instance.SpawnBullet(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        // Playerの方向を計算
        Vector2 direction = (player.position - firePoint.position).normalized;

        // 生成した弾に方向を設定
        EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
        bulletScript.SetDirection(direction);
    }
}