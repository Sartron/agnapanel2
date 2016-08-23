using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AgnaPanel
{
    public partial class BorderedTextBox : UserControl
    {
        private TextBox textBox;

        public BorderedTextBox()
        {
            textBox = new TextBox()
            {
                BorderStyle = BorderStyle.None,
                Multiline = true
            };

            currentColor = DefaultBorderColor;

            this.Paint += new PaintEventHandler(borderPaint);
            this.Resize += new EventHandler(textBoxResize);
            this.Controls.Add(textBox);

            InvalidateSize();
        }

        //Properties
        [Description("The color of the component's border when unfocused.")]
        public Color DefaultBorderColor { get; set; } = Color.FromArgb(255, 122, 122, 122);
        [Description("The color of the component's border when focused.")]
        public Color FocusedBorderColor { get; set; } = Color.FromArgb(255, 0, 120, 215);

        [Description("Indicates if return characters are accepted as input for multiline edit controls.")]
        public bool AcceptsReturn
        {
            get { return textBox.AcceptsReturn; }
            set { textBox.AcceptsReturn = value; }
        }
        [Description("Indicates if tab characters are accepted as input for multiline edit controls.")]
        public bool AcceptsTab
        {
            get { return textBox.AcceptsTab; }
            set { textBox.AcceptsTab = value; }
        }
        [Description("The StringCollection to use when the AutoCompleteSource property is set to CustomSource.")]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return textBox.AutoCompleteCustomSource; }
            set { textBox.AutoCompleteCustomSource = value; }
        }
        [Description("Indicates the text completion behavior of the text box.")]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return textBox.AutoCompleteMode; }
            set { textBox.AutoCompleteMode = value; }
        }
        [Description("The autocomplete source, which can be one of the values from AutoCompleteSource enumeration.")]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return textBox.AutoCompleteSource; }
            set { textBox.AutoCompleteSource = value; }
        }
        [Description("The background color of the component.")]
        public override Color BackColor
        {
            get { return textBox.BackColor; }
            set { textBox.BackColor = value; }
        }
        [ReadOnly(true)]
        [Description("Indicates whether the edit control should have a border.")]
        public new BorderStyle BorderStyle
        {
            get { return textBox.BorderStyle; }
            set { textBox.BorderStyle = value; }
        }
        [Description("The foreground color of this component, which is used to display text.")]
        public new Color ForeColor
        {
            get { return textBox.ForeColor; }
            set { textBox.ForeColor = value; }
        }
        [Description("The lines of text in a multiline edit, as an array of String values.")]
        public string[] Lines
        {
            get { return textBox.Lines; }
            set { textBox.Lines = value; }
        }
        [Description("Specifies the maximum number of characters that can be entered into the edit control.")]
        public int MaxLength
        {
            get { return textBox.MaxLength; }
            set { textBox.MaxLength = value; }
        }
        [Description("Controls whether the text of the edit control can span more than one line.")]
        public bool Multiline
        {
            get { return textBox.Multiline; }
            set { textBox.Multiline = value; }
        }
        [Description("The text associated with this control.")]
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        [Description("Indicates how the text should be aligned for edit controls.")]
        public HorizontalAlignment TextAlign
        {
            get { return textBox.TextAlign; }
            set { textBox.TextAlign = value; }
        }


        //Events
        //[Description("Occurs when the component is clicked.")]
        public new event EventHandler Click
        {
            add { textBox.Click += value; }
            remove { textBox.Click -= value; }
        }
        //[Description("Event raised when the value of the Text property is changed on Control.")]
        public new event EventHandler TextChanged
        {
            add { textBox.TextChanged += value; }
            remove { textBox.TextChanged -= value; }
        }

        //Paint Border
        private Color currentColor;
        private void borderPaint(object sender, PaintEventArgs e)
        {
            if (textBox.Multiline)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, currentColor, ButtonBorderStyle.Solid);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height - 5), currentColor, ButtonBorderStyle.Solid);
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            currentColor = FocusedBorderColor;
            Invalidate();
        }
        protected override void OnLeave(EventArgs e)
        {
            currentColor = DefaultBorderColor;
            Invalidate();
        }

        //Resize
        private void textBoxResize(object sender, EventArgs e) => InvalidateSize();
        private void InvalidateSize()
        {
            textBox.Size = new Size(this.Width - 2, this.Height - 2);
            textBox.Location = new Point(1, 1);
        }
    }
}