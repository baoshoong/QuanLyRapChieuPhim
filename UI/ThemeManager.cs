#pragma warning disable CA1416 // Validate platform compatibility



using System.Drawing;

using System.Windows.Forms;



/// <summary>

/// Quản lý giao diện (theme) cho toàn bộ ứng dụng.

/// Chứa các định nghĩa về màu sắc, font chữ và các phương thức để áp dụng theme.

/// </summary>

public static class ThemeManager

{

	//================================================================//

	//                        THEME LOTTE (SÁNG)                      //

	//================================================================//



	#region Lotte Theme Colors & Fonts



	// Màu thương hiệu Lotte

	public static readonly Color LotteRed = Color.FromArgb(236, 28, 36);

	public static readonly Color LotteWhite = Color.White;

	public static readonly Color LotteDarkGray = Color.FromArgb(64, 64, 64);

	public static readonly Color LotteLightGray = Color.FromArgb(240, 240, 240);

	public static readonly Color BackgroundColor = Color.FromArgb(245, 245, 245);

	public static readonly Color CardBackground = Color.White;

	public static readonly Color AccentColor = Color.FromArgb(255, 224, 192);

	public static readonly Color ActiveColor = Color.Green;

	public static readonly Color DangerColor = Color.Firebrick;



	#endregion



	//================================================================//

	//                     MODERN DARK THEME (TỐI)                    //

	//================================================================//



	#region Modern Dark Theme Colors & Fonts



	public static class ModernDark

	{

		// Màu chính

		public static readonly Color Primary = Color.FromArgb(29, 38, 54);      // Xanh đậm

		public static readonly Color Secondary = Color.FromArgb(85, 111, 247);    // Xanh sáng

		public static readonly Color Accent = Color.FromArgb(255, 107, 107);      // San hô mềm



		// Màu nền

		public static readonly Color Background = Color.FromArgb(22, 27, 34);    // Xanh-xám rất đậm

		public static readonly Color CardBg = Color.FromArgb(35, 41, 50);        // Xanh-xám đậm

		public static readonly Color InputBg = Color.FromArgb(43, 49, 59);       // Xanh-xám nhạt hơn



		// Màu chữ

		public static readonly Color TextPrimary = Color.FromArgb(230, 237, 243); // Trắng ngà

		public static readonly Color TextSecondary = Color.FromArgb(145, 155, 175);// Xám nhạt

		public static readonly Color TextMuted = Color.FromArgb(105, 115, 135);   // Xám mờ



		// Màu trạng thái

		public static readonly Color Success = Color.FromArgb(63, 182, 139);     // Xanh lá

		public static readonly Color Warning = Color.FromArgb(255, 184, 57);     // Vàng

		public static readonly Color Danger = Color.FromArgb(248, 81, 73);       // Đỏ

		public static readonly Color Info = Color.FromArgb(58, 146, 249);        // Xanh dương

	}



	#endregion



	//================================================================//

	//                 QUẢN LÝ FONT (TỐI ƯU HÓA)                      //

	//================================================================//



	#region Fonts



	// Định nghĩa sẵn các font để tránh tạo lại nhiều lần, gây rò rỉ bộ nhớ.

	public static readonly Font TitleFont = new Font("Segoe UI", 16F, FontStyle.Bold);

	public static readonly Font HeaderFont = new Font("Segoe UI", 10F, FontStyle.Bold);

	public static readonly Font BodyFont = new Font("Segoe UI", 9F);

	public static readonly Font ButtonFont = new Font("Segoe UI", 9F, FontStyle.Bold);



	#endregion



	//================================================================//

	//             ÁP DỤNG THEME (PHƯƠNG THỨC CHÍNH)                  //

	//================================================================//



	#region Apply Themes



	/// <summary>

	/// Áp dụng theme Lotte (sáng) cho một Form.

	/// </summary>

	public static void ApplyTheme(Form form)

	{

		form.BackColor = BackgroundColor;

		form.Font = BodyFont;

		form.StartPosition = FormStartPosition.CenterScreen;

		ApplyThemeToControls(form.Controls);

	}



	/// <summary>

	/// Áp dụng Modern Dark Theme (tối) cho một Form.

	/// </summary>

	public static void ApplyModernDarkTheme(Form form)

	{

		form.BackColor = ModernDark.Background;

		form.Font = BodyFont;

		form.ForeColor = ModernDark.TextPrimary;

		form.StartPosition = FormStartPosition.CenterScreen;



		// Áp dụng đệ quy cho tất cả các control con

		foreach (Control control in form.Controls)

		{

			ApplyModernDarkThemeToControl(control);

		}

	}



	#endregion



	//================================================================//

	//              PHƯƠNG THỨC HỖ TRỢ (PRIVATE)                      //

	//================================================================//



	#region Private Helper Methods for Lotte Theme



	private static void ApplyThemeToControls(Control.ControlCollection controls)

