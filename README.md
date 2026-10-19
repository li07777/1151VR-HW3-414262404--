# 1151VR-HW3-414262404-李姍霓

**作業名稱：** Unity 2D 今天吃什麼？幸運輪盤（Food Roulette）

## 一、作業目的

本次作業使用 Unity 6 建立 2D 輪盤遊戲，透過 C# 程式控制輪盤旋轉，實作點擊後加速、持續旋轉、逐漸減速及停止的效果，並加入音效與互動功能。

本次以「今天吃什麼？」作為遊戲主題，設計粉紅色系的美食輪盤，讓玩家透過轉動輪盤決定餐點，增加遊戲的趣味性與實用性。

## 二、使用工具

- Unity 6
- C#
- Visual Studio Code
- TextMeshPro
- GitHub
- Unity Remote 5（iPhone 測試）

## 三、遊戲內容與功能

### 1. 美食輪盤

遊戲採用粉紅色系設計，包含八種餐點選項：

1. 火鍋（Hot Pot）
2. 拉麵（Ramen）
3. 壽司（Sushi）
4. 義大利麵（Pasta）
5. 速食（Fast Food）
6. 韓式料理（Korean Food）
7. 飲料（Drinks）
8. 甜點（Dessert）

輪盤上方設置固定指針，用於顯示最終抽中的餐點。

### 2. 輪盤旋轉控制

使用 C# 撰寫 `RouletteController.cs`，控制輪盤的旋轉動作。

玩家點擊遊戲畫面後，輪盤先逐漸加速，達到最大旋轉速度後持續轉動一段時間，再透過衰減係數逐漸降低速度，最後完全停止。

主要使用：

- `Input.GetMouseButtonDown(0)`：偵測滑鼠點擊。
- `Time.deltaTime`：讓旋轉速度不受影格率影響。
- `Mathf.MoveTowards()`：控制加速。
- `Mathf.Pow()`：實作逐漸減速。
- `transform.Rotate()`：控制輪盤沿 Z 軸旋轉。

### 3. 音效功能

使用 Unity 的 `Audio Source` 元件加入兩種音效：

- **旋轉音效：** 輪盤開始轉動時播放，停止旋轉時停止。
- **結果音效：** 輪盤完全停止後，播放一次提示音效。

透過程式中的 `Play()` 與 `Stop()` 控制音效播放時機。

### 4. 抽獎結果判斷

輪盤停止後，程式會取得輪盤目前的 Z 軸旋轉角度，再根據八個扇形的角度範圍，判斷指針所指向的餐點。

每個扇形占 45 度，依照指針位置與輪盤旋轉角度計算結果。

### 5. 結果視窗與重新旋轉

使用 `Canvas`、`Panel`、`TextMeshPro` 和 `Button` 製作結果視窗。

輪盤停止後，畫面會顯示英文抽獎結果，例如：

```text
WHAT TO EAT TODAY?

You got: Sushi!

Enjoy your meal!
```

玩家可以點擊 **SPIN AGAIN** 按鈕，再次啟動輪盤。

### 6. 手機操作測試

針對 iPhone 操作進行 Unity Remote 5 測試，使用 USB 連接 Windows 電腦與 iPhone，並在 Unity Editor 設定 Unity Remote 裝置。

測試項目包含畫面顯示、觸控操作、輪盤旋轉、結果視窗與音效。

**手機測試結果：<img width="2622" height="1206" alt="S__136953859" src="https://github.com/user-attachments/assets/36c96213-7b13-4705-946c-e59f5b5d2268" />


## 四、製作流程

### Step 1：建立 Unity 2D 專案

透過 Unity Hub 建立 2D 專案，新增 `Images`、`Scripts` 與 `Audio` 資料夾，整理專案素材。

### Step 2：匯入輪盤與指針圖片

將輪盤和指針 PNG 匯入 Unity，設定為 `Sprite (2D and UI)`，並拖曳至 Scene。

調整 `Transform`，將輪盤放置於畫面中央，指針固定於輪盤上方。

