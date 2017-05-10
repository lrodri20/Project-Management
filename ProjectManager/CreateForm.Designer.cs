namespace ProjectManager
{
    partial class CreateForm
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
            this.pg_Create = new System.Windows.Forms.PropertyGrid();
            this.b_Save = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pg_Create
            // 
            this.pg_Create.Location = new System.Drawing.Point(13, 13);
            this.pg_Create.Name = "pg_Create";
            this.pg_Create.Size = new System.Drawing.Size(588, 518);
            this.pg_Create.TabIndex = 0;
            // 
            // b_Save
            // 
            this.b_Save.Location = new System.Drawing.Point(13, 552);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(135, 54);
            this.b_Save.TabIndex = 1;
            this.b_Save.Text = "Save";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(475, 551);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(125, 55);
            this.b_Cancel.TabIndex = 2;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 618);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_Save);
            this.Controls.Add(this.pg_Create);
            this.Name = "CreateForm";
            this.Text = "CreateForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pg_Create;
        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.Button b_Cancel;
    }
}