namespace Movie_Theater_Management
{
    partial class Edit_Movies
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
            this.dv_movie = new System.Windows.Forms.DataGridView();
            this.Add_movie = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.txt_Duration = new System.Windows.Forms.TextBox();
            this.txt_Leadactors = new System.Windows.Forms.TextBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.genrechecklist = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dv_movie)).BeginInit();
            this.SuspendLayout();
            // 
            // dv_movie
            // 
            this.dv_movie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv_movie.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dv_movie.Location = new System.Drawing.Point(500, 123);
            this.dv_movie.Name = "dv_movie";
            this.dv_movie.RowHeadersWidth = 51;
            this.dv_movie.RowTemplate.Height = 24;
            this.dv_movie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dv_movie.Size = new System.Drawing.Size(494, 206);
            this.dv_movie.TabIndex = 0;
            // 
            // Add_movie
            // 
            this.Add_movie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_movie.Location = new System.Drawing.Point(401, 628);
            this.Add_movie.Name = "Add_movie";
            this.Add_movie.Size = new System.Drawing.Size(150, 30);
            this.Add_movie.TabIndex = 1;
            this.Add_movie.Text = "Add Movie";
            this.Add_movie.UseVisualStyleBackColor = true;
            this.Add_movie.Click += new System.EventHandler(this.Add_movie_Click_1);
            // 
            // edit_btn
            // 
            this.edit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_btn.Location = new System.Drawing.Point(660, 628);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(150, 30);
            this.edit_btn.TabIndex = 2;
            this.edit_btn.Text = "Edit Movie";
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click_1);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_btn.Location = new System.Drawing.Point(905, 628);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(150, 30);
            this.Delete_btn.TabIndex = 3;
            this.Delete_btn.Text = "Delete Movie";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // txt_Duration
            // 
            this.txt_Duration.Location = new System.Drawing.Point(1155, 498);
            this.txt_Duration.Name = "txt_Duration";
            this.txt_Duration.Size = new System.Drawing.Size(150, 22);
            this.txt_Duration.TabIndex = 4;
            this.txt_Duration.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_Leadactors
            // 
            this.txt_Leadactors.Location = new System.Drawing.Point(905, 498);
            this.txt_Leadactors.Name = "txt_Leadactors";
            this.txt_Leadactors.Size = new System.Drawing.Size(150, 22);
            this.txt_Leadactors.TabIndex = 5;
            // 
            // txt_desc
            // 
            this.txt_desc.Location = new System.Drawing.Point(646, 498);
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(150, 22);
            this.txt_desc.TabIndex = 6;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(388, 498);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(150, 22);
            this.txt_Name.TabIndex = 7;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(118, 498);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(150, 22);
            this.txt_ID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1193, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Duration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(930, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lead Actors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(667, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(435, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(174, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "ID";
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(75, 43);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(120, 30);
            this.btn_back.TabIndex = 14;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // genrechecklist
            // 
            this.genrechecklist.FormattingEnabled = true;
            this.genrechecklist.Items.AddRange(new object[] {
            "Action",
            "Thriller"});
            this.genrechecklist.Location = new System.Drawing.Point(1198, 167);
            this.genrechecklist.Name = "genrechecklist";
            this.genrechecklist.Size = new System.Drawing.Size(120, 89);
            this.genrechecklist.TabIndex = 15;
            this.genrechecklist.SelectedIndexChanged += new System.EventHandler(this.genrechecklist_SelectedIndexChanged);
            // 
            // Edit_Movies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 718);
            this.Controls.Add(this.genrechecklist);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.txt_Leadactors);
            this.Controls.Add(this.txt_Duration);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.Add_movie);
            this.Controls.Add(this.dv_movie);
            this.Name = "Edit_Movies";
            this.Text = "Edit Movies";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dv_movie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dv_movie;
        private System.Windows.Forms.Button Add_movie;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.TextBox txt_Duration;
        private System.Windows.Forms.TextBox txt_Leadactors;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.CheckedListBox genrechecklist;
    }
}