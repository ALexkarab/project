namespace SimplexMethod
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.matrix = new System.Windows.Forms.DataGridView();
            this.varCount = new System.Windows.Forms.TextBox();
            this.restrCount = new System.Windows.Forms.TextBox();
            this.SetGrid = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SolveSystem = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.pastMatrix = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.matrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pastMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // matrix
            // 
            this.matrix.AllowUserToAddRows = false;
            this.matrix.AllowUserToDeleteRows = false;
            this.matrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.matrix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrix.Location = new System.Drawing.Point(415, 17);
            this.matrix.Name = "matrix";
            this.matrix.Size = new System.Drawing.Size(289, 150);
            this.matrix.TabIndex = 0;
            // 
            // varCount
            // 
            this.varCount.Location = new System.Drawing.Point(155, 17);
            this.varCount.Name = "varCount";
            this.varCount.Size = new System.Drawing.Size(40, 20);
            this.varCount.TabIndex = 1;
            // 
            // restrCount
            // 
            this.restrCount.Location = new System.Drawing.Point(155, 46);
            this.restrCount.Name = "restrCount";
            this.restrCount.Size = new System.Drawing.Size(40, 20);
            this.restrCount.TabIndex = 2;
            // 
            // SetGrid
            // 
            this.SetGrid.Location = new System.Drawing.Point(75, 81);
            this.SetGrid.Name = "SetGrid";
            this.SetGrid.Size = new System.Drawing.Size(75, 23);
            this.SetGrid.TabIndex = 3;
            this.SetGrid.Text = "Задать систему";
            this.SetGrid.UseVisualStyleBackColor = true;
            this.SetGrid.Click += new System.EventHandler(this.SetGrid_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Кол-во переменных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Кол-во ограничений";
            // 
            // SolveSystem
            // 
            this.SolveSystem.Location = new System.Drawing.Point(25, 429);
            this.SolveSystem.Name = "SolveSystem";
            this.SolveSystem.Size = new System.Drawing.Size(75, 23);
            this.SolveSystem.TabIndex = 6;
            this.SolveSystem.Text = "Решить";
            this.SolveSystem.UseVisualStyleBackColor = true;
            this.SolveSystem.Click += new System.EventHandler(this.SolveSystem_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(132, 382);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(147, 108);
            this.logBox.TabIndex = 7;
            // 
            // pastMatrix
            // 
            this.pastMatrix.AllowUserToAddRows = false;
            this.pastMatrix.AllowUserToDeleteRows = false;
            this.pastMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pastMatrix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.pastMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pastMatrix.Location = new System.Drawing.Point(415, 211);
            this.pastMatrix.Name = "pastMatrix";
            this.pastMatrix.ReadOnly = true;
            this.pastMatrix.Size = new System.Drawing.Size(289, 172);
            this.pastMatrix.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 514);
            this.Controls.Add(this.pastMatrix);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.SolveSystem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SetGrid);
            this.Controls.Add(this.restrCount);
            this.Controls.Add(this.varCount);
            this.Controls.Add(this.matrix);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.matrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pastMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView matrix;
        private System.Windows.Forms.TextBox varCount;
        private System.Windows.Forms.TextBox restrCount;
        private System.Windows.Forms.Button SetGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SolveSystem;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.DataGridView pastMatrix;
    }
}

