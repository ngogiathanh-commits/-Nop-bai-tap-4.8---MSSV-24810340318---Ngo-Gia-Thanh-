using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt_12_10_4._8
{
    public partial class FormAsyncLoad : Form
    {
        public FormAsyncLoad()
        {
            InitializeComponent();
        }

        private void FormAsyncLoad_Load(object sender, EventArgs e)
        {
            progressBarLoading.Value = 0;
            lblPercent.Text = "0%";
        }

        // Phương thức hỗ trợ gửi thông điệp lên StatusStrip của Form cha MDI (nếu có)
        private void SendStatusToParent(string message)
        {
            // Giả sử Form cha có hàm Public UpdateStatus(string msg)
            if (this.MdiParent != null)
            {
                var method = this.MdiParent.GetType().GetMethod("UpdateStatus");
                method?.Invoke(this.MdiParent, new object[] { message });
            }
        }

        // 1. Hàm nạp dữ liệu bất đồng bộ giả lập lấy dữ liệu lớn (DB / File)
        private async Task<List<Student>> LoadDataAsync(IProgress<int> progress)
        {
            // Chạy tác vụ giả lập trên tiến trình ngầm bằng Task.Run
            return await Task.Run(async () =>
            {
                List<Student> resultList = new List<Student>();

                // Giả lập nạp 100 bản ghi dữ liệu
                for (int i = 1; i <= 100; i++)
                {
                    // Giả lập độ trễ xử lý (30ms mỗi bản ghi => Tổng ~3 giây)
                    await Task.Delay(30);

                    resultList.Add(new Student(
                        $"SV{i:D3}",
                        $"Sinh Viên {i}",
                        18 + (i % 5),
                        i % 2 == 0 ? "Nam" : "Nữ"
                    ));

                    // Báo cáo phần trăm hoàn thành về UI Thread
                    progress?.Report(i);
                }

                return resultList;
            });
        }

        // 2. Sự kiện khi nhấn nút "Nạp Dữ Liệu Bất Đồng Bộ"
        private async void btnLoadData_Click(object sender, EventArgs e)
        {
            // a. Khóa nút bấm để tránh người dùng kích hoạt lặp lại
            btnLoadData.Enabled = false;
            progressBarLoading.Value = 0;
            lblPercent.Text = "0%";
            dgvStudents.DataSource = null;

            // b. Khởi tạo đối tượng Progress để nhận cập nhật tiến trình từ Background Thread
            Progress<int> progress = new Progress<int>(percent =>
            {
                // Đoạn code này tự động thực thi trên UI Thread
                progressBarLoading.Value = percent;
                lblPercent.Text = $"{percent}%";

                // Cập nhật trạng thái lên StatusStrip của Form cha MDI
                SendStatusToParent($"Đang nạp dữ liệu hệ thống... {percent}%");
            });

            try
            {
                SendStatusToParent("Bắt đầu nạp dữ liệu...");

                // c. Gọi hàm async và chờ (await) hoàn tất
                List<Student> data = await LoadDataAsync(progress);

                // d. Hiển thị dữ liệu lên DataGridView sau khi hoàn tất
                dgvStudents.DataSource = data;
                DinhDangGrid();

                SendStatusToParent("Tải dữ liệu hoàn tất!");
                MessageBox.Show("Đã nạp xong 100 bản ghi sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SendStatusToParent("Xảy ra lỗi trong quá trình nạp dữ liệu!");
                MessageBox.Show($"Lỗi khi nạp dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // e. Luôn luôn mở lại nút bấm dù thành công hay xảy ra lỗi
                btnLoadData.Enabled = true;
            }
        }

        private void DinhDangGrid()
        {
            if (dgvStudents.Columns["StudentId"] != null) dgvStudents.Columns["StudentId"].HeaderText = "Mã SV";
            if (dgvStudents.Columns["FullName"] != null) dgvStudents.Columns["FullName"].HeaderText = "Họ và Tên";
            if (dgvStudents.Columns["Age"] != null) dgvStudents.Columns["Age"].HeaderText = "Tuổi";
            if (dgvStudents.Columns["Gender"] != null) dgvStudents.Columns["Gender"].HeaderText = "Giới Tính";
        }
    }
}
