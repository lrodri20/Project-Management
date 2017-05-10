namespace ProjectManager
{
    partial class EmployeeForm
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
            this.b_Save = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.cb_SelectHours = new System.Windows.Forms.ComboBox();
            this.tb_CurrProjHours = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_Save
            // 
            this.b_Save.Location = new System.Drawing.Point(13, 226);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(75, 23);
            this.b_Save.TabIndex = 0;
            this.b_Save.Text = "Save";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(197, 226);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 1;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // cb_SelectHours
            // 
            this.cb_SelectHours.FormattingEnabled = true;
            this.cb_SelectHours.Items.AddRange(new object[] {
            "Man Hours",
            "Test Hours",
            "Code Hours",
            "Design Hours",
            "Analysis Hours"});
            this.cb_SelectHours.Location = new System.Drawing.Point(13, 54);
            this.cb_SelectHours.Name = "cb_SelectHours";
            this.cb_SelectHours.Size = new System.Drawing.Size(121, 21);
            this.cb_SelectHours.TabIndex = 2;
            this.cb_SelectHours.SelectionChangeCommitted += new System.EventHandler(this.cb_SelectHours_DropDownClosed);
            this.cb_SelectHours.DropDownClosed += new System.EventHandler(this.cb_SelectHours_DropDownClosed);
            // 
            // tb_CurrProjHours
            // 
            this.tb_CurrProjHours.Location = new System.Drawing.Point(13, 116);
            this.tb_CurrProjHours.Name = "tb_CurrProjHours";
            this.tb_CurrProjHours.Size = new System.Drawing.Size(100, 20);
            this.tb_CurrProjHours.TabIndex = 3;
            this.tb_CurrProjHours.Leave += new System.EventHandler(this.tb_CurrProjHours_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hours To Edit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current Project Hours";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_CurrProjHours);
            this.Controls.Add(this.cb_SelectHours);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_Save);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.ComboBox cb_SelectHours;
        private System.Windows.Forms.TextBox tb_CurrProjHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}