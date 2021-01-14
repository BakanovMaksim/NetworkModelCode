
namespace NetworkModelCode.Desktop
{
    partial class Form1
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProject = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.enterButton = new System.Windows.Forms.Button();
            this.numberWorkCountTxt = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.ColumnI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEarlyStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEarlyEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFullTimeReserve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFreeTimeReserve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemProject});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(968, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItemFile.Text = "Файл";
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemEdit.Text = "Правка";
            // 
            // toolStripMenuItemProject
            // 
            this.toolStripMenuItemProject.Name = "toolStripMenuItemProject";
            this.toolStripMenuItemProject.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemProject.Text = "Проект";
            this.toolStripMenuItemProject.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnI,
            this.ColumnJ,
            this.ColumnTime,
            this.ColumnEarlyStart,
            this.ColumnEarlyEnd,
            this.ColumnLateStart,
            this.ColumnLateEnd,
            this.ColumnFullTimeReserve,
            this.ColumnFreeTimeReserve});
            this.dataGridView.Location = new System.Drawing.Point(0, 55);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(944, 364);
            this.dataGridView.TabIndex = 1;
            // 
            // enterButton
            // 
            this.enterButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.enterButton.Location = new System.Drawing.Point(440, 425);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(77, 28);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "Ввод";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // numberWorkCountTxt
            // 
            this.numberWorkCountTxt.Location = new System.Drawing.Point(440, 26);
            this.numberWorkCountTxt.Name = "numberWorkCountTxt";
            this.numberWorkCountTxt.Size = new System.Drawing.Size(77, 23);
            this.numberWorkCountTxt.TabIndex = 3;
            this.numberWorkCountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberWorkCountTxt.TextChanged += new System.EventHandler(this.numberWorkCountTxt_TextChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTable);
            this.tabControl.Controls.Add(this.tabPageGraph);
            this.tabControl.Location = new System.Drawing.Point(12, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(944, 494);
            this.tabControl.TabIndex = 4;
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.dataGridView);
            this.tabPageTable.Controls.Add(this.numberWorkCountTxt);
            this.tabPageTable.Controls.Add(this.enterButton);
            this.tabPageTable.Location = new System.Drawing.Point(4, 24);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(936, 466);
            this.tabPageTable.TabIndex = 0;
            this.tabPageTable.Text = "Таблица";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Location = new System.Drawing.Point(4, 24);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraph.Size = new System.Drawing.Size(936, 466);
            this.tabPageGraph.TabIndex = 1;
            this.tabPageGraph.Text = "Сетевой график";
            this.tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // ColumnI
            // 
            this.ColumnI.HeaderText = "i";
            this.ColumnI.Name = "ColumnI";
            // 
            // ColumnJ
            // 
            this.ColumnJ.HeaderText = "j";
            this.ColumnJ.Name = "ColumnJ";
            // 
            // ColumnTime
            // 
            this.ColumnTime.HeaderText = "t";
            this.ColumnTime.Name = "ColumnTime";
            // 
            // ColumnEarlyStart
            // 
            this.ColumnEarlyStart.HeaderText = "t^рн";
            this.ColumnEarlyStart.Name = "ColumnEarlyStart";
            // 
            // ColumnEarlyEnd
            // 
            this.ColumnEarlyEnd.HeaderText = "t^ро";
            this.ColumnEarlyEnd.Name = "ColumnEarlyEnd";
            // 
            // ColumnLateStart
            // 
            this.ColumnLateStart.HeaderText = "t^пн";
            this.ColumnLateStart.Name = "ColumnLateStart";
            // 
            // ColumnLateEnd
            // 
            this.ColumnLateEnd.HeaderText = "t^по";
            this.ColumnLateEnd.Name = "ColumnLateEnd";
            // 
            // ColumnFullTimeReserve
            // 
            this.ColumnFullTimeReserve.HeaderText = "R";
            this.ColumnFullTimeReserve.Name = "ColumnFullTimeReserve";
            // 
            // ColumnFreeTimeReserve
            // 
            this.ColumnFreeTimeReserve.HeaderText = "r";
            this.ColumnFreeTimeReserve.Name = "ColumnFreeTimeReserve";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 533);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageTable.ResumeLayout(false);
            this.tabPageTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProject;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.TextBox numberWorkCountTxt;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEarlyStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEarlyEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFullTimeReserve;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFreeTimeReserve;
    }
}