	{

		foreach (Control control in controls)

		{

			ApplyThemeToControl(control);

			if (control.HasChildren)

				ApplyThemeToControls(control.Controls);

		}

	}



	private static void ApplyThemeToControl(Control control)

	{

		if (control is GroupBox gb)

		{

			gb.ForeColor = LotteRed;

			gb.Font = HeaderFont;

			gb.BackColor = CardBackground;

		}

		else if (control is Panel panel)

		{

			panel.BackColor = CardBackground;

		}

		else if (control is Label lbl)

		{

			lbl.ForeColor = LotteDarkGray;

			lbl.Font = BodyFont;

		}

		else if (control is TextBox txt)

		{

			txt.BackColor = LotteWhite;

			txt.ForeColor = LotteDarkGray;

			txt.BorderStyle = BorderStyle.FixedSingle;

			txt.Font = BodyFont;

		}

		else if (control is ComboBox cb)

		{

			cb.BackColor = LotteWhite;

			cb.ForeColor = LotteDarkGray;

			cb.FlatStyle = FlatStyle.Flat;

			cb.Font = BodyFont;

		}

		else if (control is DataGridView dgv)

		{

			StyleDataGridView(dgv);

		}

	}



	#endregion



	#region Private Helper Methods for Modern Dark Theme



	private static void ApplyModernDarkThemeToControl(Control control)

	{

		// Áp dụng đệ quy cho các control con trước

		if (control.HasChildren)

		{

			foreach (Control childControl in control.Controls)

			{

				ApplyModernDarkThemeToControl(childControl);

			}

		}



		// Định dạng cho từng loại control

		if (control is GroupBox gb)

		{

			gb.ForeColor = ModernDark.Secondary;

			gb.Font = HeaderFont;

			gb.BackColor = ModernDark.CardBg;

		}

		else if (control is Button btn)

		{

			StyleButtonModernDark(btn);

		}

		else if (control is DataGridView dgv)

		{

			StyleDataGridViewModernDark(dgv);

		}

		else if (control is Label label)

		{

			// Phân loại label dựa trên kích thước và kiểu font

			if (label.Font.Size > 12 && label.Font.Bold)

			{

				label.ForeColor = ModernDark.Secondary; // Tiêu đề chính

				label.Font = TitleFont;

			}

			else if (label.Font.Bold)

			{

				label.ForeColor = ModernDark.TextPrimary; // Tiêu đề phụ

				label.Font = HeaderFont;

			}

			else

			{

				label.ForeColor = ModernDark.TextSecondary; // Chữ thông thường

				label.Font = BodyFont;

			}

		}

		else if (control is TextBox txt)

		{

			txt.BackColor = ModernDark.InputBg;

			txt.ForeColor = ModernDark.TextPrimary;

			txt.Font = BodyFont;

			txt.BorderStyle = BorderStyle.FixedSingle;

			// Thêm một viền mảnh để làm nổi bật ô nhập liệu

			txt.Parent.Paint += (sender, e) =>

			{

				ControlPaint.DrawBorder(e.Graphics, txt.Bounds, ModernDark.TextMuted, ButtonBorderStyle.Solid);

			};

		}

		else if (control is ComboBox cmb)

		{

			cmb.BackColor = ModernDark.InputBg;

			cmb.ForeColor = ModernDark.TextPrimary;

			cmb.Font = BodyFont;

			cmb.FlatStyle = FlatStyle.Flat;

		}

		else if (control is CheckBox cb)

		{

			cb.ForeColor = ModernDark.TextPrimary;

			cb.Font = BodyFont;

		}

		else if (control is RadioButton rb)

		{

			rb.ForeColor = ModernDark.TextPrimary;

			rb.Font = BodyFont;

		}

		else if (control is Panel panel)

		{

			panel.BackColor = ModernDark.CardBg;

		}

		else if (control is DateTimePicker dtp)

		{

			dtp.CalendarForeColor = ModernDark.TextPrimary;

			dtp.CalendarMonthBackground = ModernDark.InputBg;

			dtp.CalendarTitleBackColor = ModernDark.Secondary;

			dtp.CalendarTitleForeColor = ModernDark.TextPrimary;

			dtp.Font = BodyFont;

		}

		else if (control is NumericUpDown nud)

		{

			nud.BackColor = ModernDark.InputBg;

			nud.ForeColor = ModernDark.TextPrimary;

			nud.Font = BodyFont;

		}

	}



	#endregion



	//================================================================//

	//                 ĐỊNH DẠNG CONTROL CỤ THỂ                      //

	//================================================================//



	#region Control Styling Methods



	// --- Các nút cho Theme Lotte ---

	public static void StyleButton(Button button, Color backColor, Color foreColor)

	{

		button.BackColor = backColor;

		button.ForeColor = foreColor;

		button.FlatStyle = FlatStyle.Flat;

		button.FlatAppearance.BorderSize = 0;

		button.Font = ButtonFont;

		button.Cursor = Cursors.Hand;

		button.Height = 40;

	}



