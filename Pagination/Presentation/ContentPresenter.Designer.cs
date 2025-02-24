namespace Pagination.Presentation
{
    partial class ContentPresenter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            pictureBox = new PictureBox();
            checkBox = new CheckBox();
            button = new Button();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(checkBox, 0, 1);
            tableLayoutPanel.Controls.Add(button, 1, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(200, 200);
            tableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.BackColor = Color.Black;
            tableLayoutPanel.SetColumnSpan(pictureBox, 2);
            pictureBox.Location = new Point(3, 3);
            pictureBox.MinimumSize = new Size(100, 100);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(194, 150);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // checkBox
            // 
            checkBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            checkBox.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox.Font = new Font("Segoe UI", 8F);
            checkBox.ForeColor = Color.Black;
            checkBox.Location = new Point(20, 157);
            checkBox.Margin = new Padding(20, 0, 20, 0);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(39, 41);
            checkBox.TabIndex = 1;
            checkBox.UseVisualStyleBackColor = false;
            // 
            // button
            // 
            button.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button.BackColor = Color.LightBlue;
            button.Font = new Font("Segoe UI", 8F);
            button.ForeColor = Color.FromArgb(34, 34, 34);
            button.Location = new Point(84, 161);
            button.Margin = new Padding(5);
            button.Name = "button";
            button.Size = new Size(111, 34);
            button.TabIndex = 3;
            button.Text = "Edit";
            button.UseVisualStyleBackColor = false;
            // 
            // ContentPresenter
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel);
            Name = "ContentPresenter";
            Size = new Size(200, 200);
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private PictureBox pictureBox;
        private CheckBox checkBox;
        private Button button;
    }
}
