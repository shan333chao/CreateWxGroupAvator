namespace BuildAvactor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuildAvator = new System.Windows.Forms.Button();
            this.tbImgCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBuildAvator
            // 
            this.btnBuildAvator.Location = new System.Drawing.Point(160, 26);
            this.btnBuildAvator.Name = "btnBuildAvator";
            this.btnBuildAvator.Size = new System.Drawing.Size(75, 23);
            this.btnBuildAvator.TabIndex = 0;
            this.btnBuildAvator.Text = "生成头像";
            this.btnBuildAvator.UseVisualStyleBackColor = true;
            this.btnBuildAvator.Click += new System.EventHandler(this.btnBuildAvator_Click);
            // 
            // tbImgCount
            // 
            this.tbImgCount.Location = new System.Drawing.Point(42, 26);
            this.tbImgCount.Name = "tbImgCount";
            this.tbImgCount.Size = new System.Drawing.Size(100, 21);
            this.tbImgCount.TabIndex = 1;
            this.tbImgCount.Text = "9";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 75);
            this.Controls.Add(this.tbImgCount);
            this.Controls.Add(this.btnBuildAvator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuildAvator;
        private System.Windows.Forms.TextBox tbImgCount;
    }
}

