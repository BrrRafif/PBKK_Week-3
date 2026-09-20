using System.Drawing;

namespace CalculatorApp
{
  partial class Form1
  {
    private System.ComponentModel.IContainer component = null;

    private Label lblTitle = null;
    private Label lblSubtitle = null;
    private TextBox txtDisplay = null;

    private Button btn0 = null!;
    private Button btn1 = null!;
    private Button btn2 = null!;
    private Button btn3 = null!;
    private Button btn4 = null!;
    private Button btn5 = null!;
    private Button btn6 = null!;
    private Button btn7 = null!;
    private Button btn8 = null!;
    private Button btn9 = null!;
    private Button Divide = null;
    private Button Multiply = null!;
    private Button Minus = null!;
    private Button Plus = null!;
    private Button Decimal = null!;
    private Button Clear = null!;
    private Button btnEquals = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (component != null))
      {
        component.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      component = new System.ComponentModel.Container();

      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(440, 640);
      this.Text = "Kalkulator";
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.BackColor = Color.White;
      
      KeyPreview = true;
      KeyDown += Form1_KeyDown;

      lblTitle = new Label
      {
        Name = "lblTitle",
        Text = "Kalkulator",
        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
        ForeColor = Color.Black,
        TextAlign = ContentAlignment.MiddleCenter,
        AutoSize = false,
        Location = new Point(20, 12),
        Size = new Size(400, 40)
      };

      lblSubtitle = new Label
      {
        Name = "lblSubtitle",
        Text = "Hitung lebih mudah, setiap hari!",
        Font = new Font("Segoe UI", 9F),
        ForeColor = Color.Gray,
        TextAlign = ContentAlignment.MiddleCenter,
        AutoSize = false,
        Location = new Point(20, 52),
        Size = new Size(400, 20)
      };

      txtDisplay = new TextBox
      {
        Name = "txtDisplay",
        Text = "0",
        Font = new Font("Segoe UI", 24F, FontStyle.Bold),
        TextAlign = HorizontalAlignment.Right,
        ReadOnly = true,
        BackColor = Color.FromArgb(230, 240, 250),
        BorderStyle = BorderStyle.FixedSingle,
        Location = new Point(20, 85),
        Size = new Size (400, 90)
      };

      const int x0 = 20, y0 = 190, w = 95, h = 80, gap = 8;
      int X(int col) => x0 + col * (w + gap);
      int Y(int row) => y0 + row * (h + gap);

      btn7 = MakeButton("btn7", "7", X(0), Y(0), w, h);
      btn8 = MakeButton("btn8", "8", X(1), Y(0), w, h);
      btn9 = MakeButton("btn9", "9", X(2), Y(0), w, h);
      Divide = MakeButton("btnDivide", "÷", X(3), Y(0), w, h);

      btn4 = MakeButton("btn4", "4", X(0), Y(1), w, h);
      btn5 = MakeButton("btn5", "5", X(1), Y(1), w, h);
      btn6 = MakeButton("btn6", "6", X(2), Y(1), w, h);
      Multiply = MakeButton("btnMultiply", "x", X(3), Y(1), w, h);

      btn1 = MakeButton("btn1", "1", X(0), Y(2), w, h);
      btn2 = MakeButton("btn2", "2", X(1), Y(2), w, h);
      btn3 = MakeButton("btn3", "3", X(2), Y(2), w, h);
      Minus  = MakeButton("btnMinus", "-", X(3), Y(2), w, h);

      btn0 = MakeButton("btn0", "0", X(0), Y(3), w, h);
      Decimal = MakeButton("btnDecimal", ".", X(1), Y(3), w, h);
      Clear = MakeButton("btnClear", "C", X(2), Y(3), w, h);
      Plus = MakeButton("btnPlus", "+", X(3), Y(3), w, h);

      btnEquals = MakeButton("btnEquals", "=", X(0), Y(4), 4 * w + 3 * gap, h);

      foreach (var b in new[] { Divide, Multiply, Minus, Plus })
        Style(b, Color.FromArgb(255, 152, 0), Color.White);

      Style(Clear, Color.FromArgb(239, 83, 80), Color.White);
      Style(btnEquals, Color.FromArgb(46, 170, 90), Color.White);

      foreach (var b in new[] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 })
        b.Click += NumberButton_Click;

      foreach (var b in new[] { Divide, Multiply, Minus, Plus })
        b.Click += OperatorButton_Click;

      btnEquals.Click += btnEquals_Click;
      Clear.Click += btnClear_Click;
      Decimal.Click += btnDecimal_Click;

      this.Controls.AddRange(new Control[]
      {
        lblTitle, lblSubtitle, txtDisplay,
        btn7, btn8, btn9, Divide,
        btn4, btn5, btn6, Multiply,
        btn1, btn2, btn3, Minus,
        btn0, Decimal, Clear, Plus,
        btnEquals
      });
    }

    private Button MakeButton(string name, string text, int x, int y, int width, int height)
    {
      return new Button
      {
        Name = name,
        Text = text,
        TabStop = false,
        Font = new Font("Segoe UI", 16F, FontStyle.Bold),
        Location = new Point(x, y),
        Size = new Size(width, height),
        FlatStyle = FlatStyle.Flat,
        BackColor = Color.FromArgb(245, 245, 245),
        ForeColor = Color.Black,
        UseVisualStyleBackColor = false
      };
    }

    private static void Style(Button b, Color back, Color fore)
    {
      b.BackColor = back;
      b.ForeColor = fore;
      b.FlatAppearance.BorderSize = 0;
    }
  }
}