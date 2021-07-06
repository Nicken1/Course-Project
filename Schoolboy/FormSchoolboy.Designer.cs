
namespace Клиентское
{
    partial class FormSchoolboy
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonGradebook = new System.Windows.Forms.Button();
            this.buttonTimetable = new System.Windows.Forms.Button();
            this.buttonEvents = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 283);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // buttonGradebook
            // 
            this.buttonGradebook.Location = new System.Drawing.Point(12, 300);
            this.buttonGradebook.Name = "buttonGradebook";
            this.buttonGradebook.Size = new System.Drawing.Size(190, 24);
            this.buttonGradebook.TabIndex = 2;
            this.buttonGradebook.Text = "Просмотр журнала";
            this.buttonGradebook.UseVisualStyleBackColor = true;
            this.buttonGradebook.Click += new System.EventHandler(this.buttonGradebook_Click);
            // 
            // buttonTimetable
            // 
            this.buttonTimetable.Location = new System.Drawing.Point(217, 300);
            this.buttonTimetable.Name = "buttonTimetable";
            this.buttonTimetable.Size = new System.Drawing.Size(190, 24);
            this.buttonTimetable.TabIndex = 3;
            this.buttonTimetable.Text = "Просмотр расписания";
            this.buttonTimetable.UseVisualStyleBackColor = true;
            this.buttonTimetable.Click += new System.EventHandler(this.buttonTimetable_Click);
            // 
            // buttonEvents
            // 
            this.buttonEvents.Location = new System.Drawing.Point(422, 300);
            this.buttonEvents.Name = "buttonEvents";
            this.buttonEvents.Size = new System.Drawing.Size(190, 24);
            this.buttonEvents.TabIndex = 4;
            this.buttonEvents.Text = "расписание кружков";
            this.buttonEvents.UseVisualStyleBackColor = true;
            this.buttonEvents.Click += new System.EventHandler(this.buttonEvents_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 428);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 74);
            this.buttonBack.TabIndex = 5;
            this.buttonBack.Text = "Выйти";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonProfile
            // 
            this.buttonProfile.Location = new System.Drawing.Point(429, 476);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(190, 26);
            this.buttonProfile.TabIndex = 6;
            this.buttonProfile.Text = "Просмотр профиля";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // FormSchoolboy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 514);
            this.Controls.Add(this.buttonProfile);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonEvents);
            this.Controls.Add(this.buttonTimetable);
            this.Controls.Add(this.buttonGradebook);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSchoolboy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSchoolboy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSchoolboy_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonGradebook;
        private System.Windows.Forms.Button buttonTimetable;
        private System.Windows.Forms.Button buttonEvents;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonProfile;
    }
}