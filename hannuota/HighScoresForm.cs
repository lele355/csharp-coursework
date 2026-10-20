using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hannuota
{
    public partial class HighScoresForm: Form
    {
        public HighScoresForm()
        {
            InitializeComponent();
        }
        private List<ScoreEntry> _scores;

        public HighScoresForm(List<ScoreEntry> scores)
        {
            InitializeComponent();
            _scores = scores.OrderByDescending(s => s.Score)
                            .ThenBy(s => s.Moves) // 分数相同按步数少
                            .ThenBy(s => s.TimeTaken) // 步数相同按时间少
                            .ToList();
        }

        private void HighScoresForm_Load(object sender, EventArgs e)
        {
            // 为DataGridView配置列 (如果希望自定义列名和顺序)
            dgvHighScores.AutoGenerateColumns = false; // 关闭自动生成列

            dgvHighScores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "排名",
                Name = "Rank",
                DataPropertyName = "Rank", // 这个需要手动填充
                ReadOnly = true,
                Width = 60
            });
            dgvHighScores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "玩家",
                Name = "PlayerName",
                DataPropertyName = "PlayerName", // 对应 ScoreEntry 的属性名
                ReadOnly = true
            });
            dgvHighScores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "分数",
                Name = "Score",
                DataPropertyName = "Score",
                ReadOnly = true
            });
            dgvHighScores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "盘子数",
                Name = "DiskCount",
                DataPropertyName = "DiskCount",
                ReadOnly = true,
                Width = 70
            });
            dgvHighScores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "步数",
                Name = "Moves",
                DataPropertyName = "Moves",
                ReadOnly = true,
                Width = 70
            });
            dgvHighScores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "用时",
                Name = "TimeTakenFormatted", // 使用格式化后的时间
                DataPropertyName = "TimeTakenFormatted",
                ReadOnly = true
            });
            dgvHighScores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "日期",
                Name = "DatePlayed",
                DataPropertyName = "DatePlayed",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" }
            });


            // 绑定数据源
            var bindingList = new BindingList<ScoreEntry>(_scores);
            dgvHighScores.DataSource = bindingList;

            // 手动添加排名
            for (int i = 0; i < dgvHighScores.Rows.Count; i++)
            {
                dgvHighScores.Rows[i].Cells["Rank"].Value = (i + 1).ToString();
            }
        }
        
    }
}
