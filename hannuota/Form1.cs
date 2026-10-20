using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; 
using System.IO;         
using Newtonsoft.Json;    
using Microsoft.VisualBasic;

namespace hannuota
{
    public partial class Form1: Form
    {

        // 常量
        private const int DiskHeight = 20; // 每个盘子的高度
        private const int PegBasePanelHeightAdjust = 20; // panelPegA/B/C的高度，用于计算盘子Y坐标

        // 游戏状态变量
        private int numberOfDisks;
        private Stack<Panel>[] pegs = new Stack<Panel>[3]; // 三个柱子，每个柱子是一个盘子(Panel)的栈
        private Panel[] pegBasePanels; // 存放 panelPegA, panelPegB, panelPegC，用于定位
        private Panel[] pegVisualPanels; // 存放 pegPanel1, pegPanel2, pegPanel3 (实际的柱子)

        private Panel selectedDisk = null; // 当前选中的盘子
        private int sourcePegIndex = -1;   // 选中盘子来源的柱子索引 (0, 1, or 2)
        private int movesCount = 0;

        // 盘子颜色 (可选，为了美观)
        private Color[] diskColors = new Color[] {
        Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue,
        Color.Indigo, Color.Violet, Color.Pink, Color.Brown, Color.Cyan
    };

        // 新增计时和计分相关
        private Stopwatch gameStopwatch = new Stopwatch();
        private const string HighScoresFileName = "hanoi_highscores.json";
        private List<ScoreEntry> highScores = new List<ScoreEntry>();

        // 计分参数 (可调整)
        private const int BaseScore = 100;
        private const int PenaltyPerExtraMove = 5;
        private const int PenaltyPerSecond = 1;

        private bool isAutoSolving = false; // 标记是否正在自动演示
        private const int AutoSolveDelay = 30; // 自动演示时每一步的延迟时间 (毫秒)


        struct HanoiStep
        {
            public int FromPeg { get; }
            public int ToPeg { get; }

            public HanoiStep(int from, int to)
            {
                FromPeg = from;
                ToPeg = to;
            }
        }

        public Form1()
        {
            InitializeComponent();

            // 设置窗体及其所有子控件的默认字体
            Font defaultFont = new Font("楷体", 10f, FontStyle.Regular, GraphicsUnit.Point);
            this.Font = defaultFont;

            

            InitializeGameControls(); // 初始化游戏控制相关的设置
            LoadHighScores(); // 在窗体加载时读取高分记录
            gameTimer.Tick += GameTimer_Tick; // 关联Timer的Tick事件

        }

        private void SetFontForAllControls(Control container, Font font)
        {
            foreach (Control control in container.Controls)
            {
                control.Font = font;
                if (control.HasChildren)
                {
                    SetFontForAllControls(control, font);
                }
            }
            
            if (!(container is Form)) 
            {
                container.Font = font;
            }
        }

        private void InitializeGameControls()
        {
            // 将设计器中的Panel放入数组，方便索引访问
            pegBasePanels = new Panel[] { panelPegA, panelPegB, panelPegC };
            pegVisualPanels = new Panel[] { pegPanel1, pegPanel2, pegPanel3 };


            // 初始化每个柱子的盘子栈
            for (int i = 0; i < 3; i++)
            {
                pegs[i] = new Stack<Panel>();
                // 给代表柱子的Panel（pegVisualPanels）也添加点击事件，用于放置盘子
                pegVisualPanels[i].Click += Peg_Click;
                pegVisualPanels[i].Tag = i; // 使用Tag存储柱子索引
            }
        }

     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStartReset_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // 0. 清理工作 (确保这个在最前面，只调用一次)
            ClearPreviousGame();

            // 1. 获取盘子数量
            numberOfDisks = (int)numDisksInput.Value;
            if (numberOfDisks <= 0) return;

            // 2. 重置游戏状态
            movesCount = 0;
            UpdateMovesLabel(); // 更新步数显示
            btnStartReset.Text = "重置游戏"; // 更改按钮文字
            lblTime.Text = "用时: 00m:00s"; // 重置计时器显示 (如果需要)

            

            // 3. 定义盘子尺寸和初始柱子 
            int initialPegIndex = 0; // 盘子初始放在第一个柱子 (peg A)

