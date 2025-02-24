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
            menuStrip = new MenuStrip();
            testToolStripMenuItem = new ToolStripMenuItem();
            itemsToolStripMenuItem = new ToolStripMenuItem();
            itemsToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            imageWithRandoControlsToolStripMenuItem = new ToolStripMenuItem();
            regularButtonsToolStripMenuItem = new ToolStripMenuItem();
            irregularButtonsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // contentPresenterFlowLayout
            // 
            contentPresenterFlowLayout.BackColor = SystemColors.Control;
            contentPresenterFlowLayout.Dock = DockStyle.Fill;
            contentPresenterFlowLayout.Font = new Font("Segoe UI", 12F);
            contentPresenterFlowLayout.Location = new Point(2, 42);
            contentPresenterFlowLayout.Name = "contentPresenterFlowLayout";
            contentPresenterFlowLayout.PageSize = 10;
            contentPresenterFlowLayout.Size = new Size(1074, 500);
            contentPresenterFlowLayout.TabIndex = 1;
            // 
            // menuStrip
            // 
            menuStrip.Font = new Font("Segoe UI", 14F);
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { testToolStripMenuItem });
            menuStrip.Location = new Point(2, 2);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1074, 40);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemsToolStripMenuItem, itemsToolStripMenuItem1, toolStripMenuItem1, imageWithRandoControlsToolStripMenuItem, regularButtonsToolStripMenuItem, irregularButtonsToolStripMenuItem });
            testToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(72, 36);
            testToolStripMenuItem.Text = "Test";
            // 
            // itemsToolStripMenuItem
            // 
            itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            itemsToolStripMenuItem.Size = new Size(433, 40);
            itemsToolStripMenuItem.Text = "25 Items";
            itemsToolStripMenuItem.Tag = TestOption.Items25;
            // 
            // itemsToolStripMenuItem1
            // 
            itemsToolStripMenuItem1.Name = "itemsToolStripMenuItem1";
            itemsToolStripMenuItem1.Size = new Size(433, 40);
            itemsToolStripMenuItem1.Text = "1M Items";
            itemsToolStripMenuItem1.Tag = TestOption.Items1M;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(430, 6);
            // 
            // imageWithRandoControlsToolStripMenuItem
            // 
            imageWithRandoControlsToolStripMenuItem.Name = "imageWithRandoControlsToolStripMenuItem";
            imageWithRandoControlsToolStripMenuItem.Size = new Size(433, 40);
            imageWithRandoControlsToolStripMenuItem.Text = "Image With Random Controls";
            imageWithRandoControlsToolStripMenuItem.Tag = TestOption.ImageRando;
            // 
            // regularButtonsToolStripMenuItem
            // 
            regularButtonsToolStripMenuItem.Name = "regularButtonsToolStripMenuItem";
            regularButtonsToolStripMenuItem.Size = new Size(433, 40);
            regularButtonsToolStripMenuItem.Text = "Regular Buttons";
            regularButtonsToolStripMenuItem.Tag = TestOption.ButtonRegular;
            // 
            // irregularButtonsToolStripMenuItem
            // 
            irregularButtonsToolStripMenuItem.Name = "irregularButtonsToolStripMenuItem";
            irregularButtonsToolStripMenuItem.Size = new Size(433, 40);
            irregularButtonsToolStripMenuItem.Text = "Irregular Buttons";
            irregularButtonsToolStripMenuItem.Tag = TestOption.ButtonIrregular;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aqua;
            ClientSize = new Size(1078, 544);
            Controls.Add(contentPresenterFlowLayout);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI", 10F);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Form";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Pagination.Presentation.ContentPresenterFlowLayout contentPresenterFlowLayout;
        private MenuStrip menuStrip;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem itemsToolStripMenuItem;
        private ToolStripMenuItem itemsToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem imageWithRandoControlsToolStripMenuItem;
        private ToolStripMenuItem regularButtonsToolStripMenuItem;
        private ToolStripMenuItem irregularButtonsToolStripMenuItem;
    }
}
