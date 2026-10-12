namespace bt_12_10_4._8
{
    partial class FormAsyncLoad
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnLoadData = new Button();
            progressBarLoading = new ProgressBar();
            lblPercent = new Label();
            dgvStudents = new DataGridView();
            grpProgress = new GroupBox();
            grpProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // btnLoadData
            // 
            btnLoadData.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoadData.Location = new Point(12, 12);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(220, 45);
            btnLoadData.TabIndex = 0;
            btnLoadData.Text = "Nạp Dữ Liệu Bất Đồng Bộ";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // progressBarLoading
            // 
            progressBarLoading.Location = new Point(15, 25);
            progressBarLoading.Name = "progressBarLoading";
            progressBarLoading.Size = new Size(430, 25);
            progressBarLoading.TabIndex = 1;
            // 
            // lblPercent
            // 
            lblPercent.AutoSize = true;
            lblPercent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPercent.Location = new Point(455, 25);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(35, 23);
            lblPercent.TabIndex = 2;
            lblPercent.Text = "0%";
            // 
            // dgvStudents
            // 
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(12, 140);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(758, 300);
            dgvStudents.TabIndex = 3;
            // 
            // grpProgress
            // 
            grpProgress.Controls.Add(progressBarLoading);
            grpProgress.Controls.Add(lblPercent);
            grpProgress.Location = new Point(250, 2);
            grpProgress.Name = "grpProgress";
            grpProgress.Size = new Size(520, 125);
            grpProgress.TabIndex = 4;
            grpProgress.TabStop = false;
            grpProgress.Text = "Tiến trình nạp dữ liệu ngầm";
            // 
            // FormAsyncLoad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(grpProgress);
            Controls.Add(dgvStudents);
            Controls.Add(btnLoadData);
            Name = "FormAsyncLoad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lập Trình Bất Đồng Bộ (Async/Await & ProgressBar)";
            Load += FormAsyncLoad_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            grpProgress.ResumeLayout(false);
            grpProgress.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadData;
        private ProgressBar progressBarLoading;
        private Label lblPercent;
        private DataGridView dgvStudents;
        private GroupBox grpProgress;
    }
}