### Step 3：撰寫輪盤控制程式

建立 `RouletteController.cs`，加入滑鼠點擊偵測、旋轉速度、加速度、旋轉時間與衰減係數等功能。

### Step 4：加入音效

匯入旋轉及結果音效，使用 `Audio Source` 元件進行設定，並透過 C# 控制播放與停止。

### Step 5：製作結果視窗

建立 `GameCanvas`、`ResultPanel`、`ResultText` 與 `RetryButton`，設計輪盤停止後的結果顯示畫面。

### Step 6：實作結果判斷與重新旋轉

使用輪盤停止時的角度計算抽獎結果，並透過 `Button` 的點擊事件執行重新旋轉功能。

### Step 7：調整遊戲畫面

修改攝影機背景顏色，配合粉紅色美食輪盤的視覺風格，並調整結果文字、按鈕位置與畫面比例。

### Step 8：遊戲測試

在 Unity Game 視窗測試輪盤加速、減速、停止、音效與結果視窗，並進行手機連線與操作測試。

## 五、專案截圖

> 請將實際截圖放進 GitHub Repository 的 `Screenshots` 資料夾，並依下列檔名儲存。原始文件中的 `image` 是圖片預留位置，圖片檔並未包含在本 README 中。

### 圖一：Unity 專案場景

[圖一：Unity 專案場景](<img width="600" height="1292" alt="螢幕擷取畫面 2026-10-19 193243" src="https://github.com/user-attachments/assets/9c85c63f-5b03-4402-aaf5-bb20c86a128f" />
)

### 圖二、三：輪盤控制程式


[圖二：輪盤控制程式（上）](<img width="600" height="1292" alt="螢幕擷取畫面 2026-10-19 193243" src="https://github.com/user-attachments/assets/e30ae1f1-014c-48c5-9790-6215a0434e2d" />

[圖三：輪盤控制程式（下）](<img width="454" height="1402" alt="螢幕擷取畫面 2026-10-19 193306" src="https://github.com/user-attachments/assets/7c071f35-7529-4866-bae3-1d92418007c2" />
)

### 圖四：抽獎結果畫面

[圖四：抽獎結果畫面](<img width="2880" height="1704" alt="螢幕擷取畫面 2026-10-19 193341" src="https://github.com/user-attachments/assets/d1d277a6-c0c4-4230-8913-f17ab1b6c2be" />
)


### 圖五：音效設定

[圖五：音效設定](<img width="684" height="666" alt="螢幕擷取畫面 2026-10-19 193435" src="https://github.com/user-attachments/assets/ea89a117-d376-4f4e-be86-f788d6b93566" />
)

### 圖六：手機操作測試

[圖六：手機操作測試](<img width="2622" height="1206" alt="S__136953859" src="https://github.com/user-attachments/assets/ec9a3c99-b9e9-4e0a-bebc-9db718e8b4ec" />
)


## 六、GitHub 專案連結

**GitHub 網址：** [1151VR-HW3-414262404--](https://github.com/li07777/1151VR-HW3-414262404--)

## 七、YouTube 遊戲展示影片

**影片網址：** [Unity HW3 遊戲展示](https://youtu.be/bLPqvhnYChM)

## 八、製作心得

透過本次作業，我練習了 Unity 2D 遊戲物件的配置，以及使用 C# 腳本控制物件旋轉。除了課堂要求的輪盤旋轉及減速功能外，我也嘗試加入音效、結果判斷與重新旋轉按鈕，讓原本單純的旋轉效果變成具有互動性的美食選擇遊戲。製作過程中，我也學習到 TextMeshPro 字型設定、UI 元件綁定、Audio Source 控制，以及輪盤旋轉角度的計算方式。

另外，在手機測試過程中，也接觸到 Unity Remote 5 的連線設定與畫面比例問題，進一步了解電腦與手機在遊戲測試上的差異。這次作業讓我對 Unity 中的物件控制、腳本編寫及使用者互動有更完整的認識。