	public static void StylePrimaryButton(Button button) => StyleButton(button, LotteRed, LotteWhite);

	public static void StyleAccentButton(Button button) => StyleButton(button, AccentColor, LotteDarkGray);

	public static void StyleSuccessButton(Button button) => StyleButton(button, ActiveColor, LotteWhite);

	public static void StyleDangerButton(Button button) => StyleButton(button, DangerColor, LotteWhite);



	// --- Các nút cho Modern Dark Theme ---

	public static void StyleButtonModernDark(Button button)

	{

		button.FlatStyle = FlatStyle.Flat;

		button.Font = ButtonFont;

		button.Cursor = Cursors.Hand;

		button.Height = 40;

		button.Padding = new Padding(10, 0, 10, 0);



		// Tự động định dạng nút dựa trên tên của nó

		string btnName = button.Name.ToLower();

		if (btnName.Contains("add") || btnName.Contains("create") || btnName.Contains("save") || btnName.Contains("confirm"))

		{

			button.BackColor = ModernDark.Secondary;

			button.ForeColor = ModernDark.TextPrimary;

			button.FlatAppearance.BorderSize = 0;

		}

		else if (btnName.Contains("delete") || btnName.Contains("remove"))

		{

			button.BackColor = ModernDark.Danger;

			button.ForeColor = ModernDark.TextPrimary;

			button.FlatAppearance.BorderSize = 0;

		}

		else if (btnName.Contains("edit") || btnName.Contains("update"))

		{

			button.BackColor = ModernDark.Info;

			button.ForeColor = ModernDark.TextPrimary;

			button.FlatAppearance.BorderSize = 0;

		}

		else if (btnName.Contains("back") || btnName.Contains("cancel") || btnName.Contains("clear"))

		{

			button.BackColor = ModernDark.CardBg;

			button.ForeColor = ModernDark.TextSecondary;

			button.FlatAppearance.BorderColor = ModernDark.TextMuted;

			button.FlatAppearance.BorderSize = 1;

		}

		else

		{

			// Nút mặc định

			button.BackColor = ModernDark.InputBg;

			button.ForeColor = ModernDark.TextPrimary;

			button.FlatAppearance.BorderColor = ModernDark.TextMuted;

			button.FlatAppearance.BorderSize = 1;

		}

	}



	// --- DataGridView cho Theme Lotte ---

	public static void StyleDataGridView(DataGridView dgv)

	{

		if (dgv == null) return;

		dgv.BorderStyle = BorderStyle.None;

		dgv.BackgroundColor = CardBackground;

		dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

		dgv.GridColor = LotteLightGray;

		dgv.RowHeadersVisible = false;

		dgv.ColumnHeadersDefaultCellStyle.BackColor = LotteRed;

		dgv.ColumnHeadersDefaultCellStyle.ForeColor = LotteWhite;

		dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;

		dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);

		dgv.EnableHeadersVisualStyles = false;

		dgv.DefaultCellStyle.Font = BodyFont;

		dgv.DefaultCellStyle.SelectionBackColor = LotteRed;

		dgv.DefaultCellStyle.SelectionForeColor = LotteWhite;

		dgv.DefaultCellStyle.Padding = new Padding(3);

		dgv.AlternatingRowsDefaultCellStyle.BackColor = LotteLightGray;

	}



	// --- DataGridView cho Modern Dark Theme ---

	public static void StyleDataGridViewModernDark(DataGridView dgv)

	{

		if (dgv == null) return;

		dgv.BorderStyle = BorderStyle.None;

		dgv.BackgroundColor = ModernDark.CardBg;

		dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

		dgv.GridColor = ModernDark.Background;

		dgv.RowHeadersVisible = false;

		dgv.AllowUserToResizeRows = false;



		// Header

		dgv.ColumnHeadersDefaultCellStyle.BackColor = ModernDark.Primary;

		dgv.ColumnHeadersDefaultCellStyle.ForeColor = ModernDark.TextPrimary;

		dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;

		dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);

		dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

		dgv.ColumnHeadersHeight = 40;

		dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

		dgv.EnableHeadersVisualStyles = false;



		// Rows

		dgv.DefaultCellStyle.Font = BodyFont;

		dgv.DefaultCellStyle.ForeColor = ModernDark.TextSecondary;

		dgv.DefaultCellStyle.BackColor = ModernDark.CardBg;

		dgv.DefaultCellStyle.SelectionBackColor = ModernDark.Secondary;

		dgv.DefaultCellStyle.SelectionForeColor = ModernDark.TextPrimary;

		dgv.DefaultCellStyle.Padding = new Padding(5);

		dgv.AlternatingRowsDefaultCellStyle.BackColor = ModernDark.InputBg;

		dgv.RowTemplate.Height = 35;



		// Tự động căn giữa cho cột CheckBox

		foreach (DataGridViewColumn column in dgv.Columns)

		{

			if (column is DataGridViewCheckBoxColumn)

			{

				column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			}

		}

		dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

	}



	#endregion

}