            // 调整盘子宽度计算逻辑 
            int maxDiskWidth = (pegVisualPanels[0] != null ? pegVisualPanels[0].Width + 80 : 140);
            int minDiskWidth = 40;
            if (numberOfDisks > 1)
            {
                maxDiskWidth = Math.Max(maxDiskWidth, minDiskWidth + (DiskHeight * (numberOfDisks - 1)));
            }
            else if (numberOfDisks == 1) // 确保单个盘子也有合理宽度
            {
                maxDiskWidth = Math.Max(maxDiskWidth, minDiskWidth); // 或直接设置为 minDiskWidth
            }


            // 4. 创建盘子并放置到第一个柱子
            for (int i = 0; i < numberOfDisks; i++)
            {
                Panel disk = new Panel();
                disk.Height = DiskHeight;

                if (numberOfDisks == 1)
                {
                    disk.Width = minDiskWidth; // 或者使用 (maxDiskWidth + minDiskWidth) / 2 等
                }
                else
                {
                    // 盘子宽度从大到小 (i=0是最大的盘子，在最下面)
                    disk.Width = maxDiskWidth - (i * (maxDiskWidth - minDiskWidth) / (numberOfDisks - 1));
                }

                disk.BackColor = diskColors[i % diskColors.Length]; // 循环使用颜色
                disk.BorderStyle = BorderStyle.FixedSingle;
                disk.Tag = disk.Width; // 用Tag存储盘子宽度，方便比较大小

                disk.Click += Disk_Click; // 给每个盘子添加点击事件

                this.Controls.Add(disk); // 将盘子添加到窗体控件集合中
                pegs[initialPegIndex].Push(disk); // 将盘子压入第一个柱子的逻辑栈
                disk.BringToFront(); // 确保盘子在柱子之上
            }

            // 5. 重新绘制所有柱子上的盘子位置
            RefreshAllPegsVisuals();

            // 6. 重置选中状态
            selectedDisk = null;
            sourcePegIndex = -1;

            // 7. 开始计时 (确保 StartGameTimer 方法已实现)
            StartGameTimer();
        }

        private void ClearPreviousGame()
        {
            // 移除旧的盘子 Panel 控件
            foreach (var pegStack in pegs)
            {
                if (pegStack != null)
                {
                    while (pegStack.Count > 0)
                    {
                        Panel disk = pegStack.Pop();
                        this.Controls.Remove(disk); // 从窗体控件中移除
                        disk.Dispose();              // 释放资源
                    }
                }
            }
            // 如果有选中的盘子，也清理掉
            if (selectedDisk != null)
            {
                if (this.Controls.Contains(selectedDisk))
                {
                    this.Controls.Remove(selectedDisk);
                }
                selectedDisk.Dispose();
                selectedDisk = null;
            }
            sourcePegIndex = -1;

            // 确保peg栈被重新初始化 (如果InitializeGameControls中已做，这里可省略部分)
            for (int i = 0; i < 3; i++)
            {
                if (pegs[i] == null)
                    pegs[i] = new Stack<Panel>();
                else
                    pegs[i].Clear();
            }
        }


        private void RefreshAllPegsVisuals()
        {
            for (int i = 0; i < 3; i++)
            {
                PositionDisksOnPeg(i);
            }
        }

        // 根据逻辑栈来定位盘子视觉位置
        private void PositionDisksOnPeg(int pegIndex)
        {
            Panel currentPegBase = pegBasePanels[pegIndex]; // 这是底座Panel，用于Y轴定位
            Panel currentPegVisual = pegVisualPanels[pegIndex]; // 这是柱子Panel，用于X轴定位

            int currentY = currentPegBase.Top - DiskHeight; // 第一个盘子在底座Panel的上方

            // 临时将栈中元素取出再放回，以正确的顺序（从下到上）定位
            Stack<Panel> tempStack = new Stack<Panel>();
            while (pegs[pegIndex].Count > 0)
            {
                tempStack.Push(pegs[pegIndex].Pop());
            }

            while (tempStack.Count > 0)
            {
                Panel disk = tempStack.Pop();
                disk.Left = currentPegVisual.Left + (currentPegVisual.Width / 2) - (disk.Width / 2);
                disk.Top = currentY;
                currentY -= DiskHeight; // 下一个盘子在此盘子之上
                pegs[pegIndex].Push(disk); // 放回原栈
            }
        }

