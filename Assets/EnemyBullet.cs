using UnityEngine;

// 敵が発射する弾の動作を制御するスクリプト
public class EnemyBullet : MonoBehaviour
{
    // 弾の移動速度
    public float speed = 5f;

    void Update()
    {
        // 弾を左方向に移動させる
        // Vector2.left は (-1, 0) を表し、画面の左方向を意味する
        // speed を掛けることで移動速度を調整
        // Time.deltaTime を掛けることでフレームレートに依存しない移動になる
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 画面外に出たら弾を削除する
        CheckOutOfScreen();
    }

    // 画面外に出たかどうかをチェックする関数
    void CheckOutOfScreen()
    {
        // 現在の弾の位置を取得
        Vector3 pos = transform.position;

        // 画面外の範囲を設定（プレイヤーと同じ範囲より少し広め）
        if (pos.x < -10f || pos.x > 10f || pos.y < -6f || pos.y > 6f)
        {
            // 弾を削除
            Destroy(gameObject);
        }
    }
}