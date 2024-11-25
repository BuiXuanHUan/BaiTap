using System;
using System.Windows.Forms;

namespace bai2
{
    public partial class txtlastname : Form
    {
        public txtlastname()
        {
            InitializeComponent();
        }

        // Khi chọn một mục trong ListView
        private void studentsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (studentsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = studentsListView.SelectedItems[0];
                txtLastName.Text = selectedItem.Text; // Cột 1
                txtFirstName.Text = selectedItem.SubItems[1].Text; // Cột 2
                txtPhoneNumber.Text = selectedItem.SubItems[2].Text; // Cột 3
            }
        }

        // Thêm mục mới vào ListView
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem(txtLastName.Text);
            item.SubItems.Add(txtFirstName.Text);
            item.SubItems.Add(txtPhoneNumber.Text);
            studentsListView.Items.Add(item);

            // Xóa nội dung TextBox
            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhoneNumber.Clear();
        }

        // Sửa mục được chọn
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (studentsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = studentsListView.SelectedItems[0];

                if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedItem.Text = txtLastName.Text; // Cột 1
                selectedItem.SubItems[1].Text = txtFirstName.Text; // Cột 2
                selectedItem.SubItems[2].Text = txtPhoneNumber.Text; // Cột 3

                txtLastName.Clear();
                txtFirstName.Clear();
                txtPhoneNumber.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xóa mục được chọn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (studentsListView.SelectedItems.Count > 0)
            {
                studentsListView.Items.Remove(studentsListView.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