        private void Disk_Click(object sender, EventArgs e)
        {
            if (isAutoSolving) return; // 如果正在自动演示，则不允许点击盘子

            Panel clickedDisk = sender as Panel;
            if (clickedDisk == null) return;

            // 找到这个盘子在哪个柱子上
            int currentPegIndex = -1;
            for (int i = 0; i < 3; i++)
            {
                if (pegs[i].Count > 0 && pegs[i].Peek() == clickedDisk)
                {
                    currentPegIndex = i;
                    break;
                }
            }

            if (currentPegIndex == -1) return; // 理论上不应发生，除非盘子不在栈顶

            if (selectedDisk == null) // 如果当前没有选中的盘子
            {
                // 只能选择柱子最上方的盘子
                if (pegs[currentPegIndex].Peek() == clickedDisk)
                {
                    selectedDisk = pegs[currentPegIndex].Pop(); // 从逻辑栈中取出
                    sourcePegIndex = currentPegIndex;

                    // 视觉上“提起”盘子 (可选，例如改变边框或Y坐标)
                    selectedDisk.Top -= 30; // 稍微向上移动一点
                    selectedDisk.BringToFront();
                    // 可以添加视觉提示，比如边框加粗
                    selectedDisk.BorderStyle = BorderStyle.Fixed3D;
                }
            }
            // 如果点击的是已选中的盘子，则取消选择（放回原处）
            else if (selectedDisk == clickedDisk)
            {
                // 放回原处
                pegs[sourcePegIndex].Push(selectedDisk);
                PositionDisksOnPeg(sourcePegIndex); // 重新定位原柱子上的盘子
                selectedDisk.BorderStyle = BorderStyle.FixedSingle; // 恢复边框
                selectedDisk = null;
                sourcePegIndex = -1;
            }
        }

        private void Peg_Click(object sender, EventArgs e)
        {
            if (isAutoSolving) return; // 如果正在自动演示，则不允许用户点击盘子

            if (selectedDisk == null) return; // 如果没有选中盘子，点击柱子无效

            Panel clickedPegVisual = sender as Panel; // 这里 sender 是 pegVisualPanel1, 2, or 3
            if (clickedPegVisual == null) return;

            int targetPegIndex = (int)clickedPegVisual.Tag; // 获取之前设置的柱子索引

            // 尝试移动盘子
            TryMoveDisk(targetPegIndex);
        }

