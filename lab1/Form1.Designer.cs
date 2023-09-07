namespace lab1
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnEndSession = new System.Windows.Forms.Button();
            this.ActivitiesList = new System.Windows.Forms.DataGridView();
            this.btnAddActivity = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ActivitiesList)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnEndSession
            // 
            this.btnEndSession.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEndSession.Location = new System.Drawing.Point(0, 486);
            this.btnEndSession.Name = "btnEndSession";
            this.btnEndSession.Size = new System.Drawing.Size(746, 23);
            this.btnEndSession.TabIndex = 1;
            this.btnEndSession.Text = "Завершить сессию";
            this.btnEndSession.UseVisualStyleBackColor = true;
            this.btnEndSession.Click += new System.EventHandler(this.btnEndSession_Click);
            // 
            // ActivitiesList
            // 
            this.ActivitiesList.AllowUserToAddRows = false;
            this.ActivitiesList.AllowUserToDeleteRows = false;
            this.ActivitiesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ActivitiesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActivitiesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActivitiesList.Location = new System.Drawing.Point(0, 0);
            this.ActivitiesList.Name = "ActivitiesList";
            this.ActivitiesList.ReadOnly = true;
            this.ActivitiesList.RowTemplate.Height = 25;
            this.ActivitiesList.Size = new System.Drawing.Size(746, 417);
            this.ActivitiesList.TabIndex = 3;
            // 
            // btnAddActivity
            // 
            this.btnAddActivity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddActivity.Location = new System.Drawing.Point(0, 417);
            this.btnAddActivity.Name = "btnAddActivity";
            this.btnAddActivity.Size = new System.Drawing.Size(746, 23);
            this.btnAddActivity.TabIndex = 5;
            this.btnAddActivity.Text = "Добавить тренировку";
            this.btnAddActivity.UseVisualStyleBackColor = true;
            this.btnAddActivity.Click += new System.EventHandler(this.btnAddActivity_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEdit.Location = new System.Drawing.Point(0, 440);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(746, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Изменить тренировку";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(0, 463);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(746, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить тренировку";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(746, 509);
            this.Controls.Add(this.ActivitiesList);
            this.Controls.Add(this.btnAddActivity);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEndSession);
            this.MinimumSize = new System.Drawing.Size(762, 548);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ActivitiesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button btnEndSession;
        private DataGridView ActivitiesList;
        private Button btnAddActivity;
        private Button btnEdit;
        private Button btnDelete;
    }
}