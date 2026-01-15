# VRTrashRepo

VR環境でゴミ拾いを楽しめるUnityゲームプロジェクト

## 📝 プロジェクト概要

VRTrashRepoは、Meta Quest（Oculus）向けに開発されたVRゴミ拾いゲームです。プレイヤーはVR空間内でゴミを拾い、制限時間内にスコアを競います。


## ✨ 主な機能

- **VRインタラクション**: Meta XR SDKを使用したVR操作
- **スコアシステム**: ゴミを拾うとポイントが加算される
- **タイマー機能**: 制限時間内にゲームをクリア
- **マルチシーン構成**: タイトル画面、ゲーム画面、リザルト画面
- **効果音**: ゴミ拾い時のSE実装
- **ランダム生成**: マップ上にゴミがランダムに配置される

## 🛠️ 技術スタック

- **Unity**: ゲームエンジン
- **Meta XR SDK**: Oculus/Meta Quest対応
- **XR Interaction Toolkit**: VRインタラクション実装
- **TextMesh Pro**: UI表示
- **C++/C**: ネイティブコード（87.1% C++、12.9% C）

## 📂 プロジェクト構造

```
VRTrashRepo/
└── VRTrashUnity/          # Unityプロジェクトフォルダ
    ├── Assets/            # アセットフォルダ
    │   ├── Scenes/       # ゲームシーン
    │   │   ├── BaseScene.unity
    │   │   ├── BasicScene.unity
    │   │   ├── SampleScene.unity
    │   │   └── GameOverScene.unity
    │   ├── AddScript/    # スクリプトフォルダ
    │   ├── Objects/      # ゴミなどのオブジェクト
    │   ├── MetaXR/       # Meta XR SDK
    │   ├── Oculus/       # Oculus統合
    │   ├── Resources/    # リソースファイル
    │   ├── Settings/     # プロジェクト設定
    │   └── ...
    ├── Packages/         # Unityパッケージ
    ├── ProjectSettings/  # プロジェクト設定
    └── BuildData/        # ビルドデータ
```

## 🎮 ゲームの流れ

1. **タイトルシーン**: スタートボタンでゲーム開始
2. **ゲームシーン**: VR空間でゴミを拾ってスコアを獲得
3. **タイマー**: 制限時間が0になるとゲーム終了
4. **リザルトシーン**: 獲得したスコアを表示

### 点数
ペットボトル：２００

缶：１８０

瓶：１５０


## 🚀 セットアップ

### 必要な環境

- Unity 2021.3以降（推奨）
- Meta Quest 2 / Quest Pro / Quest 3
- Windows 10/11（開発環境）

### インストール手順

1. リポジトリをクローン
```bash
git clone https://github.com/JamterFondy/VRTrashRepo.git
```

2. Unityで`VRTrashUnity`フォルダを開く

3. Meta XR SDKとXR Interaction Toolkitが自動的にインポートされます

4. Build Settings > Android に切り替え

5. Meta Questを接続してビルド

## 🎯 開発の進行状況

- ✅ VR操作の実装
- ✅ スコアシステムの実装
- ✅ タイマー機能の実装
- ✅ シーン遷移の実装
- ✅ 効果音の実装
- ✅ ゴミのランダム生成
- ✅ UIの配置調整

## 👥 コントリビューター

- [JamterFondy](https://github.com/JamterFondy)
- [shuyaad](https://github.com/shuyaad)
- [Yuji-ctrl](https://github.com/Yuji-ctrl)


## 🔧 開発メモ

最終更新: 2026年1月

開発中の課題や今後の改善点については、Issuesをご確認ください。