        private void TryMoveDisk(int targetPegIndex)
        {
            if (selectedDisk == null) return; // 没有选中的盘子
            if (targetPegIndex == sourcePegIndex) // 不能移动到原柱子
            {
                // 用户可能想取消选择，将盘子放回原处
                pegs[sourcePegIndex].Push(selectedDisk);
                PositionDisksOnPeg(sourcePegIndex);
                selectedDisk.BorderStyle = BorderStyle.FixedSingle;
                selectedDisk = null;
                sourcePegIndex = -1;
                return;
            }

            // 检查移动是否有效：目标柱子为空，或者目标柱子顶部的盘子比当前选中的盘子大
            bool isValidMove = false;
            if (pegs[targetPegIndex].Count == 0) // 目标柱子为空
            {
                isValidMove = true;
            }
            else
            {
                Panel topDiskOnTargetPeg = pegs[targetPegIndex].Peek();
                // 用 Tag 中存储的宽度比较
                if ((int)selectedDisk.Tag < (int)topDiskOnTargetPeg.Tag)
                {
                    isValidMove = true;
                }
            }

            if (isValidMove)
            {
                pegs[targetPegIndex].Push(selectedDisk); // 放入目标柱子的逻辑栈
                PositionDisksOnPeg(targetPegIndex);      // 更新目标柱子的视觉效果
                selectedDisk.BorderStyle = BorderStyle.FixedSingle; // 恢复边框

                selectedDisk = null; // 清除选中状态
                sourcePegIndex = -1;

                movesCount++;
                UpdateMovesLabel();

                CheckWinCondition();
            }
            else
            {
                // 无效移动，盘子归位到原柱子
                MessageBox.Show("无效移动！不能将大盘子放在小盘子之上。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pegs[sourcePegIndex].Push(selectedDisk); // 逻辑上放回
                PositionDisksOnPeg(sourcePegIndex);      // 视觉上放回
                selectedDisk.BorderStyle = BorderStyle.FixedSingle; // 恢复边框
                selectedDisk = null;
                sourcePegIndex = -1;
            }
        }

        private void UpdateMovesLabel()
        {
            lblMoves.Text = "步数: " + movesCount;
        }

        private void CheckWinCondition()
        {
            if (numberOfDisks > 0 && pegs[2].Count == numberOfDisks)
            {
                if (pegs[0].Count == 0 && pegs[1].Count == 0)
                {
                    StopGameTimer(); // 停止计时
                    int finalScore = CalculateScore();

                    string playerName = Interaction.InputBox("恭喜你完成了游戏！请输入你的名字：", "胜利！", "玩家");

                    if (string.IsNullOrWhiteSpace(playerName))
                    {
                        playerName = "匿名玩家";
                    }

                    ScoreEntry currentEntry = new ScoreEntry(playerName, finalScore, movesCount, gameStopwatch.Elapsed, numberOfDisks, DateTime.Now);
                    highScores.Add(currentEntry);
                    // 可以按分数排序，如果列表不长，每次添加后排序也可以
                    highScores = highScores.OrderByDescending(s => s.Score).ThenBy(s => s.Moves).ThenBy(s => s.TimeTaken).ToList();
                    SaveHighScores();

                    MessageBox.Show($"恭喜 {playerName}！\n你用 {movesCount} 步完成了汉诺塔！\n用时: {gameStopwatch.Elapsed.Minutes:D2}m:{gameStopwatch.Elapsed.Seconds:D2}s\n得分: {finalScore}", "胜利！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnStartReset.Text = "开始游戏";
                    SetDisksEnabled(false); // 游戏结束后禁用盘子
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameStopwatch.IsRunning)
            {
                lblTime.Text = $"用时: {gameStopwatch.Elapsed.Minutes:D2}m:{gameStopwatch.Elapsed.Seconds:D2}s";
            }
        }

        private void StartGameTimer()
        {
            gameStopwatch.Reset();
            gameStopwatch.Start();
            gameTimer.Start(); // UI timer
            lblTime.Text = "用时: 00m:00s";
        }

        private void StopGameTimer()
        {
            gameStopwatch.Stop();
            gameTimer.Stop(); // UI timer
        }

        private void SetDisksEnabled(bool enabled)
        {
            foreach (var pegStack in pegs)
            {
                if (pegStack != null)
                {
                    foreach (Panel disk in pegStack) 
                    {
                        // 如果需要在不改变栈的情况下操作，需要先ToArray()
                        // foreach (Panel disk in pegStack.ToArray())
                        disk.Enabled = enabled;
                    }
                }
            }
            // 如果 selectedDisk 还在，也处理它
            if (selectedDisk != null)
            {
                selectedDisk.Enabled = enabled;
            }
        }

        private int CalculateScore()
        {
            long optimalMoves = (long)Math.Pow(2, numberOfDisks) - 1;
            int score = BaseScore;

            // 步数惩罚
            if (movesCount > optimalMoves)
            {
                score -= (int)((movesCount - optimalMoves) * PenaltyPerExtraMove);
            }

            // 时间惩罚
            score -= (int)(gameStopwatch.Elapsed.TotalSeconds * PenaltyPerSecond);

            return Math.Max(0, score); // 分数不低于0
        }

        private void LoadHighScores()
        {
            try
            {
                if (File.Exists(HighScoresFileName))
                {
                    string json = File.ReadAllText(HighScoresFileName);
                    // 使用 Newtonsoft.Json
                    highScores = JsonConvert.DeserializeObject<List<ScoreEntry>>(json) ?? new List<ScoreEntry>();
                   
                }
                else
                {
                    highScores = new List<ScoreEntry>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载排行榜失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                highScores = new List<ScoreEntry>(); // 出错则使用空列表
            }
        }

        private void SaveHighScores()
        {
            try
            {
                // 使用 Newtonsoft.Json
                string json = JsonConvert.SerializeObject(highScores, Formatting.Indented);
                

                File.WriteAllText(HighScoresFileName, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存排行榜失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowHighScores_Click(object sender, EventArgs e)
        {
            // 确保高分已加载
            if (highScores == null || highScores.Count == 0)
            {
                // 可以尝试再次加载，或者提示没有记录
                LoadHighScores();
                if (highScores == null || highScores.Count == 0)
                {
                    MessageBox.Show("目前还没有排行榜记录。", "排行榜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            HighScoresForm hsForm = new HighScoresForm(highScores);
            hsForm.ShowDialog(); // 使用 ShowDialog 使其成为模态对话框
        }

        // 这个方法生成解决汉诺塔问题的步骤列表
        // n: 当前要移动的盘子数量
        // sourcePeg: 源柱子索引 (0, 1, or 2)
        // destinationPeg: 目标柱子索引
        // auxiliaryPeg: 辅助柱子索引
        // movesList: 用于存储生成的移动步骤的列表
        private void GenerateHanoiSolution(int n, int sourcePeg, int destinationPeg, int auxiliaryPeg, List<HanoiStep> movesList)
        {
            if (n == 1)
            {
                // 将最上面的一个盘子从 sourcePeg 移动到 destinationPeg
                movesList.Add(new HanoiStep(sourcePeg, destinationPeg));
                return;
            }

            // 1. 将 n-1 个盘子从 sourcePeg 移动到 auxiliaryPeg，以 destinationPeg 作为辅助
            GenerateHanoiSolution(n - 1, sourcePeg, auxiliaryPeg, destinationPeg, movesList);

            // 2. 将第 n 个盘子（最大的那个）从 sourcePeg 移动到 destinationPeg
            movesList.Add(new HanoiStep(sourcePeg, destinationPeg));

            // 3. 将 n-1 个盘子从 auxiliaryPeg 移动到 destinationPeg，以 sourcePeg 作为辅助
            GenerateHanoiSolution(n - 1, auxiliaryPeg, destinationPeg, sourcePeg, movesList);
        }

        private async void btnAutoSolve_Click(object sender, EventArgs e)
        {
            if (isAutoSolving) // 如果正在演示，则不响应
            {
                MessageBox.Show("正在自动演示中，请稍候...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pegs[0].Count == 0 && pegs[1].Count == 0 && pegs[2].Count == numberOfDisks) // 已经完成
            {
                MessageBox.Show("游戏已经完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            isAutoSolving = true;
            SetGameControlsEnabled(false); // 禁用其他控件

            // 确保游戏已初始化或重置到开始状态
            // 如果希望从当前状态开始演示，则不要调用 InitializeGame()
            // 但通常演示是从头开始的
            InitializeGame(); // 这会重置盘子、步数和计时器
            await Task.Delay(AutoSolveDelay / 2); // 短暂延迟，让用户看到初始状态

            if (numberOfDisks <= 0)
            {
                isAutoSolving = false;
                SetGameControlsEnabled(true);
                return;
            }

            List<HanoiStep> solutionSteps = new List<HanoiStep>();
            // 目标柱子通常是第2个 (索引2), 辅助柱子是第1个 (索引1)
            GenerateHanoiSolution(numberOfDisks, 0, 2, 1, solutionSteps);

            // 停止由InitializeGame启动的计时器，因为演示不计入玩家用时
            StopGameTimer();
            lblTime.Text = "开挂中..."; // 更新计时器标签

            foreach (HanoiStep step in solutionSteps)
            {
                if (!isAutoSolving) break; // 如果中途停止了演示 (更高级的功能)

                // 1. 逻辑上移动盘子
                if (pegs[step.FromPeg].Count == 0)
                {
                    // 理论上不应发生，如果算法正确且初始状态正确
                    MessageBox.Show("自动演示错误：源柱子为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                Panel diskToMove = pegs[step.FromPeg].Pop();
                pegs[step.ToPeg].Push(diskToMove);

                // 2. 更新UI显示盘子位置
                // 视觉上“提起”盘子 (可选)
                diskToMove.Top -= 25;
                diskToMove.BringToFront();
                await Task.Delay(AutoSolveDelay / 3); // 短暂的提起动画

                PositionDisksOnPeg(step.FromPeg); // 更新移出盘子的柱子
                PositionDisksOnPeg(step.ToPeg);   // 更新移入盘子的柱子 (这会将盘子放到正确堆叠位置)

                // 3. 更新步数
                movesCount++;
                UpdateMovesLabel();

                // 4. 等待一段时间，形成动画效果
                await Task.Delay(AutoSolveDelay);
            }

            if (isAutoSolving) // 正常完成
            {
                CheckWinCondition(); // 检查是否胜利 (理论上此时应该胜利了)
                                     // CheckWinCondition 内部可能会有StopGameTimer，但我们已提前停止
                MessageBox.Show("自动演示完成！", "演示结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            isAutoSolving = false;
            SetGameControlsEnabled(true); // 重新启用控件
            btnStartReset.Text = "开始游戏"; // 重置按钮文本，因为演示后游戏算结束了
            lblTime.Text = "用时: 00m:00s"; // 重置时间显示
        }

        private void SetGameControlsEnabled(bool enabled)
        {
            btnStartReset.Enabled = enabled;
            numDisksInput.Enabled = enabled;
            btnShowHighScores.Enabled = enabled;
            btnAutoSolve.Enabled = enabled; // 自动演示按钮自身也应受控

            
            foreach (Panel pvp in pegVisualPanels)
            {
                if (pvp != null) pvp.Enabled = enabled;
            }

           
        }

    }
}
