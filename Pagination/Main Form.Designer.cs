namespace Pagination
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            contentPresenterFlowLayout = new Pagination.Presentation.ContentPresenterFlowLayout();
            SuspendLayout();
            // 
            // contentPresenterFlowLayout
            // 
            contentPresenterFlowLayout.BackColor = SystemColors.Control;
            contentPresenterFlowLayout.Dock = DockStyle.Fill;
            contentPresenterFlowLayout.Font = new Font("Segoe UI", 12F);
            contentPresenterFlowLayout.Location = new Point(2, 2);
            contentPresenterFlowLayout.Name = "contentPresenterFlowLayout";
            contentPresenterFlowLayout.PageSize = 10;
            contentPresenterFlowLayout.Size = new Size(1074, 540);
            contentPresenterFlowLayout.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aqua;
            ClientSize = new Size(1078, 544);
            Controls.Add(contentPresenterFlowLayout);
            Font = new Font("Segoe UI", 10F);
            Name = "MainForm";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Form";
            ResumeLayout(false);
        }

        #endregion

        private Pagination.Presentation.ContentPresenterFlowLayout contentPresenterFlowLayout;
    }
}
