namespace Pagination.Presentation
{
    partial class ContentPresenterFlowLayout
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
            flowLayoutPanel = new FlowLayoutPanel();
            tableLayoutPanelControlStrip = new TableLayoutPanel();
            buttonNext = new Button();
            buttonPrev = new Button();
            label1 = new Label();
            tableLayoutPanel.SuspendLayout();
            tableLayoutPanelControlStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 0);
            tableLayoutPanel.Controls.Add(tableLayoutPanelControlStrip, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel.Size = new Size(500, 300);
            tableLayoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Font = new Font("Segoe UI", 10F);
            flowLayoutPanel.Location = new Point(4, 4);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(492, 249);
            flowLayoutPanel.TabIndex = 4;
            // 
            // tableLayoutPanelControlStrip
            // 
            tableLayoutPanelControlStrip.BackColor = Color.LightCyan;
            tableLayoutPanelControlStrip.ColumnCount = 3;
            tableLayoutPanelControlStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelControlStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelControlStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelControlStrip.Controls.Add(buttonNext, 2, 0);
            tableLayoutPanelControlStrip.Controls.Add(buttonPrev, 0, 0);
            tableLayoutPanelControlStrip.Controls.Add(label1, 1, 0);
            tableLayoutPanelControlStrip.Dock = DockStyle.Fill;
            tableLayoutPanelControlStrip.Location = new Point(4, 260);
            tableLayoutPanelControlStrip.Name = "tableLayoutPanelControlStrip";
            tableLayoutPanelControlStrip.RowCount = 1;
            tableLayoutPanelControlStrip.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelControlStrip.Size = new Size(492, 36);
            tableLayoutPanelControlStrip.TabIndex = 5;
            // 
            // buttonNext
            // 
            buttonNext.Dock = DockStyle.Fill;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.Location = new Point(328, 0);
            buttonNext.Margin = new Padding(0);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(164, 36);
            buttonNext.TabIndex = 2;
            buttonNext.Text = "▶";
            buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonPrev
            // 
            buttonPrev.Dock = DockStyle.Fill;
            buttonPrev.FlatAppearance.BorderSize = 0;
            buttonPrev.FlatStyle = FlatStyle.Flat;
            buttonPrev.Location = new Point(0, 0);
            buttonPrev.Margin = new Padding(0);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(164, 36);
            buttonPrev.TabIndex = 1;
            buttonPrev.Text = "◀";
            buttonPrev.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(167, 0);
            label1.Name = "label1";
            label1.Size = new Size(158, 36);
            label1.TabIndex = 3;
            label1.Text = "0/0";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FlowLayoutRecycler
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Font = new Font("Segoe UI", 12F);
            Name = "FlowLayoutRecycler";
            Size = new Size(500, 300);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanelControlStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Button buttonNext;
        private Button buttonPrev;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel;
        private TableLayoutPanel tableLayoutPanelControlStrip;
    }
}
