namespace Tech_Conn
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileNameMas = new System.Windows.Forms.MaskedTextBox();
            this.destFolder = new System.Windows.Forms.MaskedTextBox();
            this.buttonSelectfileNameMas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectdestFolder = new System.Windows.Forms.Button();
            this.buttonGetData = new System.Windows.Forms.Button();
            this.tbProcess = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fileNameMas
            // 
            this.fileNameMas.Location = new System.Drawing.Point(131, 12);
            this.fileNameMas.Name = "fileNameMas";
            this.fileNameMas.Size = new System.Drawing.Size(574, 20);
            this.fileNameMas.TabIndex = 55;
            // 
            // destFolder
            // 
            this.destFolder.Location = new System.Drawing.Point(131, 47);
            this.destFolder.Name = "destFolder";
            this.destFolder.Size = new System.Drawing.Size(574, 20);
            this.destFolder.TabIndex = 56;
            // 
            // buttonSelectfileNameMas
            // 
            this.buttonSelectfileNameMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectfileNameMas.Location = new System.Drawing.Point(711, 12);
            this.buttonSelectfileNameMas.Name = "buttonSelectfileNameMas";
            this.buttonSelectfileNameMas.Size = new System.Drawing.Size(23, 21);
            this.buttonSelectfileNameMas.TabIndex = 61;
            this.buttonSelectfileNameMas.Text = "...";
            this.buttonSelectfileNameMas.UseVisualStyleBackColor = true;
            this.buttonSelectfileNameMas.Click += new System.EventHandler(this.buttonSelectfileNameMas_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "Файл данных:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Папка назначения:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSelectdestFolder
            // 
            this.buttonSelectdestFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectdestFolder.Location = new System.Drawing.Point(711, 46);
            this.buttonSelectdestFolder.Name = "buttonSelectdestFolder";
            this.buttonSelectdestFolder.Size = new System.Drawing.Size(23, 21);
            this.buttonSelectdestFolder.TabIndex = 65;
            this.buttonSelectdestFolder.Text = "...";
            this.buttonSelectdestFolder.UseVisualStyleBackColor = true;
            this.buttonSelectdestFolder.Click += new System.EventHandler(this.buttonSelectdestFolder_Click);
            // 
            // buttonGetData
            // 
            this.buttonGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetData.Location = new System.Drawing.Point(521, 84);
            this.buttonGetData.Name = "buttonGetData";
            this.buttonGetData.Size = new System.Drawing.Size(184, 31);
            this.buttonGetData.TabIndex = 66;
            this.buttonGetData.Text = "Создать отчеты";
            this.buttonGetData.UseVisualStyleBackColor = true;
            this.buttonGetData.Click += new System.EventHandler(this.buttonGetData_Click);
            // 
            // tbProcess
            // 
            this.tbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProcess.Location = new System.Drawing.Point(12, 121);
            this.tbProcess.Multiline = true;
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbProcess.Size = new System.Drawing.Size(722, 229);
            this.tbProcess.TabIndex = 67;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 362);
            this.Controls.Add(this.tbProcess);
            this.Controls.Add(this.buttonGetData);
            this.Controls.Add(this.buttonSelectdestFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelectfileNameMas);
            this.Controls.Add(this.destFolder);
            this.Controls.Add(this.fileNameMas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox fileNameMas;
        private System.Windows.Forms.MaskedTextBox destFolder;
        private System.Windows.Forms.Button buttonSelectfileNameMas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectdestFolder;
        private System.Windows.Forms.Button buttonGetData;
        private System.Windows.Forms.TextBox tbProcess;
    }
}

