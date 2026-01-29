using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.BLL;
using WinFormsApp1.Model;

namespace WinFormsApp1.UI
{
    public partial class FormMovies : Form
    {
        private MovieBLL movieBLL;
        private Movie? currentMovie;
        
        public FormMovies()
        {
            InitializeComponent();
            movieBLL = new MovieBLL();
        }
        
        private void FormMovies_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyModernDarkTheme(this);
			LoadMovies();
            ClearForm();

        }
        
        private void LoadMovies()
        {
            dgvMovies.DataSource = movieBLL.GetAllMovies();
            FormatDataGridView();
        }
        
        private void FormatDataGridView()
        {
            dgvMovies.Columns["Id"].HeaderText = "ID";
            dgvMovies.Columns["Title"].HeaderText = "Tên phim";
            dgvMovies.Columns["Director"].HeaderText = "Đạo diễn";
            dgvMovies.Columns["Genre"].HeaderText = "Thể loại";
            dgvMovies.Columns["Duration"].HeaderText = "Thời lượng (phút)";
            dgvMovies.Columns["Description"].HeaderText = "Mô tả";
            dgvMovies.Columns["ReleaseDate"].HeaderText = "Ngày khởi chiếu";
            dgvMovies.Columns["IsActive"].HeaderText = "Đang chiếu";
            
            // Hide PosterUrl column as it's just a URL/path
            if (dgvMovies.Columns.Contains("PosterUrl"))
            {
                dgvMovies.Columns["PosterUrl"].Visible = false;
            }
            
            dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovies.Columns["ReleaseDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        
        private void ClearForm()
        {
            txtMovieId.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtDirector.Text = string.Empty;
            txtGenre.Text = string.Empty;
            txtDuration.Text = string.Empty;
            txtDescription.Text = string.Empty;
            dtpReleaseDate.Value = DateTime.Today;
            txtPosterUrl.Text = string.Empty;
            chkIsActive.Checked = true;
            
            currentMovie = null;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            
            picPoster.Image = null;
            // Set a placeholder image if possible
            try
            {
                picPoster.Image = Image.FromFile("placeholder_movie.jpg");
            }
            catch
            {
                // No placeholder image is available, not crucial
            }
        }
        
        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int movieId = Convert.ToInt32(dgvMovies.Rows[e.RowIndex].Cells["Id"].Value);
                currentMovie = movieBLL.GetMovieById(movieId);
                
                if (currentMovie != null)
                {
                    txtMovieId.Text = currentMovie.Id.ToString();
                    txtTitle.Text = currentMovie.Title;
                    txtDirector.Text = currentMovie.Director;
                    txtGenre.Text = currentMovie.Genre;
                    txtDuration.Text = currentMovie.Duration.ToString();
                    txtDescription.Text = currentMovie.Description;
                    dtpReleaseDate.Value = currentMovie.ReleaseDate;
                    txtPosterUrl.Text = currentMovie.Poster;
                    chkIsActive.Checked = currentMovie.IsActive;
                    
                    LoadPosterImage(currentMovie.Poster);
                    
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
        }
        
        private void LoadPosterImage(string posterUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(posterUrl) && File.Exists(posterUrl))
                {
                    using (var stream = new FileStream(posterUrl, FileMode.Open, FileAccess.Read))
                    {
                        picPoster.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    picPoster.Image = null;
                    // Set a placeholder image if possible
                    try
                    {
                        picPoster.Image = Image.FromFile("placeholder_movie.jpg");
                    }
                    catch
                    {
                        // No placeholder image is available, not crucial
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception if the image can't be loaded
                Console.WriteLine($"Error loading image: {ex.Message}");
                picPoster.Image = null;
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs())
                {
                    Movie movie = new Movie
                    {
                        Title = txtTitle.Text.Trim(),
                        Director = txtDirector.Text.Trim(),
                        Genre = txtGenre.Text.Trim(),
                        Duration = Convert.ToInt32(txtDuration.Text),
                        Description = txtDescription.Text.Trim(),
                        ReleaseDate = dtpReleaseDate.Value,
                        Poster = txtPosterUrl.Text.Trim(),
                        IsActive = chkIsActive.Checked
                    };
                    
                    bool result = movieBLL.AddMovie(movie);
                    
                    if (result)
                    {
                        MessageBox.Show("Thêm phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMovies();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Thêm phim thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentMovie == null)
            {
                MessageBox.Show("Vui lòng chọn phim để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                if (ValidateInputs())
                {
                    currentMovie.Title = txtTitle.Text.Trim();
                    currentMovie.Director = txtDirector.Text.Trim();
                    currentMovie.Genre = txtGenre.Text.Trim();
                    currentMovie.Duration = Convert.ToInt32(txtDuration.Text);
                    currentMovie.Description = txtDescription.Text.Trim();
                    currentMovie.ReleaseDate = dtpReleaseDate.Value;
                    currentMovie.Poster = txtPosterUrl.Text.Trim();
                    currentMovie.IsActive = chkIsActive.Checked;
                    
                    bool result = movieBLL.UpdateMovie(currentMovie);
                    
                    if (result)
                    {
                        MessageBox.Show("Cập nhật phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMovies();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật phim thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentMovie == null)
            {
                MessageBox.Show("Vui lòng chọn phim để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa phim này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dr == DialogResult.Yes)
            {
                try
                {
                    bool result = movieBLL.DeleteMovie(currentMovie.Id);
                    
                    if (result)
                    {
                        MessageBox.Show("Xóa phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMovies();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phim thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";
                openFileDialog.Title = "Chọn ảnh poster";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPosterUrl.Text = openFileDialog.FileName;
                    LoadPosterImage(openFileDialog.FileName);
                }
            }
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phim.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtDirector.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đạo diễn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDirector.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Vui lòng nhập thể loại phim.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenre.Focus();
                return false;
            }
            
            if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("Thời lượng phim phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDuration.Focus();
                return false;
            }
            
            return true;
        }
    }
}