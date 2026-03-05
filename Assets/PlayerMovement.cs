using UnityEngine;

// プレイヤーの移動処理を行うスクリプト
public class PlayerMovement : MonoBehaviour
{
    // プレイヤーの移動速度
    public float speed = 2f;

    void Update()
    {
        // キーボード入力を取得
        // Horizontal : A/Dキー または ←/→キー
        // Vertical   : W/Sキー または ↑/↓キー
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 移動方向ベクトルを作成
        // normalized を使うことで、斜め移動時の速度が速くなるのを防ぐ
        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;

        // プレイヤーの位置を移動させる
        // Time.deltaTime を掛けることでフレームレートに依存しない移動になる
        transform.position += movement * speed * Time.deltaTime;

        // プレイヤーの現在位置を取得し、画面外に出ないように制限する
        // Mathf.Clamp(値, 最小値, 最大値)
        // x座標は -8 ～ 8 の範囲に制限
        float x = Mathf.Clamp(transform.position.x, -8f, 8f);

        // y座標は -4 ～ 4 の範囲に制限
        float y = Mathf.Clamp(transform.position.y, -4f, 4f);

        // 制限後の座標をプレイヤーの位置として再設定
        transform.position = new Vector3(x, y, 0f);
    }
}
